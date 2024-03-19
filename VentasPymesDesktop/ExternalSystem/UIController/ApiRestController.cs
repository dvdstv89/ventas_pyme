using System;
using ExternalSystem.UI;
using MyUI.Service;
using ExternalSystem.Service;
using ExternalSystem.Model;
using MyUI.UIControler;
using MyUI.Factories;
using MyUI.Enum.Message;
using ExternalSystem.Enum.Message;

namespace ExternalSystem.UIController
{
    public class ApiRestController : BaseUIController<ApiRestUI>
    {
        ApiRestService apiRestService;        
        public bool isValidado { get; set; }
        public ApiRestController(ApiRestService apiRestService, ApiRestUI apiRestUI) : base(apiRestUI)
        {
            this.apiRestService = apiRestService;              
            this.isValidado = false;         
        }
        public ApiRestUI ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btCancelar.Click += new EventHandler(btnCancelar_Click);
            forma.btProbar.Click += new EventHandler(btnProbar_Click);
            forma.btGuardar.Click += new EventHandler(btnGuardar_Click);
            return forma;
        }
        public override void forma_Load(object sender, EventArgs e)
        {
            base.forma_Load(sender, e);
        }
        public override void aplicarTema()
        {
            ButtonIconStyleFactory.GUARDAR(forma.btGuardar);
            ButtonIconStyleFactory.CANCELAR(forma.btCancelar);
            ButtonIconStyleFactory.PROBAR(forma.btProbar);
           

            LabelStyleFactory.Label_FORM(forma.labelToken, TextMensaje.TOKEN);
            LabelStyleFactory.Label_FORM(forma.labelUrl, TextMensaje.URL);

            TextBoxStyleFactory.TEXT(forma.tbToken);
            TextBoxStyleFactory.TEXT(forma.tbUrl);
            FormularioStyleFactory.WINDOWS_FORM(this.forma, TextMensajeExternalSystem.API_REST_CONFIG);
        }
        public override void initDataForm()
        {   
            forma.btGuardar.Enabled= false;
            forma.tbToken.Text = apiRestService.apiRest.token;           
            forma.tbUrl.Text = apiRestService.apiRest.uri;
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(apiRestService.apiRest);
                apiRestService.GuardarApiRest();
                forma.Close();
               
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
        public void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {               
                ApiRest prueba = new ApiRest();
                capturarDatos(prueba);
                isValidado = apiRestService.ProbarApiRest(prueba);
                if (isValidado) forma.btGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
        public new void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                isValidado = false;
                forma.Close(); 
                return;
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
        private void capturarDatos(ApiRest apiRestDestino)
        {
            apiRestDestino.token = forma.tbToken.Text;
            apiRestDestino.uri = forma.tbUrl.Text;
        }
    }
}
