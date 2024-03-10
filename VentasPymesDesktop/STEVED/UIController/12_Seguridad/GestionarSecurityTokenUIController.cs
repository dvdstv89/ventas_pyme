using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData.Service.RemotoDatabaseClient;
using ModelData;
using LocalData.Atributo;
using LocalData.Model;

namespace NucleoEV.UIController
{
    internal class GestionarSecurityTokenUIController : BaseUIController, IController<GestionarSecurityTokenUI>
    {
        MainUIController mainUI;       
        List<SecurityToken> tokens;
        SecurityToken tokenSeleccionado= null;
        protected List<Permiso> permisos;
        protected List<Complejo> complejos;
        protected List<GrupoConciliacion> gruposConsiliacion;
        public GestionarSecurityTokenUIController(Session session, MainUIController mainUI) : base(session, new GestionarSecurityTokenUI())
        {
            try
            {            
                this.mainUI = mainUI;
                permisos = PermisoData.getPermisos();
                complejos = ComplejoData.getByComplejosAutorizadosInSessionToken();
                gruposConsiliacion = GrupoConsiliacionData.getGrupoConsiliacionAutorizadosInSessionToken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<SecurityToken> getSecurityTokens()
        {
            try
            {
                return new SecurityTokenRDB().getAllNotEliminated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<SecurityToken>();
            }
        }
        public GestionarSecurityTokenUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            getForma().lwToken.SelectedIndexChanged += new EventHandler(lwToken_SelectedIndexChanged);
            getForma().btnAdicionar.Click += new EventHandler(btnAdicionar_Click);
            getForma().btnModificar.Click += new EventHandler(btnModificar_Click);
            getForma().btnEliminar.Click += new EventHandler(btnEliminar_Click);
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {         
            aplicarTema();
            restablecerFormulario();           
        }
        void aplicarTema()
        {
            session.temaAplication.inicializarListView(ref getForma().lwToken);          
            forma.BackColor  = session.temaAplication.formularioBgColor();          
            session.temaAplication.inicializarToolStripButton(ref getForma().btnAdicionar, TipoToolStripButton.Adicionar);
            session.temaAplication.inicializarToolStripButton(ref getForma().btnModificar, TipoToolStripButton.Modificar);           
            session.temaAplication.inicializarToolStripButton(ref getForma().btnEliminar, TipoToolStripButton.Eliminar);
            getForma().panelDetails.BackColor = session.temaAplication.inicializarColor(TipoColor.PanelDetails);
            getForma().panelBanner.BackColor = new TemaAplication().inicializarColor(TipoColor.PanelBannerDetails);
            getForma().lbDetailsHeaderTitle.Font = new TemaAplication().inicializarTexto(TipoTexto.Title);
            getForma().lbDetailsHeaderTitle.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
        }
        void restablecerFormulario()
        {
            tokens = getSecurityTokens();
            LlenarListadoTokens();
            tokenSeleccionado = null;
            getForma().panelDetails.Visible = false;
            getForma().btnEliminar.Enabled= false;
            getForma().btnModificar.Enabled= false;
        }
        private void LlenarListadoTokens()
        {
            getForma().lwToken.Items.Clear();
            for (int i = 0; i < tokens.Count; i++)
            {
                ListViewItem item = new ListViewItem();  
                item.Text = tokens[i].token.Value;
                item.SubItems.Add(tokens[i].denominacion.Value);
                item.SubItems.Add(tokens[i].complejos.Value);
                item.SubItems.Add(tokens[i].permisos.Value);
                getForma().lwToken.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            }
        }          
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {               
                AdicionarSecurityTokenUIController adicionarFormController = new AdicionarSecurityTokenUIController(session);
                DialogResult result = adicionarFormController.Ejecutar().ShowDialog();
                if (result == DialogResult.OK)
                {                  
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
                ModificarSecurityTokenUIController modificarFormController = new ModificarSecurityTokenUIController(session, tokenSeleccionado);
                DialogResult result = modificarFormController.Ejecutar().ShowDialog();      
                if (result == DialogResult.OK)
                {
                    if (VariablesEntorno.securityToken.token.Value == tokenSeleccionado.token.Value)
                    {
                        mainUI.reiniciarFormulario();
                    }                   
                    restablecerFormulario();
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
                if (VariablesEntorno.securityToken.token.Value == tokenSeleccionado.token.Value)
                {
                    new MensajeBox().eliminacionFail();                  
                }
                else
                {
                    new SecurityTokenRDB().eliminarToken(tokenSeleccionado);
                    restablecerFormulario();
                    new MensajeBox().eliminacionOk();                   
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lwToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (getForma().lwToken.SelectedIndices.Count > 0)
                {
                    tokenSeleccionado = tokens[getForma().lwToken.SelectedIndices[0]];
                    getForma().btnEliminar.Enabled = (VariablesEntorno.securityToken.token.Value == tokenSeleccionado.token.Value || tokenSeleccionado.superadmin.Value) ? false : true;
                    getForma().btnModificar.Enabled = (VariablesEntorno.securityToken.token.Value == tokenSeleccionado.token.Value || tokenSeleccionado.superadmin.Value) ? false : true;
                   
                    getForma().panelDetails.Visible = true;
                    getForma().tbToken.Text = tokenSeleccionado.token.Value;
                    getForma().tbDenominacion.Text = tokenSeleccionado.denominacion.Value;
                    getForma().lbxComplejos.Text = String.Empty;
                    getForma().lbxPermisos.Text = String.Empty;
                    getForma().lbxGrupoConsiliacion.Text = String.Empty;

                    List<string> complejoList = tokenSeleccionado.getIdComplejos();
                    for (int i = 0; i < complejoList.Count; i++)
                    {
                        Complejo aux = complejos.Find(c => c.getId() == complejoList[i]);
                        if (getForma().lbxComplejos.Text != String.Empty)
                            getForma().lbxComplejos.Text += "\r\n";
                        getForma().lbxComplejos.Text += aux.denominacion;
                    }

                    List<string> permisoList = tokenSeleccionado.getIdPermisos();
                    for (int i = 0; i < permisoList.Count; i++)
                    {
                        Permiso aux = permisos.Find(c => c.getId() == permisoList[i]);
                        if (getForma().lbxPermisos.Text != String.Empty)
                            getForma().lbxPermisos.Text += "\r\n";
                        getForma().lbxPermisos.Text += aux.denominacion.Value;
                    }

                    List<string> gruposConsiliacionList = tokenSeleccionado.getIdGrupoConsiliaciones();
                    for (int i = 0; i < gruposConsiliacionList.Count; i++)
                    {
                        int index = gruposConsiliacion.FindIndex(c => c.getId() == gruposConsiliacionList[i]);
                        if (index >= 0)
                        {
                            if (getForma().lbxGrupoConsiliacion.Text != String.Empty)
                                getForma().lbxGrupoConsiliacion.Text += "\r\n";
                            getForma().lbxGrupoConsiliacion.Text += gruposConsiliacion[index].denominacion;
                        }
                    }
                }
                else
                {
                    tokenSeleccionado = null;
                    getForma().btnEliminar.Enabled = false;
                    getForma().btnModificar.Enabled = false;
                    getForma().panelDetails.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }              
        public GestionarSecurityTokenUI getForma()
        {
            return forma as GestionarSecurityTokenUI;
        }
    }
}
