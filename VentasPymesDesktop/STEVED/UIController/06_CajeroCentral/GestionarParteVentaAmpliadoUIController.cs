using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;

using ModelData;

namespace NucleoEV.UIController
{
    internal class GestionarParteVentaAmpliadoUIController : BaseUIController, IController<GestionarParteVentaAmpliadoUI>
    {
        MainUIController mainUI;
        List<Tienda> tiendas;
        Tienda tiendaSeleccionada;       
        List<Complejo> complejos;
        Complejo complejoSeleccionado;
        int diaSeleccionado;
        public GestionarParteVentaAmpliadoUIController(Session session, MainUIController mainUI) : base(session, new GestionarParteVentaAmpliadoUI())
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
        public GestionarParteVentaAmpliadoUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            getForma().cbComplejos.SelectedIndexChanged += new EventHandler(cbComplejos_SelectedIndexChanged);
            getForma().lwTiendas.SelectedIndexChanged += new EventHandler(lwTiendas_SelectedIndexChanged);
            getForma().lwParteVenta.SelectedIndexChanged += new EventHandler(lwParteVenta_SelectedIndexChanged);
            getForma().btnNuevoParteVentaMLC.Click += new EventHandler(btnNuevoParteVentaMLC);
            getForma().btnNuevoParteVentaCUP.Click += new EventHandler(btnNuevoParteVentaCUP);
            getForma().btnModificarParte.Click += new EventHandler(btnModificarParte_Click);
            getForma().btnVerParteDetallado.Click += new EventHandler(btnVerParteDetallado_Click);
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {            
            getForma().panelDetails.Visible = false;
            aplicarTema();
            getForma().lbDetailsHeaderTitle.Text = VariablesEntorno.mesAbierto.Mes;
            llenarComboComplejos();          
            restablecerFormulario();           
        }
        void aplicarTema()
        {
            session.temaAplication.inicializarListView(ref getForma().lwTiendas);
            session.temaAplication.inicializarSubListView(ref getForma().lwParteVenta);
            forma.BackColor  = session.temaAplication.formularioBgColor();
            getForma().panelDetails.BackColor = session.temaAplication.inicializarColor(TipoColor.PanelDetails);          
            session.temaAplication.inicializarToolStripButton(ref getForma().btnNuevoParteVentaMLC, TipoToolStripButton.NuevoParteVentaMLC);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnNuevoParteVentaCUP, TipoToolStripButton.NuevoParteVentaCUP, true);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnModificarParte, TipoToolStripButton.ModificarParteVenta, true);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnVerParteDetallado, TipoToolStripButton.VerDetalles, true);
            getForma().panelBanner.BackColor = new TemaAplication().inicializarColor(TipoColor.PanelBannerBC);
            getForma().lbDetailsHeaderTitle.Font = new TemaAplication().inicializarTexto(TipoTexto.Title);
            getForma().lbDetailsHeaderTitle.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
        }
        void restablecerFormulario()
        {
            getForma().panelDetails.Visible = false;
            diaSeleccionado = 0;               
            getForma().btnModificarParte.Enabled = false;
            getForma().btnVerParteDetallado.Enabled = false;
            llenarComboComplejos();
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
                tiendas = complejoSeleccionado.tiendas;
                llenarListadoTiendas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void llenarListadoTiendas()
        {
            try
            {
                getForma().btnNuevoParteVentaMLC.Enabled = (complejoSeleccionado.tiendas.FindAll(t => t.isMonedaCUP() == false).Count > 0);
                getForma().btnNuevoParteVentaCUP.Enabled = (complejoSeleccionado.tiendas.FindAll(t => t.isMonedaCUP() == true).Count > 0);
                getForma().lwTiendas.Items.Clear();
                tiendaSeleccionada = null;
                int pos = 0;
                foreach (Tienda tienda in tiendas)
                {
                    ListViewItem item = new ListViewItem(tienda.denominacion.Value);
                    item.SubItems.Add(tienda.planVentaMesActual.getMoneyFormated());
                    item.SubItems.Add(tienda.porcientoVentaDetalladasMesActual.Value);
                    item.SubItems.Add(tienda.planVentaAnno.getMoneyFormated());
                    item.SubItems.Add(tienda.porcientoVentaDetalladasAnnoActual.Value);
                    getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItem(item, pos++));
                }
                ListViewItem itemTotal = new ListViewItem(complejoSeleccionado.denominacion.Value);
                itemTotal.SubItems.Add(complejoSeleccionado.planVentaMesActual.getMoneyFormated());
                itemTotal.SubItems.Add(complejoSeleccionado.porcientoVentaDetalladasMesActual.Value);
                itemTotal.SubItems.Add(complejoSeleccionado.planVentaAnno.getMoneyFormated());
                itemTotal.SubItems.Add(complejoSeleccionado.porcientoVentaDetalladasAnnoActual.Value);
                getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItemTotal(itemTotal));
            }
            catch
            {
                tiendaSeleccionada = null;
                getForma().panelDetails.Visible = false;
            }
        }
        private void lwTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tiendaSeleccionada = (getForma().lwTiendas.SelectedIndices.Count > 0) ? tiendas[getForma().lwTiendas.SelectedIndices[0]] : null;
                if (tiendaSeleccionada != null)
                {                                 
                    getForma().panelDetails.Visible = true;  
                    getForma().tbNombreTienda.Text = tiendaSeleccionada.denominacion.Value;
                    getForma().lwParteVenta.Items.Clear();                    

                    for (int i = 1; i <= Session.countDaysOfMounth(); i++)
                    {
                        ListViewItem item = new ListViewItem(i.ToString());
                        item.SubItems.Add(tiendaSeleccionada.planDiarioMesActual.getMoneyFormated());
                        item.SubItems.Add(tiendaSeleccionada.getGananciaNetaVentasDia(VariablesEntorno.mesAbierto.Value, i).getMoneyFormated());
                        item.SubItems.Add(tiendaSeleccionada.getComisionVentasTotalesDia(VariablesEntorno.mesAbierto.Value, i).getMoneyFormated());
                        item.SubItems.Add(tiendaSeleccionada.getVentaTotalDia(VariablesEntorno.mesAbierto.Value, i).getMoneyFormated());
                        getForma().lwParteVenta.Items.Add(session.temaAplication.inicializarSubListViewItem(item, i));
                    }
                    ListViewItem itemTotal = new ListViewItem("Total");
                    itemTotal.SubItems.Add(tiendaSeleccionada.planVentaMesActual.getMoneyFormated());
                    itemTotal.SubItems.Add(tiendaSeleccionada.ventasRealesDetalladasMesActual.getMoneyFormated());
                    getForma().lwParteVenta.Items.Add(session.temaAplication.inicializarListViewItemTotal(itemTotal));
                }
            }
            catch
            {
                tiendaSeleccionada = null;
                getForma().panelDetails.Visible = false;
            }
        }
        private void lwParteVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (getForma().lwParteVenta.SelectedIndices.Count > 0)
                {
                    diaSeleccionado = getForma().lwParteVenta.SelectedIndices[0] + 1;
                    if (diaSeleccionado < getForma().lwParteVenta.Items.Count)
                    {
                        DateTime fechaSeleccionada = session.makeDate(diaSeleccionado);
                        if (fechaSeleccionada <= VariablesEntorno.ultimaFechaValida)
                        {
                            getForma().btnModificarParte.Enabled = true;
                            getForma().btnVerParteDetallado.Enabled = true;
                        }
                        else
                        {
                            getForma().btnModificarParte.Enabled = false;
                            getForma().btnVerParteDetallado.Enabled = false;
                        }
                    }
                    else
                    {
                        diaSeleccionado = 0;
                        getForma().btnModificarParte.Enabled = false;
                        getForma().btnVerParteDetallado.Enabled = false;
                    }
                }
            }
            catch
            {
                diaSeleccionado = 0;
                getForma().btnModificarParte.Enabled = false;
                getForma().btnVerParteDetallado.Enabled = false;                     
            }
        }
        private void btnNuevoParteVentaMLC(object sender, EventArgs e)
        {
            try
            {
                //ParteVentaAmpliadoUIController parteVentaFormController = new ParteVentaAmpliadoUIController(session, complejoSeleccionado, MonedaData.getMonedaById(VariablesEntorno.idMonedaMLC) );
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
                //ParteVentaAmpliadoUIController parteVentaFormController = new ParteVentaAmpliadoUIController(session, complejoSeleccionado, MonedaData.getMonedaById(VariablesEntorno.idMonedaCUP));
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
        private void btnModificarParte_Click(object sender, EventArgs e)
        {
            try
            {
                List<ParteVentaDiario> partesVentasDiarios = tiendaSeleccionada.getPartesVentasRealesDia(VariablesEntorno.mesAbierto.Value, diaSeleccionado);
                ModificarParteVentaAmpliadoUIController modificarFormController = new ModificarParteVentaAmpliadoUIController(session, partesVentasDiarios, session.makeDate(diaSeleccionado), tiendaSeleccionada);
                DialogResult result = modificarFormController.Ejecutar().ShowDialog();
                if (result == DialogResult.OK)
                {
                    Tienda tiendaSeleccionadaSalva = tiendaSeleccionada;
                    session.actualizarPlanesVentasTiendas();
                    restablecerFormulario();
                    reseleccionarTienda(tiendaSeleccionadaSalva);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnVerParteDetallado_Click(object sender, EventArgs e)
        {
            try
            {
                List<ParteVentaDiario> partesVentasDiarios = tiendaSeleccionada.getPartesVentasRealesDia(VariablesEntorno.mesAbierto.Value, diaSeleccionado);
                DetallesParteVentaAmpliadoUIController detallesFormController = new DetallesParteVentaAmpliadoUIController(session, partesVentasDiarios, session.makeDate(diaSeleccionado), tiendaSeleccionada);
                detallesFormController.Ejecutar().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public GestionarParteVentaAmpliadoUI getForma()
        {
            return forma as GestionarParteVentaAmpliadoUI;
        }
        private void reseleccionarTienda(Tienda tiendaMarcada)
        {
            int indexComplejoSeleccionado = complejos.FindIndex(c => c.denominacion.Value == getForma().cbComplejos.Text);
            int index = complejos[indexComplejoSeleccionado].tiendas.FindIndex(t => t.getId() == tiendaMarcada.getId());
            getForma().lwTiendas.Items[index].Selected = true;
        }
    }   
}
