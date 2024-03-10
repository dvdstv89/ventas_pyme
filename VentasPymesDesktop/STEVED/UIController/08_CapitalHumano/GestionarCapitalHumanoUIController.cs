using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData;
using ModelData.Service.RemotoDatabaseClient;
using ModelData.Service.LocalDatabaseClient;

namespace NucleoEV.UIController
{
    internal class GestionarCapitalHumanoUIController : BaseUIController, IController<GestionarCapitalHumanoUI>
    {
        MainUIController mainUI;
        List<Tienda> tiendas;
        Tienda tiendaSeleccionada;
        Complejo complejoSeleccionado;
        protected List<Complejo> complejos;
        public GestionarCapitalHumanoUIController(Session session, MainUIController mainUI) : base(session, new GestionarCapitalHumanoUI())
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
        public GestionarCapitalHumanoUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            getForma().cbComplejos.SelectedIndexChanged += new EventHandler(cbComplejos_SelectedIndexChanged);
            getForma().lwTiendas.SelectedIndexChanged += new EventHandler(lwTiendas_SelectedIndexChanged);
            getForma().btnAdicionar.Click += new EventHandler(btnAdicionar_Click);
            getForma().btnModificar.Click += new EventHandler(btnModificar_Click);
            getForma().btnEliminar.Click += new EventHandler(btnEliminar_Click);
            getForma().btnAbrir.Click += new EventHandler(btnAbrir_Click);
            getForma().btnCerrar.Click += new EventHandler(btnCerrar_Click);
            getForma().btnGestionarPlanVenta.Click += new EventHandler(btnGestionarPlanVenta_Click);
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {
            getForma().panelDetails.Visible = false;
            aplicarTema();
            LlenarComboComplejos();          
            restablecerFormulario();           
        }
        void aplicarTema()
        {
            session.temaAplication.inicializarListView(ref getForma().lwTiendas);
            session.temaAplication.inicializarSubListView(ref getForma().lwPlanVenta);
            forma.BackColor  = session.temaAplication.formularioBgColor();
            getForma().panelDetails.BackColor = session.temaAplication.inicializarColor(TipoColor.PanelDetails);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnAdicionar, TipoToolStripButton.Adicionar);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnModificar, TipoToolStripButton.Modificar);           
            session.temaAplication.inicializarToolStripButton(ref getForma().btnEliminar, TipoToolStripButton.Eliminar);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnAdicionar, TipoToolStripButton.Adicionar);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnAbrir, TipoToolStripButton.Abrir);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnCerrar, TipoToolStripButton.Cerrar);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnGestionarPlanVenta, TipoToolStripButton.PlanVenta);
            getForma().panelBanner.BackColor = new TemaAplication().inicializarColor(TipoColor.PanelBannerBC);
            getForma().lbDetailsHeaderTitle.Font = new TemaAplication().inicializarTexto(TipoTexto.Title);
            getForma().lbDetailsHeaderTitle.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
        }
        void restablecerFormulario(bool llenarCombo = true)
        {
            getForma().btnEliminar.Enabled = false;
            getForma().btnModificar.Enabled = false;
            getForma().btnAbrir.Enabled = false;
            getForma().btnAbrir.Visible = true;
            getForma().btnCerrar.Enabled = false;
            getForma().btnCerrar.Visible = false;
            getForma().separadorAbrirCerrarTienda.Visible = true;
            getForma().panelDetails.Visible = false;
            getForma().btnGestionarPlanVenta.Enabled = false;
            if(llenarCombo)
                LlenarComboComplejos();
        }      
        private void LlenarComboComplejos()
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
                LlenarListadoTiendas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LlenarListadoTiendas()
        {           
            getForma().lwTiendas.Items.Clear();
            tiendaSeleccionada = null;          

            int pos = 0;
            foreach (Tienda tienda in tiendas)
            {
                ListViewItem item = new ListViewItem(tienda.denominacion.Value);
                string abierta = (tienda.isAbierta.Value) ? "Abierto" : "Cerrada";
                item.SubItems.Add(abierta);
                item.SubItems.Add(tienda.moneda.Objeto.denominacion.Value);
                item.SubItems.Add(tienda.planVentaMesActual.getMoneyFormated());
                item.SubItems.Add(tienda.porcientoVentaResumidaMesActual.Value);
                item.SubItems.Add(tienda.planVentaAnno.getMoneyFormated());
                getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItem(item, pos++));
            }
            ListViewItem itemTotal = new ListViewItem(complejoSeleccionado.denominacion.Value);
            itemTotal.SubItems.Add("Plan del año");
            itemTotal.SubItems.Add(VariablesEntorno.annoAbierto.Value.ToString());
            itemTotal.SubItems.Add(complejoSeleccionado.planVentaMesActual.getMoneyFormated());
            itemTotal.SubItems.Add(complejoSeleccionado.porcientoVentaResumidaMesActual.Value);
            itemTotal.SubItems.Add(complejoSeleccionado.planVentaAnno.getMoneyFormated());
            getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItemTotal(itemTotal));
        }
        private void lwTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {             
                tiendaSeleccionada = (getForma().lwTiendas.SelectedIndices.Count > 0) ? tiendas[getForma().lwTiendas.SelectedIndices[0]] : null;

                if (tiendaSeleccionada!= null)
                {                 
                    if(tiendaSeleccionada.isAbierta.Value)
                    {
                        getForma().btnAbrir.Enabled = false;
                        getForma().btnAbrir.Visible = false;
                        getForma().btnCerrar.Enabled = true;
                        getForma().btnCerrar.Visible = true;
                    }
                    else
                    {
                        getForma().btnAbrir.Enabled = true;
                        getForma().btnAbrir.Visible = true;
                        getForma().btnCerrar.Enabled = false;
                        getForma().btnCerrar.Visible = false;
                    }


                    getForma().btnEliminar.Enabled = true;
                    getForma().btnModificar.Enabled = true;                 
                    getForma().separadorAbrirCerrarTienda.Visible = true;
                    getForma().panelDetails.Visible = true;
                    getForma().btnGestionarPlanVenta.Enabled = true;

                    getForma().tbComplejo.Text = complejos.Find(c=> c.id.Value ==  tiendaSeleccionada.idComplejo.Value).denominacion.Value;
                    getForma().tbMoneda.Text = tiendaSeleccionada.moneda.Objeto.denominacion.Value;
                    getForma().tbNombreTienda.Text = tiendaSeleccionada.denominacion.Value;

                    getForma().lbxFormasPago.Text = String.Empty;
                    getForma().lwPlanVenta.Items.Clear();
                    
                    for (int i = 0; i < tiendaSeleccionada.formasPagosUtiliza.Count; i++)
                    {                       
                        if (getForma().lbxFormasPago.Text != String.Empty)
                            getForma().lbxFormasPago.Text += "\r\n";
                        getForma().lbxFormasPago.Text += tiendaSeleccionada.formasPagosUtiliza[i].denominacion;
                    }
                   
                    for (int i = 0; i < tiendaSeleccionada.planesVentas.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(tiendaSeleccionada.planesVentas[i].fecha.Mes.Mes);                       
                        item.SubItems.Add(tiendaSeleccionada.planesVentas[i].planDiario.getMoneyFormated());
                        item.SubItems.Add(tiendaSeleccionada.planesVentas[i].saldo.getMoneyFormated());                                        
                        getForma().lwPlanVenta.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
                    }
                    ListViewItem itemTotal = new ListViewItem("Total Año " + VariablesEntorno.ultimaFechaValida.Year);                  
                    itemTotal.SubItems.Add(tiendaSeleccionada.planDiarioPromedio.getMoneyFormated());
                    itemTotal.SubItems.Add(tiendaSeleccionada.planVentaAnno.getMoneyFormated());
                    getForma().lwPlanVenta.Items.Add(session.temaAplication.inicializarListViewItemTotal(itemTotal));
                }
                else
                {
                    restablecerFormulario(false);
                }
            }
            catch
            {
                tiendaSeleccionada = null;
                getForma().panelDetails.Visible = false;
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarTiendaUIController modificarFormController = new AdicionarTiendaUIController(session, complejos);
                DialogResult result = modificarFormController.Ejecutar().ShowDialog();
                if (result == DialogResult.OK)
                {
                    session.actualizarPlanesVentasTiendas();
                    restablecerFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarTiendaUIController modificarFormController = new ModificarTiendaUIController(session, tiendaSeleccionada, complejos);
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = new MensajeBox().confirmarEliminacion();
                if (result == DialogResult.Yes)
                {
                    if (session.chequearConectividadConServidor())
                    {
                        new TiendaRDB().eliminarTienda(tiendaSeleccionada);
                        tiendaSeleccionada.isSincronizada.Value = true;                        ;
                    }
                    else
                    {
                        tiendaSeleccionada.isSincronizada.Value = false;
                    }
                    new TiendaLDB().eliminarTienda(tiendaSeleccionada);
                    session.actualizarPlanesVentasTiendas();
                    restablecerFormulario();
                    new MensajeBox().eliminacionOk();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (session.chequearConectividadConServidor())
                {
                    new TiendaRDB().abrirTienda(tiendaSeleccionada);
                    tiendaSeleccionada.isSincronizada.Value = true;                   
                }
                else
                {
                    tiendaSeleccionada.isSincronizada.Value = false;
                }
                Tienda tiendaSeleccionadaSalva = tiendaSeleccionada;
                new TiendaLDB().abrirTienda(tiendaSeleccionada);
                session.actualizarPlanesVentasTiendas();
                restablecerFormulario();
                new MensajeBox().modificacionOk();
                reseleccionarTienda(tiendaSeleccionadaSalva);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (session.chequearConectividadConServidor())
                {
                    new TiendaRDB().cerrarTienda(tiendaSeleccionada);
                    tiendaSeleccionada.isSincronizada.Value = true;                   
                }
                else
                {
                    tiendaSeleccionada.isSincronizada.Value = false;
                }
                Tienda tiendaSeleccionadaSalva = tiendaSeleccionada;
                new TiendaLDB().cerrarTienda(tiendaSeleccionada);
                session.actualizarPlanesVentasTiendas();
                restablecerFormulario();
                new MensajeBox().modificacionOk();
                reseleccionarTienda(tiendaSeleccionadaSalva);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGestionarPlanVenta_Click(object sender, EventArgs e)
        {
            try
            {
                PlanVentaUIController planVentaUIController = new PlanVentaUIController(session, tiendaSeleccionada);
                mainUI.ocultarVentanaPrincipal();
                DialogResult result = planVentaUIController.Ejecutar().ShowDialog();
                mainUI.mostrarVentanaPrincipal();
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
        public GestionarCapitalHumanoUI getForma()
        {
            return forma as GestionarCapitalHumanoUI;
        }
        private void reseleccionarTienda(Tienda tiendaMarcada)
        {
            int indexComplejoSeleccionado = complejos.FindIndex(c => c.denominacion.Value == getForma().cbComplejos.Text);
            int index = complejos[indexComplejoSeleccionado].tiendas.FindIndex(t => t.getId() == tiendaMarcada.getId());
            getForma().lwTiendas.Items[index].Selected = true;
        }
    }   
}