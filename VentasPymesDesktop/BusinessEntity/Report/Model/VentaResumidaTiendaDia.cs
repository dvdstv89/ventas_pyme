using Database.Class;
using ModelData.Atributo;
using ModelData.Model;
using System.CodeDom;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Report.Model
{
    public class VentaResumidaTiendaDia
    {
        public Atributo_Mes mes { get; set; }
        public bool isVentaRealizada { get; set; }
        public int dia { get; set; }       
        public Atributo_Money planDiario { get; set; }
        public Atributo_Money ventaDia { get; set; }
        public Atributo_Porciento porcientoCumplimientoVentasDia { get; set; }
        public Atributo_Money planAcumuladoMes { get; set; }
        public Atributo_Money ventaAcumuladoMes{ get; set; }
        public Atributo_Porciento porcientoAcumuladasMes { get; set; }       
        public Atributo_Money planAcumuladoAnno { get; set; }
        public Atributo_Money ventaAcumuladoAnno { get; set; }
        public Atributo_Porciento porcientoAcumuladoAnno { get; set; }
        public Tienda tienda { get; set; }      
        Atributo_Money planAcumulado { get; set; }
        Atributo_Money realAcumulado { get; set; }
        public VentaResumidaTiendaDia(Tienda tienda, Atributo_Mes mes, int dia, Atributo_Money planDiario, Atributo_Money planAcumulado, Atributo_Money realAcumulado)
        {
            this.tienda = tienda;
            this.mes= mes; 
            this.planAcumulado = planAcumulado;
            this.realAcumulado = realAcumulado;
            this.dia = dia;
            this.planDiario = planDiario;
            isVentaRealizada = true;
            ventaDia = tienda.getVentaTotalDia(mes.Value, dia, true);
            porcientoCumplimientoVentasDia = AtributoFactory.builPorciento(ventaDia.getPorcientoDe(planDiario));
            planAcumuladoMes = getPlanAcumuladoMes();
            ventaAcumuladoMes = tienda.getVentasResumidasAcumuladoMesHastaElDia(mes.Value, dia);
            porcientoAcumuladasMes = AtributoFactory.builPorciento(ventaAcumuladoMes.getPorcientoDe(planAcumuladoMes));
            planAcumuladoAnno = getPlanAcumuladoAnno();
            ventaAcumuladoAnno = getVentaAcumuladoAnno();
            porcientoAcumuladoAnno = AtributoFactory.builPorciento(ventaAcumuladoAnno.getPorcientoDe(planAcumuladoAnno));
        }
        Atributo_Money getPlanAcumuladoMes()
        {
            decimal saldo = planDiario.MoneyAccount * dia;
            return AtributoFactory.buildMoney(saldo);
        }
        Atributo_Money getPlanAcumuladoAnno()
        {
            decimal saldo = planAcumulado.MoneyAccount + (planDiario.MoneyAccount * dia);
            return AtributoFactory.buildMoney(saldo);
        }
        Atributo_Money getVentaAcumuladoAnno()
        {
            decimal saldo = ventaAcumuladoMes.MoneyAccount + realAcumulado.MoneyAccount;
            return AtributoFactory.buildMoney(saldo);
        }
    }
}
