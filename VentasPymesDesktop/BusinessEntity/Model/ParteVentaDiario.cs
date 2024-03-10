using Database;
using Database.Class;
using ModelData.Atributo;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Data.Common;
using System.Numerics;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Model
{
    public class ParteVentaDiario : BaseModelPro<ParteVentaDiario, string>, ISincronizable<ParteVentaDiario, string>
    {       
        public Atributo_Datetime fecha { get; set; } = new Atributo_Datetime("fecha");
        public Atributo_Moneda moneda { get; set; } = new Atributo_Moneda("id_moneda");
        public Atributo_FormaPago formaPago { get; set; } = new Atributo_FormaPago("id_forma_pago");
        public Atributo_Money saldo { get; set; } = new Atributo_Money("saldo");
        public Atributo_PK<int> idTienda { get; set; } = new Atributo_PK<int>("id_tienda");
        public Atributo_PK<string> idConsiliacion { get; set; } = new Atributo_PK<string>("id_consiliacion");
        public Atributo_Money comision { get; set; } = new Atributo_Money("comision");
        public Atributo_Money saldoMasComision
        {
            get
            {
                decimal valor =  saldo.MoneyAccount+comision.MoneyAccount;
                return AtributoFactory.buildMoney(valor);
            }
            set { }
        }
        public ParteVentaDiario()
        {
            setTabla();
        }
        public ParteVentaDiario(string tokenId) : base(tokenId)
        {      
        }
        public ParteVentaDiario(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {   
            this.id.setValue(sqlReader);
            this.fecha.setValue(sqlReader);
            this.moneda.setValue(sqlReader);            
            this.formaPago.setValue(sqlReader);           
            this.saldo.setValue(sqlReader);
            this.idConsiliacion.setValue(sqlReader);          
            this.idTienda.setValue(sqlReader);          
            this.comision.setValue(sqlReader);
        }
        public void setId()
        {
            //25:6:2023-01-01
            this.id.Value = idTienda.Value + ":" + formaPago.getId() + ":" + fecha.getAsString();
        }      
        protected new void setTabla()
        {
            tabla = new Tabla("parte_venta_diario", "pvd");
        }
        public void setComision()
        {
            decimal valor = formaPago.Objeto.grupoConciliacion.Objeto.comision.MoneyAccount / 100 * saldo.MoneyAccount;
            comision.setMoney(valor);
            valor = saldo.MoneyAccount - valor;
            saldo.setMoney(valor);
        }
    }
}
