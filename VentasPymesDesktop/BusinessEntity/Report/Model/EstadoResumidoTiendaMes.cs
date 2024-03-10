using Database.Class;
using ModelData.Atributo;
using ModelData.Model;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Report.Model
{
    public class EstadoResumidoTiendaMes
    {
        public Atributo_Mes mes { get; set; }       
        public Atributo_Money planDiario { get; set; }
        public Atributo_Money planMes { get; set; }
        public Atributo_Money ventasMes { get; set; }
        public Atributo_Porciento porcientoVentasVivo { get; set; }
        public Atributo_Porciento porcientoMes { get; set; }
        public Atributo_Money faltaMes { get; set; }
        public Atributo_Money planAnno { get; set; }
        public Atributo_Money ventaAnno { get; set; }
        public Atributo_Porciento porcientoAnno { get; set; }
        public Tienda tienda { get; set; }     
        public EstadoResumidoTiendaMes(Tienda tienda, Atributo_Mes mes)
        {
            this.tienda = tienda;
            this.mes= mes;           
            this.planDiario = tienda.getPlanVentaDia(mes.Value);
            this.planMes = tienda.getPlanVentaMes(mes.Value);
            this.ventasMes = tienda.getVentasRealesResumidasMes(mes.Value);
            this.porcientoVentasVivo = AtributoFactory.builPorciento(this.ventasMes.getPorcientoDe(getPlanAcumuladoMes()));
            this.porcientoMes = AtributoFactory.builPorciento(this.ventasMes.getPorcientoDe(this.planMes));
            this.faltaMes = this.planMes.getDiferencia(ventasMes);
            this.planAnno = tienda.planVentaAnno;
            this.ventaAnno = tienda.ventasRealesResumidasAnnoActual;
            this.porcientoAnno = AtributoFactory.builPorciento(ventaAnno.getPorcientoDe(planAnno));
        }
        Atributo_Money getPlanAcumuladoMes()
        {
            Atributo_Datetime fecha = tienda.getFechaUltimoParteVenta(true);            
            decimal saldo = (mes.Value == fecha.Fecha.Month)?planDiario.MoneyAccount * fecha.Fecha.Day: fecha.Mes.countDays();
            return AtributoFactory.buildMoney(saldo);
        }      
    }
}
