using Database;
using Database.Class;
using LocalData.Atributo;
using ModelData.Atributo;
using ModelData.Report.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Model
{
    public class Tienda : BaseModelPro<Tienda, int>, ISincronizable<Tienda, int>
    {
        public ParteDiarioAcumuladosVentasResumidasTienda reporteParteDiarioAcumuladosVentasResumidasMesActual { get; set; }       
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");        
        public Atributo_Moneda moneda { get; set; } = new Atributo_Moneda("id_moneda");
        public Atributo<bool> isAbierta { get; set; } = new Atributo<bool>("is_abierta");    
        public Atributo_PK<int> idComplejo { get; set; } = new Atributo_PK<int>("id_complejo");
        public Atributo_Email email { get; set; } = new Atributo_Email("email");
        public Atributo<int> ordenComercial { get; set; } = new Atributo<int>("orden_comercial");
        public Atributo<int> cantidadMaximaTrabajadores { get; set; } = new Atributo<int>("cantidad_maxima_trabajadores");
        public Atributo<int> cantidadRealTrabajadores { get; set; } = new Atributo<int>("cantidad_real_depentientes");
        public Atributo<int> cantidadJefeBrigada { get; set; } = new Atributo<int>("cantidad_real_jefes_brigadas");
        public Atributo_Horario_Servicio horarioServicio { get; set; } = new Atributo_Horario_Servicio("id_horario_servicio");
        public Atributo_Grupo_Tienda grupoTienda { get; set; } = new Atributo_Grupo_Tienda("id_grupo_tienda");
        public List <FormaPago> formasPagosUtiliza { get; set; }
        public List<PlanVentaMensual> planesVentas { get; set; }
        public List<ParteVentaDiario> partesVentas { get; set; }
        public Atributo_Money planAcumuladoMesesAnteriores
        {
            get
            {                
                return getPlanAcumuladoMesAnteriores(VariablesEntorno.mesAbierto.Value);
            }
            set { }
        }
        public Atributo_Money ventasAcumuladasResumidasMesAnteriores
        {
            get
            {                
                return getVentasResumidasAcumuladoMesesAnteriores(VariablesEntorno.mesAbierto.Value);
            }
            set { }
        }
        public Atributo_Money planVentaAnno
        {
            get
            {
                decimal saldo = planesVentas.Sum(p => p.saldo.MoneyAccount);
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Money planDiarioPromedio
        {
            get
            {
                decimal saldo = planVentaAnno.MoneyAccount / VariablesEntorno.annoAbierto.CantidadDias;
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Money planVentaMesActual
        {
            get
            {
                return getPlanVentaMes(VariablesEntorno.mesAbierto.Value);
            }
            set { }
        }
        public Atributo_Money planDiarioMesActual
        {
            get
            {
                return getPlanVentaDia(VariablesEntorno.mesAbierto.Value);
            }
            set { }
        }
        public Atributo_Porciento porcientoVentasResumidasVivoMesActual
        {
            get
            {
                return AtributoFactory.builPorciento(this.ventasRealesResumidasMesActual.getPorcientoDe(planVentaMesActual));
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
                List<ParteVentaDiario> partesVentaMes = partesVentas.FindAll(p => p.fecha.Fecha.Month == VariablesEntorno.mesAbierto.Value && p.formaPago.Objeto.getIsResumen() == false);
                decimal saldo = partesVentaMes.Sum(p => p.saldo.MoneyAccount);
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
        public Atributo_Money ventasRealesResumidasAnnoActual
        {
            get
            {
                decimal saldoMesesAnteriores = planesVentas.Sum(p => p.realResumido.MoneyAccount);
                decimal saldo = ventasRealesResumidasMesActual.MoneyAccount + saldoMesesAnteriores;
                return AtributoFactory.buildMoney(saldo);
            }
            set { }
        }
        public Atributo_Money ventasRealesDetalladasAnnoActual
        {
            get
            {
                decimal saldoMesesAnteriores = planesVentas.Sum(p => p.realDetallado.MoneyAccount);
                decimal saldo = ventasRealesDetalladasMesActual.MoneyAccount + saldoMesesAnteriores;
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
        public Tienda()
        {
            setTabla();
        }
        public Tienda(string tokenId) : base(tokenId)
        {          
            idComplejo.Value = 0;
            isAbierta.Value = true;  
            cantidadJefeBrigada.Value = 1;
            planesVentas = new List<PlanVentaMensual>();
            formasPagosUtiliza = new List<FormaPago>();
            partesVentas = new List<ParteVentaDiario>();            
        }
        public Tienda(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos): base(sqlReader, tipoBaseDatos)
        {           
            this.id.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.moneda.setValue(sqlReader);           
            this.isAbierta.setValue(sqlReader);
            this.idComplejo.setValue(sqlReader);
            this.email.setValue(sqlReader);
            this.ordenComercial.setValue(sqlReader);
            this.formasPagosUtiliza = FormaPagoData.getByMoneda(moneda.Objeto);
            this.cantidadMaximaTrabajadores.setValue(sqlReader);
            this.cantidadRealTrabajadores.setValue(sqlReader);
            this.cantidadJefeBrigada.setValue(sqlReader);
            this.horarioServicio.setValue(sqlReader);
            this.grupoTienda.setValue(sqlReader);
            updatePlanesVentas();
            updatePartesVentas();
        }
        public void updatePlanesVentas()
        {
            this.planesVentas = RepositoryFactory.PlanVentaMensual_Local().getByTienda(this.id.getValueAsInt());
        }
        public void updatePartesVentas()
        {
            this.partesVentas = RepositoryFactory.ParteVentaDiario_Local().getByTienda(this.id.getValueAsInt());
        }

        public Atributo_Money getPlanVentaDia(int mes)
        {
            decimal saldo = planesVentas.Find(p => p.fecha.Mes.Value == mes).planDiario.MoneyAccount;
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanVentaMes(int mes)
        {
            decimal saldo = planesVentas.Find(p => p.fecha.Mes.Value == mes).saldo.MoneyAccount;
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
            List<ParteVentaDiario> partesVentaMes = partesVentas.FindAll(p => p.fecha.Fecha.Month == mes && p.fecha.Fecha.Day == dia && p.formaPago.Objeto.getIsResumen() == isResumen);
            decimal saldo = partesVentaMes.Sum(p => p.comision.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getGananciaNetaVentasDia(int mes, int dia, bool isResumen = false)
        {
            List<ParteVentaDiario> partesVentaMes = partesVentas.FindAll(p => p.fecha.Fecha.Month == mes && p.fecha.Fecha.Day == dia && p.formaPago.Objeto.getIsResumen() == isResumen);
            decimal saldo = partesVentaMes.Sum(p => p.saldo.MoneyAccount);           
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanAcumuladoMesAnteriores(int mes)
        {
            decimal saldo = planesVentas
                    .Where(p => p.fecha.Mes.Value < mes)
                    .Sum(p => p.saldo.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanAcumuladoMes(int mes, int dia)
        {
            decimal saldo = planesVentas.Find(p => p.fecha.Mes.Value == mes).planDiario.MoneyAccount * dia;
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanAcumuladoAnno(int mes, int dia)
        {
            decimal saldo = planesVentas
                    .Where(p => p.fecha.Mes.Value < mes)
                    .Sum(p => p.saldo.MoneyAccount);
            saldo += getPlanAcumuladoMes(mes, dia).MoneyAccount;
            return AtributoFactory.buildMoney(saldo);
        }      
        public Atributo_Money getVentasRealesResumidasMes(int mes)
        {
            List<ParteVentaDiario> partesVentaMes = partesVentas.FindAll(p => p.fecha.Fecha.Month == mes && p.formaPago.Objeto.getIsResumen() == true);
            decimal saldo = partesVentaMes.Sum(p => p.saldo.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasResumidasAcumuladoMesesAnteriores(int mes)
        {
            decimal saldo = planesVentas
                    .Where(p => p.fecha.Mes.Value < mes)
                    .Sum(p => p.realResumido.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasResumidasAcumuladoAnnoHastaElDia(int mes, int dia)
        {
            decimal saldo = getVentasResumidasAcumuladoMesesAnteriores(mes).MoneyAccount;
            saldo += partesVentas
                    .Where(p => p.fecha.Fecha.Day <= dia && p.formaPago.Objeto.getIsResumen() == true)
                    .Sum(p => p.saldo.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }        
        public Atributo_Money getVentasResumidasAcumuladoMesHastaElDia(int mes, int dia)
        {
            decimal saldo = partesVentas
                    .Where(p => p.fecha.Fecha.Day <= dia && p.formaPago.Objeto.getIsResumen() == true)
                    .Sum(p => p.saldo.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Porciento getPorcientoVentasResumidasAcumuladasAnno(int mes, int dia)
        {
            Atributo_Money plan = getPlanAcumuladoAnno(mes, dia);
            Atributo_Money venta = getVentasResumidasAcumuladoAnnoHastaElDia(mes, dia);
            return AtributoFactory.builPorciento(venta.getPorcientoDe(plan));
        }
        public Atributo_Money getPlanVentasMes(int mes)
        {
            return planesVentas.Find(p => p.fecha.Mes.Value == mes).saldo;
        }
        public List<ParteVentaDiario> getPartesVentasRealesDia(int mes, int dia, bool isResumen = false)
        {
            return partesVentas.FindAll(p => p.fecha.Fecha.Month == mes && p.fecha.Fecha.Day == dia && p.formaPago.Objeto.getIsResumen() == isResumen);            
        }
        public Atributo_Datetime getFechaUltimoParteVenta(bool isResumen = false)
        {
            List<ParteVentaDiario> partesVentasFilter = partesVentas.FindAll(p => p.formaPago.Objeto.getIsResumen() == isResumen);
            if (partesVentasFilter.Count > 0) {
                DateTime fecha = partesVentasFilter.Max(p => p.fecha.Fecha);
                return AtributoFactory.builDateTime(fecha);
            } 
            Atributo_Datetime fechaMinima= AtributoFactory.builDateTime(VariablesEntorno.primeraFechaValida);
            fechaMinima.setSumarDias(-1);
            return fechaMinima;
        }
        public bool validar()
        {
            if (denominacion.Value == "") return false;
            if (moneda.Objeto == null) return false;
            if (idComplejo.Value == 0) return false;
            if (!email.isValido()) return false;
            return true;
        }
        public override string ToString()
        {
            return denominacion.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("tienda", "t");
        }
        public void setReporteParteDiarioAcumuladosVentasResumidasMesActual(Complejo complejo, Atributo_Mes mes)
        {
            reporteParteDiarioAcumuladosVentasResumidasMesActual = new ParteDiarioAcumuladosVentasResumidasTienda(complejo, this, mes);
        }     
        public bool isMonedaCUP()
        {
            return (moneda.Objeto.denominacion.Value == MonedaData.CUP);
        }

    }
}
