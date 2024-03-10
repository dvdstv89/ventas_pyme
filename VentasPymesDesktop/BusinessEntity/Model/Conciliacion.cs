using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Database;
using Database.Class;
using ModelData.Atributo;
using ModelData.Repository;
using ModelData.Service.LocalDatabaseClient;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Model
{    
    public class Conciliacion : BaseModelPro<Conciliacion, string>, ISincronizable<Conciliacion, string>
    {  
        public Atributo<string> documento { get; set; } = new Atributo<string>("documento");
        public Atributo_Complejo complejo { get; set; } = new Atributo_Complejo("id_complejo");
        public Atributo_GrupoConciliacion grupoConciliacion { get; set; } = new Atributo_GrupoConciliacion("id_grupo_conciliacion");
        public Atributo_Datetime fechaInicio { get; set; } = new Atributo_Datetime("fecha_inicio");
        public Atributo_Datetime fechaFin { get; set; } = new Atributo_Datetime("fecha_fin");
        public Atributo_Moneda moneda { get; set; } = new Atributo_Moneda("id_moneda");
        public Atributo_Money saldoVenta { get; set; } = new Atributo_Money("saldo_venta");
        public Atributo_Money saldoComision { get; set; } = new Atributo_Money("saldo_comision");
        public Atributo<bool> existenDiferencias { get; set; } = new Atributo<bool>("exist_diferencias");
        public List<ParteVentaDiario> partesVentas { get; set; } = new List<ParteVentaDiario>();
        public Atributo_Money saldoDeclarado
        {
            get
            {
                decimal saldo = partesVentas.Sum(p => p.saldo.MoneyAccount);
                Atributo_Money planVentaAnnoValue = new Atributo_Money("");
                planVentaAnnoValue.setMoney(saldo);
                return planVentaAnnoValue;
            }
            set { }
        }
        public Atributo_Money comisionDeclarada
        {
            get
            {
                decimal saldo = partesVentas.Sum(p => p.comision.MoneyAccount);
                Atributo_Money planVentaAnnoValue = new Atributo_Money("");
                planVentaAnnoValue.setMoney(saldo);
                return planVentaAnnoValue;
            }
            set { }
        }
        public Atributo_Money diferenciaSaldo
        {
            get
            {
                Atributo_Money saldoComplejo = saldoDeclarado;
                decimal saldoVentaMonedaByDefualt = saldoVenta.getSaldoMonedaByDefault();
                decimal saldo = saldoVentaMonedaByDefualt - saldoComplejo.MoneyAccount;
                Atributo_Money planVentaAnnoValue = new Atributo_Money("");
                planVentaAnnoValue.setMoney(saldo);
                return planVentaAnnoValue;
            }
            set { }
        }
        public Atributo_Money diferenciaComision
        {
            get
            {
                Atributo_Money comisionComplejo = comisionDeclarada;
                decimal comisionVentaMonedaByDefualt = saldoComision.getSaldoMonedaByDefault();
                decimal saldo = comisionVentaMonedaByDefualt - comisionComplejo.MoneyAccount;
                Atributo_Money planVentaAnnoValue = new Atributo_Money("");
                planVentaAnnoValue.setMoney(saldo);
                return planVentaAnnoValue;
            }
            set { }
        }
        public Atributo_Money saldoMasComision
        {
            get
            {
                decimal valor = saldoVenta.MoneyAccount + saldoComision.MoneyAccount;
                return AtributoFactory.buildMoney(valor);
            }
            set { }
        }
        public Conciliacion()
        {
            setTabla();
        }
        public Conciliacion(string tokenId, DateTime fechaInicio =default) : base(tokenId)
        {            
            this.fechaInicio.setFecha(fechaInicio);
            existenDiferencias.Value = false;                
            fechaFin.setFecha(this.fechaInicio.Fecha);
        }
        public Conciliacion(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.documento.setValue(sqlReader);
            this.complejo.setValue(sqlReader);            
            this.grupoConciliacion.setValue(sqlReader);            
            this.fechaInicio.setValue(sqlReader);
            this.fechaFin.setValue(sqlReader);           
            this.moneda.setValue(sqlReader);           
            this.saldoVenta.setValue(sqlReader, moneda);          
            this.saldoComision.setValue(sqlReader, moneda);
            this.existenDiferencias.setValue(sqlReader);
            partesVentas = RepositoryFactory.ParteVentaDiario_Local().getByConciliacion(this);            
        }
        public void setId()
        {
            //1:6:2023-01-01:2023-01-02
            this.id.Value = complejo.getId() + ":" + grupoConciliacion.getId() + ":" + fechaInicio.getAsString() + ":" + fechaFin.getAsString();
        }       
        public bool validar()
        {
            if (saldoVenta.MoneyAccount <= 0) return false;
            if (saldoComision.MoneyAccount <= 0) return false;
            if (documento.Value == string.Empty) return false;
            return true;
        }
        public decimal getSaldoVentaMonedaByDefault(Moneda monedaByDefault)
        {
            decimal multiplicarSaldoX = (moneda.getId() == monedaByDefault.getId() ) ? 1 : monedaByDefault.tazaCambioRespectoDefecto.MoneyAccount;
            return saldoVenta.MoneyAccount * multiplicarSaldoX;
        }
        public decimal getSaldoComisionMonedaByDefault(Moneda monedaByDefault)
        {
            decimal multiplicarSaldoX = (moneda.getId() == monedaByDefault.getId()) ? 1 : monedaByDefault.tazaCambioRespectoDefecto.MoneyAccount;
            return saldoComision.MoneyAccount * multiplicarSaldoX;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("conciliacion", "con");
        }

        public void setExistenDiferencias()
        {
            this.existenDiferencias.Value = (diferenciaSaldo.MoneyAccount != 0 || diferenciaComision.MoneyAccount != 0) ? true : false;
        }
    } 
}
