using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData;
using ModelData.Service.LocalDatabaseClient;
using System.Runtime.InteropServices;

namespace NucleoEV.UIController
{
    internal class GestionarConciliacionUIController : BaseUIController, IController<GestionarConciliacionUI>
    {
        MainUIController mainUI;            
        List<Complejo> complejos;
        List<GrupoConciliacion> grupoConsiliaciones;
        Complejo complejoSeleccionado;
        GrupoConciliacion grupoConsiliacionSeleccionado;
        List<Conciliacion> conciliaciones;
        Conciliacion conciliacionSeleccionada;
        int diaSeleccionado;
        public GestionarConciliacionUIController(Session session, MainUIController mainUI) : base(session, new GestionarConciliacionUI())
        {
            try
            {               
                this.mainUI = mainUI;
                conciliacionSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        public GestionarConciliacionUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            getForma().cbComplejos.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            getForma().cbGrupoConciliacion.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            getForma().lwConciliaciones.SelectedIndexChanged += new EventHandler(lwConciliaciones_SelectedIndexChanged);           
            getForma().btnNuevaConciliacion.Click += new EventHandler(btnNuevaConciliacion_Click);          
            getForma().btnModificarConciliacion.Click += new EventHandler(btnModificarParte_Click);           
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {
            getForma().panelDetails.Visible = false;
            aplicarTema();           
            restablecerFormulario();
            getForma().lbDetailsHeaderTitle.Text = VariablesEntorno.mesAbierto.Mes;
        }
        void aplicarTema()
        {
            session.temaAplication.inicializarListView(ref getForma().lwConciliaciones);
            session.temaAplication.inicializarSubListView(ref getForma().lwParteVenta);
            forma.BackColor  = session.temaAplication.formularioBgColor();
            getForma().panelDetails.BackColor = session.temaAplication.inicializarColor(TipoColor.PanelDetails);          
            session.temaAplication.inicializarToolStripButton(ref getForma().btnNuevaConciliacion, TipoToolStripButton.CrearConciliacionBancaria);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnModificarConciliacion, TipoToolStripButton.ModificarConciliacionBancaria, true);            
            getForma().panelBanner.BackColor = new TemaAplication().inicializarColor(TipoColor.PanelBannerBC);
            getForma().lbDetailsHeaderTitle.Font = new TemaAplication().inicializarTexto(TipoTexto.Title);
            getForma().lbDetailsHeaderTitle.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
        }
        void restablecerFormulario()
        {
            getForma().panelDetails.Visible = false;
            diaSeleccionado = 0;
            visualizarFuncionalidadesPorPermisos();           
            getForma().btnModificarConciliacion.Enabled = false;           
            llenarComboComplejos();
            llenarComboGrupoConciliaciones();
        }
        void visualizarFuncionalidadesPorPermisos()
        {
            //grupo de conciliaciones que puede ver 
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
        private void llenarComboGrupoConciliaciones()
        {
            grupoConsiliaciones = GrupoConsiliacionData.getGrupoConsiliacionAutorizadosInSessionToken();
            if (grupoConsiliaciones.Count == 0) return;
            int indexSeleccionado = grupoConsiliaciones.FindIndex(g => g.denominacion.Value == getForma().cbGrupoConciliacion.Text);

            getForma().cbGrupoConciliacion.Items.Clear();
            foreach (GrupoConciliacion grupo in grupoConsiliaciones)
            {
                getForma().cbGrupoConciliacion.Items.Add(grupo.denominacion);
            }
            indexSeleccionado = (grupoConsiliaciones.Count > 0 && indexSeleccionado != -1) ? indexSeleccionado : 0;
            grupoConsiliacionSeleccionado = grupoConsiliaciones[indexSeleccionado];
            getForma().cbGrupoConciliacion.SelectedIndex = indexSeleccionado;

        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {               
                int indexSeleccionado = complejos.FindIndex(c => c.denominacion.Value == getForma().cbComplejos.Text);
                complejoSeleccionado = (indexSeleccionado != -1) ? complejos[indexSeleccionado] : null;
                if (grupoConsiliaciones == null) llenarComboGrupoConciliaciones();
                indexSeleccionado = grupoConsiliaciones.FindIndex(g => g.denominacion.Value == getForma().cbGrupoConciliacion.Text);
                grupoConsiliacionSeleccionado = (indexSeleccionado != -1) ? grupoConsiliaciones[indexSeleccionado] : null;
                llenarListadoConciliaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
        private void llenarListadoConciliaciones()
        {
            getForma().lwConciliaciones.Items.Clear();
            conciliacionSeleccionada = null;
            conciliaciones = new ConciliacionLDB().getByComplejoAndGrupo(complejoSeleccionado.getId(), grupoConsiliacionSeleccionado.getId());

            int pos = 0;
            foreach(Conciliacion conciliacion in conciliaciones)
            {              
                ListViewItem item = new ListViewItem(conciliacion.fechaInicio.getAsStringDMY());
                item.SubItems.Add(conciliacion.fechaFin.getAsStringDMY());
                item.SubItems.Add(conciliacion.saldoVenta.getMoneyFormated());
                item.SubItems.Add(conciliacion.saldoDeclarado.getMoneyFormated());
                item.SubItems.Add(conciliacion.diferenciaSaldo.getMoneyFormated());
                item.SubItems.Add(conciliacion.saldoComision.getMoneyFormated());
                item.SubItems.Add(conciliacion.comisionDeclarada.getMoneyFormated());
                item.SubItems.Add(conciliacion.diferenciaComision.getMoneyFormated());
                item.SubItems.Add(conciliacion.documento.Value);
                getForma().lwConciliaciones.Items.Add(session.temaAplication.inicializarListViewItem(item, pos++));
            }
        }
        private void lwConciliaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conciliacionSeleccionada = (getForma().lwConciliaciones.SelectedIndices.Count > 0) ? conciliaciones[getForma().lwConciliaciones.SelectedIndices[0]] : null;
                if (conciliacionSeleccionada != null)
                {
                    getForma().panelDetails.Visible = true;
                    getForma().btnModificarConciliacion.Enabled = true;
                    getForma().lwParteVenta.Items.Clear();
                    List<ParteVentaDiario> partes = conciliacionSeleccionada.partesVentas;
                    for (int i = 0; i < partes.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(partes[i].fecha.getAsStringDMY());
                        item.SubItems.Add(partes[i].formaPago.Objeto.denominacion.Value);
                        item.SubItems.Add(conciliacionSeleccionada.complejo.Objeto.tiendas.Find(t=> t.id.Value == partes[i].idTienda.Value).denominacion.Value);
                        item.SubItems.Add(partes[i].saldo.getMoneyFormated());
                        item.SubItems.Add(partes[i].comision.getMoneyFormated());
                        getForma().lwParteVenta.Items.Add(session.temaAplication.inicializarSubListViewItem(item, i));
                    }
                    ListViewItem itemTotal = new ListViewItem("Total");
                    itemTotal.SubItems.Add("");
                    itemTotal.SubItems.Add("");
                    itemTotal.SubItems.Add(conciliacionSeleccionada.saldoDeclarado.getMoneyFormated());
                    itemTotal.SubItems.Add(conciliacionSeleccionada.comisionDeclarada.getMoneyFormated());
                    getForma().lwParteVenta.Items.Add(session.temaAplication.inicializarListViewItemTotal(itemTotal));
                }
                else
                {
                    getForma().panelDetails.Visible = false;
                    getForma().btnModificarConciliacion.Enabled = false;
                }
            }
            catch
            {
                conciliacionSeleccionada = null;
                getForma().panelDetails.Visible = false;
            }
        }       
        private void btnNuevaConciliacion_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaProximaConciliacion = session.fechaProximaConciliacion(grupoConsiliacionSeleccionado, complejoSeleccionado);
                Conciliacion conciliacion= new Conciliacion(session.getTokenId(), fechaProximaConciliacion);
                AdicionarConciliacionUIController conciliacionUI = new AdicionarConciliacionUIController(session, complejoSeleccionado, grupoConsiliacionSeleccionado, conciliacion);
                DialogResult result = conciliacionUI.Ejecutar().ShowDialog();
                if (result == DialogResult.OK)
                {
                    //session.actualizarListadoTiendas();
                    restablecerFormulario();
                }
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
                ModificarConciliacionUIController modificarFormController = new ModificarConciliacionUIController(session, complejoSeleccionado, grupoConsiliacionSeleccionado, conciliacionSeleccionada);
                DialogResult result = modificarFormController.Ejecutar().ShowDialog();
                if (result == DialogResult.OK)
                {
                    Conciliacion concialicionSeleccionadaSalva = conciliacionSeleccionada;
                    //session.actualizarListadoTiendas();
                    restablecerFormulario();
                    reseleccionarConciliacion(concialicionSeleccionadaSalva);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      
        public GestionarConciliacionUI getForma()
        {
            return forma as GestionarConciliacionUI;
        }
        private void reseleccionarConciliacion(Conciliacion conciliacionMarcada)
        {           
            int index = conciliaciones.FindIndex(t => t.getId() == conciliacionMarcada.getId());
            getForma().lwConciliaciones.Items[index].Selected = true;
        }
    }   
}
