using Database;
using Database.Class;
using ModelData.Atributo;
using ModelData.Report;
using ModelData.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LocalData.Model;
using Atributo_Money = ModelData.Atributo.Atributo_Money;
using LocalData.Atributo;
using ModelData.DTO;

namespace ModelData.Model
{    
    public class Complejo: BaseModelPro<Complejo,int>, ISincronizable<Complejo,int>
    {
        public ParteDiarioAcumuladosVentasResumidasComplejo reporteParteDiarioAcumuladosVentasResumidasMesActual { get; set; }       
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo_PK<int> idEmpresa { get; set; } = new Atributo_PK<int>("id_empresa");
        public Atributo_Email email { get; set; } = new Atributo_Email("email");
        public Atributo_Tipo_Departamento tipoDepartamento { get; set; } = new Atributo_Tipo_Departamento("id_tipo_departamento");
        public List<PlanVentaMensual> planesVentas { get; set; }
        public List<PlanServicioMensual> planesElectricidad { get; set; }
        public List<PlanServicioMensual> planesAgua { get; set; }
        public List<Tienda> tiendas { get; set; }
        public Atributo_Money planVentaDiariasMesActual
        {
            get
            {
                return getPlanVentasDiarias(VariablesEntorno.mesAbierto.Value);
            }
            set { }
        }
        public Atributo_Money planVentaAnno
        {
            get
            {
                decimal saldo = tiendas.Sum(p => p.planVentaAnno.MoneyAccount);
                return new Atributo_Money(saldo);
            }
            set { }
        }
        public Atributo_Money planVentaMesActual
        {
            get
            {
                decimal saldo = tiendas.Sum(p => p.planVentaMesActual.MoneyAccount);
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Porciento porcientoVentaDetalladasMesActual
        {
            get
            {            
                return AtributoFactory.builPorciento(ventasRealesDetalladasMesActual.getPorcientoDe(planVentaMesActual));
            }
            set { }
        }
        public Atributo_Porciento porcientoVentaResumidaMesActual
        {
            get
            {               
                return AtributoFactory.builPorciento(ventasRealesResumidasMesActual.getPorcientoDe(planVentaMesActual));
            }
            set { }
        }
        public Atributo_Porciento porcientoVentaDetalladasAnnoActual
        {
            get
            {             
                return AtributoFactory.builPorciento(ventasRealesDetalladasAnnoActual.getPorcientoDe(planVentaAnno));
            }
            set { }
        }
        public Atributo_Porciento porcientoVentaResumidaAnnoActual
        {
            get
            {               
                return AtributoFactory.builPorciento(ventasRealesResumidasAnnoActual.getPorcientoDe(planVentaAnno));
            }
            set { }
        }
        public Atributo_Money ventasRealesDetalladasMesActual
        {
            get
            {
                decimal saldo = tiendas.Sum(p => p.ventasRealesDetalladasMesActual.MoneyAccount);
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Money ventasRealesResumidasMesActual
        {
            get
            {               
                return getVentasRealesResumidasMes(VariablesEntorno.mesAbierto.Value);
            }
            set { }
        }
        public Atributo_Money getPlanAcumuladoMes(int mes, int dia)
        {
            decimal saldo = getPlanVentasDiarias(mes).MoneyAccount * dia;
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money ventasRealesResumidasAnnoActual
        {
            get
            {
                decimal saldo = tiendas.Sum(p => p.ventasRealesResumidasAnnoActual.MoneyAccount);   
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Money ventasRealesDetalladasAnnoActual
        {
            get
            {
                decimal saldo = tiendas.Sum(p => p.ventasRealesDetalladasAnnoActual.MoneyAccount);
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Money ventasRealesResumidasRestantesMesActual
        {
            get
            {
                decimal saldo = planVentaMesActual.MoneyAccount - ventasRealesResumidasMesActual.MoneyAccount;
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Complejo()
        {
            setTabla();
        }
        public Complejo(string tokenId) : base(tokenId)
        {
            tiendas = new List<Tienda>();
            idEmpresa.Value = VariablesEntorno.idEmpresaPorDefecto;            
            planesVentas = new List<PlanVentaMensual>();
            planesAgua = new List<PlanServicioMensual>();
            planesElectricidad = new List<PlanServicioMensual>();

        }
        public Complejo(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.idEmpresa.setValue(sqlReader); 
            this.tipoDepartamento.setValue(sqlReader);
            tiendas = new List<Tienda>();
            this.email.setValue(sqlReader);
            updatePlanesVentas();
        }
        public void updatePlanesVentas()
        {
            this.planesVentas = RepositoryFactory.PlanVentaMensual_Local().getByComplejo(id.Value);
            this.planesAgua = RepositoryFactory.PlanServicioMensual_Local().getByComplejo(id.Value, TipoServicioData.Agua.getPK().Value);
            this.planesElectricidad = RepositoryFactory.PlanServicioMensual_Local().getByComplejo(id.Value, TipoServicioData.Electricidad.getPK().Value);
        }
        public void updatePartesVentas()
        {
           
        }
        public Atributo_Money getVentasRealesResumidasMes(int mes)
        {
            decimal saldo = tiendas.Sum(p => p.getVentasRealesResumidasMes(mes).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanVentasMes(int mes)
        {
            decimal saldo = tiendas.Sum(p => p.getPlanVentasMes(mes).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanVentasDiarias(int mes)
        {
            decimal saldo = tiendas.Sum(p => p.getPlanVentaDia(mes).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanAcumuladoMesAnteriores(int mes)
        {
            decimal saldo = tiendas.Sum(t => t.getPlanAcumuladoMesAnteriores(mes).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasResumidasAcumuladoMesesAnteriores(int mes)
        {
            decimal saldo = tiendas.Sum(t => t.getVentasResumidasAcumuladoMesesAnteriores(mes).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentaTotalDia(int mes, int dia, bool isResumen = false)
        {
            decimal saldo = getGananciaNetaVentasDia(mes, dia, isResumen).MoneyAccount;
            decimal comision = getComisionVentasTotalesDia(mes, dia, isResumen).MoneyAccount;
            return AtributoFactory.buildMoney(saldo + comision);
        }
        public Atributo_Money getComisionVentasTotalesDia(int mes, int dia, bool isResumen = false)
        {            
            decimal saldo = tiendas.Sum(t => t.getComisionVentasTotalesDia(mes,dia,isResumen).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getGananciaNetaVentasDia(int mes, int dia, bool isResumen = false)
        {
            decimal saldo = tiendas.Sum(t => t.getGananciaNetaVentasDia(mes, dia, isResumen).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasResumidasAcumuladoMesHastaElDia(int mes, int dia)
        {
            decimal saldo = tiendas.Sum(t => t.getVentasResumidasAcumuladoMesHastaElDia(mes, dia).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }        
        public Atributo_Porciento getPorcientoVentasResumidasParcialMesActual(int dia)
        {  
            Atributo_Money planParcial = AtributoFactory.buildMoney(planVentaDiariasMesActual.MoneyAccount * dia);
            return AtributoFactory.builPorciento(ventasRealesResumidasMesActual.getPorcientoDe(planParcial));
        }
        public override string ToString()
        {
            return denominacion.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("complejo", "com");
        }
        public void setReporteParteDiarioAcumuladosVentasResumidasMesActual(Atributo_Mes mes)
        {
            reporteParteDiarioAcumuladosVentasResumidasMesActual = new ParteDiarioAcumuladosVentasResumidasComplejo( this, mes);
        }
        public int getDiaUltimaFechaVentaComplejo(bool isResumen = false)
        {
            int diasTrancurridosMayorVenta = 0;
            foreach (Tienda tienda in tiendas)
            {
                int diasTrancurridos = getFechaUltimoParteVenta(tienda.moneda.Objeto, isResumen).Fecha.Day;
                if (tienda.ventasRealesResumidasMesActual.MoneyAccount > 0)
                {
                    diasTrancurridosMayorVenta = (diasTrancurridos > diasTrancurridosMayorVenta) ? diasTrancurridos : diasTrancurridosMayorVenta;
                }
            }
            return diasTrancurridosMayorVenta;
        }
        public Atributo_Datetime getFechaUltimoParteVenta(Moneda moneda, bool isResumen = false)
        {
            List<Tienda> tiendasConMoneda = tiendas.FindAll(t => t.moneda.Objeto.getId() == moneda.getId());
            DateTime fecha = tiendasConMoneda.Max(t => t.getFechaUltimoParteVenta(isResumen).Fecha);
            return AtributoFactory.builDateTime(fecha);
        }
    }    
}
