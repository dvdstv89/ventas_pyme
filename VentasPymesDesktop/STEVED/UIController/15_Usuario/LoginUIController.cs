using ModelData.Model;
using NucleoEV.UI;
using NucleoEV.Model;
using NucleoEV.Tema;
using System;
using System.Windows.Forms;
using ModelData.Service.RemotoDatabaseClient;
using ModelData.Service.LocalDatabaseClient;
using ModelData;

namespace NucleoEV.UIController
{
    internal class LoginUIController: BaseUIController, IController<LoginUI>
    {       
        MainUIController mainUI;
        public LoginUIController(Session session, MainUIController mainUI) :base(session, new LoginUI())
        {
            try
            {              
                this.mainUI = mainUI;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        public LoginUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);          
            getForma().btnCambiar.Click += new EventHandler(btnGuardar_Click);
            getForma().btnCancelar.Click += new EventHandler(btnCancelar_Click);
            return getForma();
        }

        void forma_Load(object sender, EventArgs e)
        {
            aplicarTema();
            getForma().tbToken.Text = VariablesEntorno.securityToken.token.Value; 
        }

        void aplicarTema()
        {            
            forma.Text = "Usuario";
            LoginUI login = getForma();
            session.temaAplication.inicializarFormDialog(ref login);
            session.temaAplication.inicializarBoton(ref getForma().btnCambiar, Tema.TipoBoton.Normal);
            session.temaAplication.inicializarBoton(ref getForma().btnCancelar, Tema.TipoBoton.Normal);
            if (mainUI.estaAbiertaLaAplicacion())
                forma.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }  

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {               
                string token = getForma().tbToken.Text;
                if(token == VariablesEntorno.securityToken.token.Value)
                {
                    return;
                }
                else
                {
                    SecurityToken securityToken = new SecurityTokenRDB().getByToken(token);
                    if(securityToken != null)
                    {                        
                        new SecurityTokenLDB().update(securityToken);
                        mainUI.reiniciarFormulario();                        
                    }
                    else
                    {
                        new MensajeBox().tokenNoExiste();
                        getForma().tbToken.Text=VariablesEntorno.securityToken.token.Value;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private new void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                mainUI.cerrarAplicacion();
                getForma().Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public LoginUI getForma()
        {
            return forma as LoginUI;
        }
    }   
}
