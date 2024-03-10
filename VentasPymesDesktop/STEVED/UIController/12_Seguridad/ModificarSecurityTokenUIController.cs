using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData.Service.RemotoDatabaseClient;
using ModelData;

namespace NucleoEV.UIController
{
    internal class ModificarSecurityTokenUIController : SecurityTokenUIController
    {       
        public ModificarSecurityTokenUIController(Session session, SecurityToken securityToken) : base(session, securityToken)
        {
            formularioModoModificar = true;
        }      

        public override SecurityTokenUI Ejecutar()
        {
            base.Ejecutar();           
            base.forma.btnGuardar.Click += new EventHandler(btnModificar_Click);           
            return forma;
        }
      
        protected override void restablecerFormulario()
        {
            base.restablecerFormulario();
            base.forma.Text = "Modificar security token";
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);
            forma.btnGuardar.Text = "Modificar";
            base.forma.tbDenominacion.Text = securityToken.denominacion.Value;
            seleccionarComplejos();
            seleccionarPermisos();
            seleccionarGruposConsiliacion();
        }

        private void seleccionarComplejos()
        {
            List<string> complejoList = securityToken.getIdComplejos();
            for (int i = 0; i < complejoList.Count; i++)
            {
                forma.lwComplejo.Items[complejos.FindIndex(x => x.getId() == complejoList[i])].Checked = true;               
            }
        }

        private void seleccionarPermisos()
        {
            List<string> permisoList = securityToken.getIdPermisos();
            for (int i = 0; i < permisoList.Count; i++)
            {
                forma.lwPermiso.Items[permisos.FindIndex(x => x.getId() == permisoList[i])].Checked = true;
            }
        }
        private void seleccionarGruposConsiliacion()
        {
            List<string> grupos = securityToken.getIdGrupoConsiliaciones();
            for (int i = 0; i < grupos.Count; i++)
            {
                int index = gruposConsiliaciones.FindIndex(x => x.getId() == grupos[i]);
                if(index>=0)
                    forma.lwGrupoConciliacion.Items[gruposConsiliaciones.FindIndex(x => x.getId() == grupos[i])].Checked = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarSecurityTokenDesdeFormulario();
                if (validacion)
                {
                    securityToken.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                    new SecurityTokenRDB().actualizarToken(securityToken);
                    new MensajeBox().modificacionOk();
                    cerrarFormulario();
                }
                else
                {
                    new MensajeBox().validacionFail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
