using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData;
using ModelData.Report;
using ModelData.Report.Model;

namespace NucleoEV.UIController
{
    internal class GestionarParteVentaResumidaUIController : BaseUIController, IController<GestionarParteVentaResumidoUI>
    {
        MainUIController mainUI;
        List<Tienda> tiendas;
        Tienda tiendaSeleccionada;       
        List<Complejo> complejos;
        Complejo complejoSeleccionado;
       
        public GestionarParteVentaResumidaUIController(Session session, MainUIController mainUI) : base(session, new GestionarParteVentaResumidoUI())
        {
            try
            {               
                this.mainUI = mainUI;                
                tiendaSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        public GestionarParteVentaResumidoUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            getForma().cbComplejos.SelectedIndexChanged += new EventHandler(cbComplejos_SelectedIndexChanged);
            getForma().lwTiendas.SelectedIndexChanged += new EventHandler(lwTiendas_SelectedIndexChanged);           
            getForma().btnNuevoParteVentaMLC.Click += new EventHandler(btnNuevoParteVentaMLC);
            getForma().btnNuevoParteVentaCUP.Click += new EventHandler(btnNuevoParteVentaCUP);
            getForma().btnExportarExcelParteVentaComplejo.Click += new EventHandler(btnExportarExcelParteVentaComplejo_Click);
            getForma().btnExportarExcelParteVentaComplejoyTienda.Click += new EventHandler(btnExportarExcelParteVentaComplejoyTiendas_Click);
            getForma().btnDetalles.Click += new EventHandler(btDetalles);
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {           
            aplicarTema();            
            llenarComboComplejos();          
            restablecerFormulario();           
        }
        void aplicarTema()
        {
            session.temaAplication.inicializarListView(ref getForma().lwTiendas);          
            forma.BackColor  = session.temaAplication.formularioBgColor();                  
            session.temaAplication.inicializarToolStripButton(ref getForma().btnNuevoParteVentaMLC, TipoToolStripButton.NuevoParteVentaMLC);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnNuevoParteVentaCUP, TipoToolStripButton.NuevoParteVentaCUP, true); 
        }
        void restablecerFormulario()
        {               
            llenarComboComplejos();
            getForma().btnDetalles.Enabled = false;
        }        
        private void llenarComboComplejos()
        {           
            complejos = ComplejoData.getByComplejosAutorizadosInSessionToken();
            int indexSeleccionado = complejos.FindIndex(c => c.denominacion.Value == getForma().cbComplejos.Text);           

            getForma().cbComplejos.Items.Clear();
            foreach (Complejo complejo in complejos)
            {
                getForma().cbComplejos.Items.Add(complejo.denominacion);
            }
            indexSeleccionado = (complejos.Count > 0 && indexSeleccionado != -1) ? indexSeleccionado : 0;            
            getForma().cbComplejos.SelectedIndex = indexSeleccionado;           

        }        
        private void cbComplejos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int indexSeleccionado = complejos.FindIndex(c => c.denominacion.Value == getForma().cbComplejos.Text);
                complejoSeleccionado = (indexSeleccionado != -1) ? complejos[indexSeleccionado] : null;
                if(complejoSeleccionado != null)
                {
                    complejoSeleccionado.setReporteParteDiarioAcumuladosVentasResumidasMesActual(VariablesEntorno.mesAbierto);
                }
                tiendas = complejoSeleccionado.tiendas;
                llenarListadoTiendas();
            }
            catch
            {
                tiendaSeleccionada = null;              
            }
        }
        private void llenarListadoTiendas()
        {
            getForma().btnNuevoParteVentaMLC.Enabled = (complejoSeleccionado.tiendas.FindAll(t => t.isMonedaCUP() == false).Count > 0);
            getForma().btnNuevoParteVentaCUP.Enabled = (complejoSeleccionado.tiendas.FindAll(t => t.isMonedaCUP() == true).Count > 0);
            getForma().lwTiendas.Items.Clear();
            for (int i = 0; i < complejoSeleccionado.reporteParteDiarioAcumuladosVentasResumidasMesActual.listViewItemVentasResumidasPorDia.Count; i++)
            {
                getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItem(complejoSeleccionado.reporteParteDiarioAcumuladosVentasResumidasMesActual.listViewItemVentasResumidasPorDia[i], i + 1, complejoSeleccionado.tiendas[i].isAbierta.Value));
            }
            getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItemTotal(complejoSeleccionado.reporteParteDiarioAcumuladosVentasResumidasMesActual.itemTotal));
        }
        private void lwTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tiendaSeleccionada = (getForma().lwTiendas.SelectedIndices.Count > 0) ? tiendas[getForma().lwTiendas.SelectedIndices[0]] : null;
                if (tiendaSeleccionada != null)
                {
                    getForma().btnDetalles.Enabled = true;
                }
                else
                {
                    getForma().btnDetalles.Enabled = false;
                }
            }
            catch
            {
                tiendaSeleccionada = null;              
            }
        }       
        private void btnNuevoParteVentaMLC(object sender, EventArgs e)
        {
            try
            {
                //ParteVentaResumidoUIController parteVentaFormController = new ParteVentaResumidoUIController(session, complejoSeleccionado, MonedaData.getMonedaById(VariablesEntorno.idMonedaMLC) );
                //DialogResult result = parteVentaFormController.Ejecutar().ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    session.actualizarPartesVentasTiendas();                   
                //    restablecerFormulario();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnNuevoParteVentaCUP(object sender, EventArgs e)
        {
            try
            {
                //ParteVentaResumidoUIController parteVentaFormController = new ParteVentaResumidoUIController(session, complejoSeleccionado, MonedaData.getMonedaById(VariablesEntorno.idMonedaCUP));
                //DialogResult result = parteVentaFormController.Ejecutar().ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    session.actualizarPartesVentasTiendas();                   
                //    restablecerFormulario();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btDetalles(object sender, EventArgs e)
        {
            try
            {                
                DetallesParteVentaResumidaMesActualUIController parteVentaFormController = new DetallesParteVentaResumidaMesActualUIController(session, tiendaSeleccionada, complejoSeleccionado);
                parteVentaFormController.Ejecutar().ShowDialog();
                if (parteVentaFormController.modificado)
                {
                    session.actualizarPartesVentasTiendas();
                    restablecerFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExportarExcelParteVentaComplejo_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteFactory.getReporteParteVentaDiarioResumidoComplejo(complejoSeleccionado.reporteParteDiarioAcumuladosVentasResumidasMesActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExportarExcelParteVentaComplejoyTiendas_Click(object sender, EventArgs e)
        {
            try
            {
                List<ParteDiarioAcumuladosVentasResumidasTienda> parteDiarioAcumuladosVentasResumidasTiendas = new List<ParteDiarioAcumuladosVentasResumidasTienda>();
                foreach (Tienda tienda in tiendas)
                {
                    tienda.setReporteParteDiarioAcumuladosVentasResumidasMesActual(complejoSeleccionado,VariablesEntorno.mesAbierto);
                    parteDiarioAcumuladosVentasResumidasTiendas.Add(tienda.reporteParteDiarioAcumuladosVentasResumidasMesActual);
                }
                ReporteFactory.getReporteParteVentaDiarioResumidoComplejoAndTiendas(complejoSeleccionado.reporteParteDiarioAcumuladosVentasResumidasMesActual, parteDiarioAcumuladosVentasResumidasTiendas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public GestionarParteVentaResumidoUI getForma()
        {
            return forma as GestionarParteVentaResumidoUI;
        }
        private void reseleccionarTienda(Tienda tiendaMarcada)
        {
            int indexComplejoSeleccionado = complejos.FindIndex(c => c.denominacion.Value == getForma().cbComplejos.Text);
            int index = complejos[indexComplejoSeleccionado].tiendas.FindIndex(t => t.getId() == tiendaMarcada.getId());
            getForma().lwTiendas.Items[index].Selected = true;
        }
    }   
}
