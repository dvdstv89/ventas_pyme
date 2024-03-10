using Database;
using Database.Class;
using ModelData.Atributo;
using System;
using System.Data.Common;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Model
{ 
    public enum TipoPlanVenta
    {
        Tienda = 1,
        Complejo = 2        
    }

    public class PlanVentaMensual : BaseModelPro<PlanVentaMensual, string>, ISincronizable<PlanVentaMensual, string>,ICloneable
    {       
        public Atributo_Datetime fecha { get; set; } = new Atributo_Datetime("fecha", true);
        public Atributo_Moneda moneda { get; set; } = new Atributo_Moneda("id_moneda");
        public Atributo_Money saldo { get; set; } = new Atributo_Money("saldo");
        public Atributo_Money realDetallado { get; set; } = new Atributo_Money("real_detallado"); //venta detallada + comision detallada
        public Atributo_Money realResumido { get; set; } = new Atributo_Money("real_resumido");      
        public Atributo_Money planDiario { get; set; } = new Atributo_Money("");
        private TipoPlanVenta tipoPlanVenta;
        private int idCreador;
        public PlanVentaTienda planVentaTienda { get; set; }
        public PlanVentaComplejo planVentaComplejo { get; set; }
        public Atributo_Porciento porcientoCumplimientoDetallado
        {
            get
            {     
              return new Atributo_Porciento(realDetallado.getPorcientoDe(saldo)); 
            }
            set { }
        }
        public Atributo_Porciento porcientoCumplimientoResumido
        {
            get
            {               
                return new Atributo_Porciento(realResumido.getPorcientoDe(saldo));
            }
            set { }
        }
        public PlanVentaMensual()
        {
            setTabla();
        }       
        public  PlanVentaMensual(DateTime fecha, Moneda moneda, string tokenId, TipoPlanVenta tipoPlanVenta, string idCreador) :base(tokenId)
        {           
            this.fecha.setFecha(fecha);
            setId(tipoPlanVenta, idCreador);          
            this.moneda.setObjeto(moneda);
            inicializarPlanVenta();

        }
        public PlanVentaMensual(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        { 
            this.id.setValue(sqlReader);
            this.fecha.setValue(sqlReader);         
            this.moneda.setValue(sqlReader);
            this.saldo.setValue(sqlReader);
            this.realDetallado.setValue(sqlReader);
            this.realResumido.setValue(sqlReader);
            this.planDiario.setMoney(getPlanDiario());           
            inicializarPlanVenta();
        }
        private void setId(TipoPlanVenta tipoPlan, string idCreador)
        {
            //1:50:2023-01-01
            this.id.Value = (int)tipoPlan + ":" + idCreador + ":" + fecha.getAsString();
        }      
        private decimal getPlanDiario()
        {
            return saldo.MoneyAccount / fecha.countDaysMes();
        }
        protected new void setTabla()
        {
            tabla = new Tabla("plan_venta_mensual", "pvm");
        }       
        public object Clone()
        {
            PlanVentaMensual plan = new PlanVentaMensual();
            plan.id = new Atributo_PK<string>(this.id.Value, this.id.ColumnName);
            plan.fecha = new Atributo_Datetime(this.fecha.Fecha, this.fecha.ColumnName);
            plan.moneda = new Atributo_Moneda(this.moneda.Objeto, this.moneda.ColumnName);
            plan.saldo = new Atributo_Money(this.saldo.MoneyAccount, this.saldo.ColumnName);
            plan.realDetallado = new Atributo_Money(this.realDetallado.MoneyAccount, this.realDetallado.ColumnName);
            plan.realResumido = new Atributo_Money(this.realResumido.MoneyAccount, this.realResumido.ColumnName);
            plan.version = new Atributo<long>(this.version.Value, this.version.ColumnName);
            plan.isActivo = new Atributo<bool>(this.isActivo.Value, this.isActivo.ColumnName);
            plan.isSincronizada = new Atributo<bool>(this.isSincronizada.Value, this.isSincronizada.ColumnName);
            plan.isEliminada = new Atributo<bool>(this.isEliminada.Value, this.isEliminada.ColumnName);
            plan.tokenCreador = new Atributo<string>(this.tokenCreador.Value, this.tokenCreador.ColumnName);
            plan.tokenModificador = new Atributo<string>(this.tokenModificador.Value, this.tokenModificador.ColumnName);
            plan.fechaCreacion = new Atributo_Datetime(this.fechaCreacion.Fecha, this.fechaCreacion.ColumnName);
            plan.fechaModificacion = new Atributo_Datetime(this.fechaModificacion.Fecha, this.fechaModificacion.ColumnName);
            return plan;
        }       
        private void inicializarPlanVenta()
        {
            interpretarID();
            if (tipoPlanVenta == TipoPlanVenta.Tienda)
            {
                planVentaTienda = new PlanVentaTienda(idCreador, id.Value, fecha.Anno.Value);
                planVentaComplejo = null;
            }
            else
            {
                planVentaComplejo = new PlanVentaComplejo(idCreador, id.Value, fecha.Anno.Value);
                planVentaTienda = null;
            }
        }
        private void interpretarID()
        {
            string[] idString = id.Value.Split(':');
            int idTipoPlanVenta = int.Parse(idString[0]);
            this.idCreador = int.Parse(idString[1]);
            this.tipoPlanVenta = (TipoPlanVenta)idTipoPlanVenta;
        }
    }    
}
