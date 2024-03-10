using Database;
using Database.Class;
using LocalData.Atributo;
using LocalData.Model;
using System;
using System.Data.Common;

namespace ModelData.Model
{
    public enum TipoPlanServicio
    {
        Metrocontador = 1,
        Complejo = 2
    }
    public class PlanServicioMensual : BaseModelPro<PlanServicioMensual, string>, ISincronizable<PlanServicioMensual, string>,ICloneable
    {       
        public Atributo_Datetime fecha { get; set; } = new Atributo_Datetime("fecha", true);       
        public Atributo_Consumo planMes { get; set; } = new Atributo_Consumo("plan_mes");
        public Atributo_Consumo realConsumidoMes { get; set; } = new Atributo_Consumo("real_consumido_mes");
        public Atributo_Servicio tipoServicio { get; set; } = new Atributo_Servicio("id_servicio");
        public Atributo_Consumo planDiario { get; set; } = new Atributo_Consumo("");

        private TipoPlanServicio tipoPlanServicio;
        private int idCreador;
        public PlanServicioMetrocontador planServicioMetrocontador { get; set; }
        public PlanServicioComplejo planServicioComplejo { get; set; }

        public PlanServicioMensual()
        {
            setTabla();
        }       
        public PlanServicioMensual(DateTime fecha, TipoServicio tipoServicio, string tokenId, TipoPlanServicio tipoPlanServicio, string idCreador) :base(tokenId)
        {
            this.fecha.setFecha(fecha);
            setId(tipoPlanServicio,tipoServicio, idCreador);
            this.tipoServicio.setObjeto(tipoServicio);
            inicializarPlanServicio();
        }
        public PlanServicioMensual(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.fecha.setValue(sqlReader);
            this.planMes.setValue(sqlReader);
            this.tipoServicio.setValue(sqlReader);
            this.realConsumidoMes.setValue(sqlReader);        
            this.planDiario.setConsumo(getPlanDiario());
            inicializarPlanServicio();
        }
        private void setId(TipoPlanServicio tipoPlan, TipoServicio tipoServicio, string idCreador)
        {
            //1:1:50:2023-01-01
            this.id.Value = (int)tipoPlan + ":" + tipoServicio.getId() + ":" + idCreador + ":" + fecha.getAsString();
        }       
        private decimal getPlanDiario()
        {
            return planMes.Consumo / fecha.countDaysMes();
        }
        protected new void setTabla()
        {
            tabla = new Tabla("plan_servicio_mensual", "psm");
        }       
        public object Clone()
        {
            PlanServicioMensual plan = new PlanServicioMensual();
            plan.id = new Atributo_PK<string>(this.id.Value, this.id.ColumnName);
            plan.fecha = new Atributo_Datetime(this.fecha.Fecha, this.fecha.ColumnName);
            plan.planMes = new Atributo_Consumo(this.planMes.Consumo, this.planMes.ColumnName);
            plan.realConsumidoMes = new Atributo_Consumo(this.realConsumidoMes.Consumo, this.realConsumidoMes.ColumnName);
            plan.tipoServicio = new Atributo_Servicio(this.tipoServicio.Objeto, this.tipoServicio.ColumnName);
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
        private void inicializarPlanServicio()
        {
            interpretarID();
            if (tipoPlanServicio == TipoPlanServicio.Metrocontador)
            {
                planServicioMetrocontador = new PlanServicioMetrocontador(idCreador, id.Value, fecha.Anno.Value);
                planServicioComplejo = null;
            }
            else
            {
                planServicioComplejo = new PlanServicioComplejo(idCreador, id.Value, fecha.Anno.Value);
                planServicioMetrocontador = null;
            }
        }
        private void interpretarID()
        {
            string[] idString = id.Value.Split(':');
            int idTipoPlanServicio = int.Parse(idString[0]);
            this.idCreador = int.Parse(idString[2]);
            this.tipoPlanServicio = (TipoPlanServicio)idTipoPlanServicio;
        }
    }    
}
