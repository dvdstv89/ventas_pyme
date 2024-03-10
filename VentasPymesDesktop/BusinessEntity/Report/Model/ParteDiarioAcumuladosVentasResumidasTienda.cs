using ModelData.Model;
using System.Collections.Generic;
using ModelData.Atributo;
using ModelData.Report.Model;
using System.Windows.Forms;
using Database.Class;
using Atributo_Money = ModelData.Atributo.Atributo_Money;
using System;
using System.Linq;
using LocalData.Model;

namespace ModelData.Report.Model
{
    public class ParteDiarioAcumuladosVentasResumidasTienda
    {
        public Tienda tienda { get; set; }
        public string ubicacion { get; set; }
        public Atributo_Mes mes { get; set; }
        public int anno { get; set; }
        public Atributo_Money planMes { get; set; }
        public Atributo_Money planDiario { get; set; }
        public Atributo_Money planAcumulado { get; set; }
        public Atributo_Money realAcumulado { get; set; }
        DateTime? fecha = null;
        public List<ListViewItem> listViewItemVentasResumidasPorDia { get; set; }
        public List<VentaResumidaTiendaDia> ventaResumidaDias { get; set; }
        public ListViewItem itemTotal { get; set; }
        public ParteDiarioAcumuladosVentasResumidasTienda(Complejo complejo, Tienda tienda, Atributo_Mes mes)
        {
            this.tienda = tienda;
            this.mes = mes;
            this.anno = VariablesEntorno.annoAbierto.Value;
            this.ubicacion = tienda.denominacion.Value +" - "+complejo.denominacion.Value;
            inicializarFecha(complejo, tienda.grupoTienda.Objeto);
            calcularEncabezado();
            calcularVentaResumidaDias();
            calcularListViewItem();
            calcularListViewItemTotal();
        }
        private void inicializarFecha(Complejo complejo, GrupoTienda grupoTienda)
        {
            Moneda monedaDeLaTienda = MonedaData.getMoneda(tienda.moneda.Objeto, grupoTienda.isOnline.Value);
            fecha = complejo.getFechaUltimoParteVenta(monedaDeLaTienda, true).Fecha;
            fecha = (fecha < VariablesEntorno.primeraFechaValida) ? null : fecha;
            if (fecha.HasValue && fecha.Value.Month > VariablesEntorno.mesAbierto.Value)
                fecha = VariablesEntorno.ultimaFechaValida;
        }
        private void calcularEncabezado()
        {
            planMes = tienda.getPlanVentaMes(mes.Value);
            planDiario = tienda.getPlanVentaDia(mes.Value);
            planAcumulado = tienda.getPlanAcumuladoMesAnteriores(mes.Value);
            realAcumulado = tienda.getVentasResumidasAcumuladoMesesAnteriores(mes.Value);
        }
        private void calcularVentaResumidaDias()
        {
            ventaResumidaDias = new List<VentaResumidaTiendaDia>();
            for (int i = 1; i <= mes.countDays(anno); i++)
            {
                ventaResumidaDias.Add(new VentaResumidaTiendaDia(tienda,mes, i,planDiario,planAcumulado,realAcumulado));
                ventaResumidaDias[i - 1].isVentaRealizada = diaSeleccionable(i);
            }

        }
        private void calcularListViewItem()
        {
            listViewItemVentasResumidasPorDia = new List<ListViewItem>();
            for (int i = 1; i <=  mes.countDays(anno); i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(ventaResumidaDias[i-1].planDiario.getMoneyFormated());
                if (ventaResumidaDias[i - 1].isVentaRealizada)
                {
                    item.SubItems.Add(ventaResumidaDias[i - 1].ventaDia.getMoneyFormated());
                    item.SubItems.Add(ventaResumidaDias[i - 1].porcientoCumplimientoVentasDia.Value);
                    //Mes
                    item.SubItems.Add(ventaResumidaDias[i - 1].planAcumuladoMes.getMoneyFormated());
                    item.SubItems.Add(ventaResumidaDias[i - 1].ventaAcumuladoMes.getMoneyFormated());
                    item.SubItems.Add(ventaResumidaDias[i - 1].porcientoAcumuladasMes.Value);
                    //anno
                    item.SubItems.Add(ventaResumidaDias[i - 1].planAcumuladoAnno.getMoneyFormated());
                    item.SubItems.Add(ventaResumidaDias[i - 1].ventaAcumuladoAnno.getMoneyFormated());
                    item.SubItems.Add(ventaResumidaDias[i - 1].porcientoAcumuladoAnno.Value);
                }
                else
                {
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(ventaResumidaDias[i - 1].planAcumuladoMes.getMoneyFormated());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(ventaResumidaDias[i - 1].planAcumuladoAnno.getMoneyFormated());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                }
                listViewItemVentasResumidasPorDia.Add(item);
            }
        }
        private void calcularListViewItemTotal()
        {
            itemTotal = new ListViewItem("Total");
            itemTotal.SubItems.Add("");
            itemTotal.SubItems.Add("");
            itemTotal.SubItems.Add("");
            itemTotal.SubItems.Add(planMes.getMoneyFormated());
            itemTotal.SubItems.Add(getventaResumidasMes().getMoneyFormated());
            itemTotal.SubItems.Add(porcientoMes().Value);
            itemTotal.SubItems.Add(getPlanAcumuladoAnno().getMoneyFormated());
            itemTotal.SubItems.Add(getVentasAcumuladoAnno().getMoneyFormated());
            itemTotal.SubItems.Add(porcientoAnno().Value);
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
        public Atributo_Porciento porcientoAnno()
        {
            return AtributoFactory.builPorciento(getVentasAcumuladoAnno().getPorcientoDe(getPlanAcumuladoAnno()));
        }
        public bool diaSeleccionable(int dia)
        {
            return (fecha.HasValue && dia <= fecha.Value.Day);
        }
    }
}
