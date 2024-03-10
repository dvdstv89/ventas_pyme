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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NucleoEV.UIController
{
    internal class GestionarTiendaUIController : BaseUIController, IController<GestionarTiendaUI>
    {
        MainUIController mainUI;
        List<Complejo> complejos;
        private List<Tienda> tiendas = new List<Tienda>();
        Tienda tiendaSeleccionada;
        private List<Complejo> complejosSeleccionados = new List<Complejo>();
        private List<ListViewItem> elementosSeleccionadosComplejo = new List<ListViewItem>();
        bool isPrimeraVez;

        public GestionarTiendaUIController(Session session, MainUIController mainUI) : base(session, new GestionarTiendaUI())
        {
            try
            {               
                this.mainUI = mainUI;                
                tiendaSeleccionada = null;
                this.complejos = ComplejoData.getByComplejosTiendasAutorizadosInSessionToken();
                isPrimeraVez = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        public GestionarTiendaUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);         
            getForma().lwComplejo.ItemChecked += new ItemCheckedEventHandler(LwComplejos_ItemChecked);
            getForma().lwComplejo.GotFocus += LwComplejos_GotFocus;
            getForma().lwTiendas.SelectedIndexChanged += new EventHandler(lwTiendas_SelectedIndexChanged);
            getForma().btnNuevaTienda.Click += new EventHandler(btnAdicionarTienda_Click);
            getForma().btnModificarTienda.Click += new EventHandler(btnModificarTienda_Click); 
            getForma().btnDetallesTienda.Click += new EventHandler(btnAbrir_Click);           
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {          
            aplicarTema();  
            restablecerFormulario();          
        }
        void aplicarTema()
        {
            session.temaAplication.inicializarListView(ref getForma().lwTiendas);
            session.temaAplication.inicializarListView(ref getForma().lwComplejo);
            forma.BackColor  = session.temaAplication.formularioBgColor();    
        }
        void restablecerFormulario()
        {         
            getForma().btnModificarTienda.Enabled = false;               
            getForma().btnDetallesTienda.Enabled = false;
            getForma().btnPlanVentaTienda.Enabled = false;
            LlenarListaComplejos();
        }
        private void LlenarListaComplejos()
        {
            getForma().lwComplejo.Items.Clear();
            for (int i = 0; i < complejos.Count; i++)
            {
                complejos[i].setReporteParteDiarioAcumuladosVentasResumidasMesActual(VariablesEntorno.mesAbierto);                         
                ListViewItem item = complejos[i].reporteParteDiarioAcumuladosVentasResumidasMesActual.getListViewItemTotal(); 
                if(isPrimeraVez)
                {
                    item.Checked= true;
                }
                else
                {
                    item.Checked = elementosSeleccionadosComplejo.Exists(x => x.Text == item.Text);                    
                }
                getForma().lwComplejo.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            }
            if(!isPrimeraVez)
            {               
                ActualizarSeleccion();
            }
            isPrimeraVez =false;
        }
        private void LwComplejos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                // Agregar elemento a la lista de elementos seleccionados
                elementosSeleccionadosComplejo.Add(e.Item);
            }
            else
            {
                // Eliminar elemento de la lista de elementos seleccionados
                elementosSeleccionadosComplejo.Remove(e.Item);
            }

            // Actualizar lista de complejos seleccionados y tiendas
            ActualizarSeleccion();
        }
        private void LwComplejos_GotFocus(object sender, EventArgs e)
        {
            // Volver a marcar los elementos seleccionados al recuperar el foco
            foreach (ListViewItem item in elementosSeleccionadosComplejo)
            {
                item.Checked = true;
            }
        }
        private void ActualizarSeleccion()
        {
            complejosSeleccionados.Clear();
            tiendas.Clear();

            foreach (ListViewItem item in getForma().lwComplejo.CheckedItems)
            {
                int index = item.Index;
                complejosSeleccionados.Add(complejos[index]);
                tiendas.AddRange(complejos[index].tiendas);
                tiendas.Add(null);
            }

            LlenarListadoTiendas();
        }
        private void LlenarListadoTiendas()
        {           
            getForma().lwTiendas.Items.Clear();
            tiendaSeleccionada = null;           
            foreach (Complejo complejo in complejosSeleccionados)
            {
                //complejo.setReporteParteDiarioAcumuladosVentasResumidasMesActual(VariablesEntorno.mesAbierto);
                llenarListadoTiendasCompelejo(complejo);             
            }           
        }
        private void llenarListadoTiendasCompelejo(Complejo complejo)
        {          
            for (int i = 0; i < complejo.reporteParteDiarioAcumuladosVentasResumidasMesActual.listViewItemVentasResumidasPorDia.Count; i++)
            {
                getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItem(complejo.reporteParteDiarioAcumuladosVentasResumidasMesActual.listViewItemVentasResumidasPorDia[i], i + 1, complejo.tiendas[i].isAbierta.Value));
            }
            getForma().lwTiendas.Items.Add(session.temaAplication.inicializarListViewItemTotal(complejo.reporteParteDiarioAcumuladosVentasResumidasMesActual.itemTotal));
        }
        private void lwTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (getForma().lwTiendas.SelectedIndices.Count == 1)
                {
                    tiendaSeleccionada = tiendas[getForma().lwTiendas.SelectedIndices[0]];
                    if (tiendaSeleccionada != null)
                    {
                        getForma().btnModificarTienda.Enabled = true;
                        getForma().btnDetallesTienda.Enabled = true;
                        getForma().btnPlanVentaTienda.Enabled = true;
                    }
                   else
                    {
                        putTiendaSeleccionadaAsNull();
                    }                   
                }
                else
                {
                    putTiendaSeleccionadaAsNull();
                }
            }
            catch
            {
                tiendaSeleccionada = null;
            }
        }
        private void putTiendaSeleccionadaAsNull()
        {
            tiendaSeleccionada = null;
            getForma().btnModificarTienda.Enabled = false;
            getForma().btnDetallesTienda.Enabled = false;
        }
        private void btnAdicionarTienda_Click(object sender, EventArgs e)
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
        private void btnModificarTienda_Click(object sender, EventArgs e)
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
        public GestionarTiendaUI getForma()
        {
            return forma as GestionarTiendaUI;
        }
        private void reseleccionarTienda(Tienda tiendaMarcada)
        {           
            int index = tiendas.FindIndex(t => t.getId() == tiendaMarcada.getId());
            getForma().lwTiendas.Items[index].Selected = true;
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
                        tiendaSeleccionada.isSincronizada.Value = true;
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
    }   
}