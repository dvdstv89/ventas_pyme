using ModelData.Model;
using System.Collections.Generic;
using ModelData.Atributo;
using ModelData.Report.Model;
using System.Windows.Forms;
using Database.Class;
using Atributo_Money = ModelData.Atributo.Atributo_Money;
using System.Linq;
using System.Numerics;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace ModelData.DTO
{
    public class ParteDiarioAcumuladosVentasResumidasComplejo
    {
        public Complejo complejo { get; set; }        
        public Atributo_Mes mes { get; set; }
        public int anno { get; set; }
        public Atributo_Money planMes { get; set; }
        public Atributo_Money planDiario { get; set; }
        public Atributo_Money planAcumulado { get; set; }
        public Atributo_Money realAcumulado { get; set; }      
        public List<ListViewItem> listViewItemVentasResumidasPorDia { get; set; }
        public List<VentaResumidaComplejoDia> ventaResumidaDias { get; set; }
        public List<EstadoResumidoTiendaMes> estadoTiendaMes { get; set; }
        public ListViewItem itemTotal { get; set; }
        public ParteDiarioAcumuladosVentasResumidasComplejo(Complejo complejo, Atributo_Mes mes)
        {
            this.complejo = complejo;
            this.mes = mes;
            this.anno = VariablesEntorno.annoAbierto.Value; 
            calcularEncabezado();
            calcularVentaResumidaDias();
            calcularEstadoTiendaMes();
            calcularListViewItem();
            calcularListViewItemTotal();
        }      
        private void calcularEncabezado()
        {
            planMes = complejo.getPlanVentasMes(mes.Value);
            planDiario = complejo.getPlanVentasDiarias(mes.Value);
            planAcumulado = complejo.getPlanAcumuladoMesAnteriores(mes.Value);
            realAcumulado = complejo.getVentasResumidasAcumuladoMesesAnteriores(mes.Value);
        }
        private void calcularVentaResumidaDias()
        {
            ventaResumidaDias = new List<VentaResumidaComplejoDia>();           
            for (int i = 1; i <= mes.countDays(anno); i++)
            {
                ventaResumidaDias.Add(new VentaResumidaComplejoDia(complejo, mes, i, planDiario, planAcumulado, realAcumulado));               
            }           
        }
        private void calcularEstadoTiendaMes()
        {          
            estadoTiendaMes = new List<EstadoResumidoTiendaMes>();          
            for (int i = 0; i < complejo.tiendas.Count; i++)
            {
                estadoTiendaMes.Add(new EstadoResumidoTiendaMes(complejo.tiendas[i], mes));
            }
        }
        private void calcularListViewItem()
        {
            listViewItemVentasResumidasPorDia = new List<ListViewItem>();
            foreach (EstadoResumidoTiendaMes tienda in estadoTiendaMes)
            {               
                ListViewItem item = new ListViewItem(tienda.tienda.denominacion.Value + " ("+ tienda.tienda.moneda.Objeto.denominacion+")");
                item.SubItems.Add(tienda.planDiario.getMoneyFormated());
                item.SubItems.Add(tienda.planMes.getMoneyFormated());
                item.SubItems.Add(tienda.ventasMes.getMoneyFormated());
                item.SubItems.Add(tienda.porcientoVentasVivo.Value);
                item.SubItems.Add(tienda.porcientoMes.Value);
                item.SubItems.Add(tienda.faltaMes.getMoneyFormated());
                item.SubItems.Add(tienda.planAnno.getMoneyFormated());
                item.SubItems.Add(tienda.ventaAnno.getMoneyFormated());
                item.SubItems.Add(tienda.porcientoAnno.Value);
                listViewItemVentasResumidasPorDia.Add(item);
            }            
        }
        private void calcularListViewItemTotal()
        {
            itemTotal = new ListViewItem(complejo.denominacion.Value);
            itemTotal.SubItems.Add(planDiario.getMoneyFormated());
            itemTotal.SubItems.Add(planMes.getMoneyFormated());
            itemTotal.SubItems.Add(getventaResumidasMes().getMoneyFormated());
            itemTotal.SubItems.Add(porcientoVivoMes().Value);
            itemTotal.SubItems.Add(porcientoMes().Value);
            itemTotal.SubItems.Add(getFaltaMes().getMoneyFormated());
            itemTotal.SubItems.Add(complejo.planVentaAnno.getMoneyFormated());
            itemTotal.SubItems.Add(complejo.ventasRealesResumidasAnnoActual.getMoneyFormated());
            itemTotal.SubItems.Add(complejo.porcientoVentaResumidaAnnoActual.Value);
        }
        public ListViewItem getListViewItemTotal()
        {
            ListViewItem item = new ListViewItem();
            item = new ListViewItem(complejo.denominacion.Value);
            item.SubItems.Add(planDiario.getMoneyFormated());
            item.SubItems.Add(planMes.getMoneyFormated());
            item.SubItems.Add(getventaResumidasMes().getMoneyFormated());
            item.SubItems.Add(porcientoVivoMes().Value);
            item.SubItems.Add(porcientoMes().Value);
            item.SubItems.Add(getFaltaMes().getMoneyFormated());
            item.SubItems.Add(complejo.planVentaAnno.getMoneyFormated());
            item.SubItems.Add(complejo.ventasRealesResumidasAnnoActual.getMoneyFormated());
            item.SubItems.Add(complejo.porcientoVentaResumidaAnnoActual.Value);
            return item;
        }
        public Atributo_Money getventaResumidasMes()
        {
            decimal saldo = ventaResumidaDias.Sum(p => p.ventaDia.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanAcumuladoAnno()
        {
            decimal saldo = planMes.MoneyAccount + planAcumulado.MoneyAccount;
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasAcumuladoAnno()
        {
            decimal saldo = getventaResumidasMes().MoneyAccount + realAcumulado.MoneyAccount;
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Porciento porcientoMes()
        {
            return AtributoFactory.builPorciento(getventaResumidasMes().getPorcientoDe(planMes));
        }
        public Atributo_Porciento porcientoVivoMes()
        {               
            return AtributoFactory.builPorciento(getventaResumidasMes().getPorcientoDe(complejo.getPlanAcumuladoMes(mes.Value, complejo.getDiaUltimaFechaVentaComplejo(true))));
        }    
        public Atributo_Porciento porcientoAnno()
        {
            return AtributoFactory.builPorciento(getVentasAcumuladoAnno().getPorcientoDe(getPlanAcumuladoAnno()));
        }
        public Atributo_Money getFaltaMes()
        {
            decimal saldo = estadoTiendaMes.Sum(e=>e.faltaMes.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
    }
}
