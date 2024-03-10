using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData;
using ModelData.Report;

namespace NucleoEV.UIController
{
    internal class DetallesParteVentaResumidaMesActualUIController
    {         
        Tienda tienda;       
        Session session;
        DetallesVentasResumidasTiendaUI forma;        
        int diaSeleccionado;
        Complejo complejo;   
        public Boolean modificado { get; set; }
        public DetallesParteVentaResumidaMesActualUIController(Session session, Tienda tienda, Complejo complejo)
        {
            this.session = session;
            this.tienda = tienda;
            forma = new DetallesVentasResumidasTiendaUI();
            this.complejo = complejo;
            modificado = false;
        }       
        public DetallesVentasResumidasTiendaUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.lwParteVenta.SelectedIndexChanged += new EventHandler(lwParteVenta_SelectedIndexChanged);
            forma.btnModificarParte.Click += new EventHandler(btnModificarParte_Click);
            forma.btnExportarExcel.Click += new EventHandler(btnExportarExcel_Click);
            return forma;
        }
        void forma_Load(object sender, EventArgs e)
        {   
            aplicarTema();
            restablecerFormulario();
            forma.tbTienda.Text = tienda.denominacion.Value;
            forma.tbMes.Text = VariablesEntorno.mesAbierto.Mes;
            forma.tbPlanMes.Text = tienda.planVentaMesActual.getMoneyFormated();
            forma.tbPlanDiario.Text = tienda.planDiarioMesActual.getMoneyFormated();
            forma.tbPlanAcumulado.Text = tienda.planAcumuladoMesesAnteriores.getMoneyFormated();
            forma.tbRealAcumulado.Text = tienda.ventasAcumuladasResumidasMesAnteriores.getMoneyFormated();
        }        
        protected void aplicarTema()
        {
            forma.Text = "Detalles de la ventas resumidas de la tienda "+ tienda.denominacion.Value; 
            forma.BackColor = session.temaAplication.subFormularioBgColor();
            session.temaAplication.inicializarSubListView(ref forma.lwParteVenta);
            session.temaAplication.inicializarToolStripButton(ref forma.btnModificarParte, TipoToolStripButton.ModificarParteVenta, true);
        }       
        void restablecerFormulario()
        {           
            diaSeleccionado = 0;          
            forma.btnModificarParte.Enabled = false;
            tienda.setReporteParteDiarioAcumuladosVentasResumidasMesActual(complejo, VariablesEntorno.mesAbierto);
            llenarPartesVentas();
        }
        private void lwParteVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            diaSeleccionado = 0;
            forma.btnModificarParte.Enabled = false;
            if (forma.lwParteVenta.SelectedIndices.Count > 0)
            {
                diaSeleccionado = forma.lwParteVenta.SelectedIndices[0] + 1;             
                if (tienda.reporteParteDiarioAcumuladosVentasResumidasMesActual.diaSeleccionable(diaSeleccionado))
                {
                    DateTime fechaSeleccionada = session.makeDate(diaSeleccionado);
                    forma.btnModificarParte.Enabled = (fechaSeleccionada <= VariablesEntorno.ultimaFechaValida) ? true : false;
                }
            }            
        }
        private void btnModificarParte_Click(object sender, EventArgs e)
        {
            try
            {
                List<ParteVentaDiario> partesVentasDiarios = tienda.getPartesVentasRealesDia(VariablesEntorno.mesAbierto.Value, diaSeleccionado, true);
                ModificarParteVentaResumidoUIController modificarFormController = new ModificarParteVentaResumidoUIController(session, partesVentasDiarios, session.makeDate(diaSeleccionado), tienda);
                DialogResult result = modificarFormController.Ejecutar().ShowDialog();
                if (result == DialogResult.OK)
                {                  
                    session.actualizarPlanesVentasTiendas();                  
                    restablecerFormulario();
                    modificado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteFactory.getReporteParteVentaDiarioResumidoTienda(tienda.reporteParteDiarioAcumuladosVentasResumidasMesActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void llenarPartesVentas()
        {
            forma.lwParteVenta.Items.Clear();
            for (int i = 0; i < tienda.reporteParteDiarioAcumuladosVentasResumidasMesActual.listViewItemVentasResumidasPorDia.Count; i++)
            {  
                forma.lwParteVenta.Items.Add(session.temaAplication.inicializarSubListViewItem(tienda.reporteParteDiarioAcumuladosVentasResumidasMesActual.listViewItemVentasResumidasPorDia[i], i+1));
            }            
            forma.lwParteVenta.Items.Add(session.temaAplication.inicializarListViewItemTotal(tienda.reporteParteDiarioAcumuladosVentasResumidasMesActual.itemTotal));
        }
    }
}