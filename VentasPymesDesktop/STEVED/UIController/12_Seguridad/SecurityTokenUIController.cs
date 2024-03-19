using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;


namespace NucleoEV.UIController
{
    internal class SecurityTokenUIController
    {
        protected SecurityTokenUI forma = new SecurityTokenUI();
        bool dialogResultOk;
        protected bool formularioModoModificar;
        public  SecurityToken securityToken { get; set; }        
       
        protected List<Complejo> complejos;
        protected List<GrupoConciliacion> gruposConsiliaciones;
        protected Session session;

        public SecurityTokenUIController(Session session, SecurityToken securityToken)
        {
            try
            {
                this.session = session;
                this.securityToken = securityToken;
                this.dialogResultOk = false;
              
                this.complejos = ComplejoData.getByComplejosAutorizadosInSessionToken();
                this.gruposConsiliaciones = GrupoConsiliacionData.getGrupoConsiliacionAutorizadosInSessionToken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        public virtual SecurityTokenUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);           
            return forma;
        }

        void forma_Load(object sender, EventArgs e)
        {         
            aplicarTema();          
            restablecerFormulario();            
        }

        protected virtual void aplicarTema()
        {
            //session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal); 
            //session.temaAplication.inicializarFormDialog(ref forma);
            //session.temaAplication.inicializarListView(ref forma.lwComplejo);
            //session.temaAplication.inicializarListView(ref forma.lwPermiso);
            //session.temaAplication.inicializarListView(ref forma.lwGrupoConciliacion);
        }
        protected virtual void restablecerFormulario()
        {
            //forma.tbToken.Text = securityToken.token.Value;            
            LlenarListadoPermisos();
            LlenarListadoComplejos();
            LlenarListadoGrupoConsiliacion();
        }       
        private void LlenarListadoPermisos()
        {
            forma.lwPermiso.Items.Clear();            
            //for (int i = 0; i < permisos.Count; i++)
            //{
            //    ListViewItem item = new ListViewItem();   
            //    item.Text = permisos[i].getId().ToString();
            //    item.SubItems.Add(permisos[i].denominacion.Value);    
            //    forma.lwPermiso.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            //}
        }
        private void LlenarListadoComplejos()
        {
            forma.lwComplejo.Items.Clear();           
            for (int i = 0; i < complejos.Count; i++)
            {
                ListViewItem item = new ListViewItem();              
                //item.Text = complejos[i].id.ToString();
                //item.SubItems.Add(complejos[i].denominacion.Value);              
                forma.lwComplejo.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            }
        }
        private void LlenarListadoGrupoConsiliacion()
        {
            forma.lwGrupoConciliacion.Items.Clear();
            for (int i = 0; i < gruposConsiliaciones.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                //item.Text = gruposConsiliaciones[i].id.ToString();
                //item.SubItems.Add(gruposConsiliaciones[i].denominacion.Value);
                forma.lwGrupoConciliacion.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.DialogResult = (dialogResultOk && formularioModoModificar) ? DialogResult.OK : DialogResult.Cancel;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        protected bool actualizarSecurityTokenDesdeFormulario()
        {
            try
            {   
                //securityToken.denominacion.Value = forma.tbDenominacion.Text;
               

                List<string> list = new List<string>();
                for (int i = 0; i < forma.lwComplejo.Items.Count; i++)
                {
                    if (forma.lwComplejo.Items[i].Checked)
                    {
                        //list.Add(complejos[i].getId());
                       
                    }
                }
                //securityToken.complejos.Value = String.Join(",",list);

                list = new List<string>();
                for (int i = 0; i < forma.lwPermiso.Items.Count; i++)
                {                    
                    if (forma.lwPermiso.Items[i].Checked)
                    {
                        //list.Add(permisos[i].getId());
                    }
                }
                //securityToken.permisos.Value = String.Join(",", list);

                list = new List<string>();
                for (int i = 0; i < forma.lwGrupoConciliacion.Items.Count; i++)
                {
                    if (forma.lwGrupoConciliacion.Items[i].Checked)
                    {
                        list.Add(forma.lwGrupoConciliacion.Items[i].Text);
                    }
                }
                //securityToken.gruposConciliacion.Value = String.Join(",", list);
                //dialogResultOk = true;
                //return securityToken.validar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        protected void cerrarFormulario()
        {           
            forma.DialogResult= DialogResult.OK;
            forma.Close();
        }
    }
}
