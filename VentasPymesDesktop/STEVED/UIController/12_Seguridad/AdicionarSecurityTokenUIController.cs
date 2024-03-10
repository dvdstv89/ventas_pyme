using ModelData.Model;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData.Service.RemotoDatabaseClient;
using ModelData;

namespace NucleoEV.UIController
{
    internal class AdicionarSecurityTokenUIController : SecurityTokenUIController
    {
        public AdicionarSecurityTokenUIController(Session session) : base(session, new SecurityToken(session.getTokenId()))
        {
            formularioModoModificar = false;
        }

        public override SecurityTokenUI Ejecutar()
        {
            base.Ejecutar();
            base.forma.btnGuardar.Click += new EventHandler(btnAdicionar_Click);
            return forma;
        }

        protected override void restablecerFormulario()
        {
            base.restablecerFormulario();
            session.temaAplication.inicializarBoton(ref forma.btnGuardar,TipoBoton.Normal);
            forma.btnGuardar.Text = "Adicionar";
            base.forma.Text = "Adicionar security token";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarSecurityTokenDesdeFormulario();
                if (validacion)
                {                    
                    new SecurityTokenRDB().insertarToken(securityToken);
                    new MensajeBox().creacionOk();
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
