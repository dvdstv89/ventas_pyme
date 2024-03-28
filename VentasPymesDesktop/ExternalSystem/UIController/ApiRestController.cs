using System;
using ExternalSystem.UI;
using MyUI.Service;
using ExternalSystem.Service;
using MyUI.UIControler;
using MyUI.Factories;
using ventasPymesClient.Dto;
using ventasPymesClient;
using ventasPymesClient.Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExternalSystem.UIController
{
    public class ApiRestController : BaseUIController<ApiRestUI>
    {
        readonly ApiRestService apiRestService;        
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
        protected override void forma_Load(object sender, EventArgs e)
        {
            base.forma_Load(sender, e);
        }
        protected override void aplicarTema()
        {
            ButtonIconStyleFactory.GUARDAR(forma.btGuardar);
            ButtonIconStyleFactory.CANCELAR(forma.btCancelar);
            ButtonIconStyleFactory.PROBAR(forma.btProbar);

            LabelStyleFactory.Label_FORM(forma.labelProtocolo, MyUI.Enum.Message.TextMensaje.SERVIDOR);
            LabelStyleFactory.Label_FORM_CHARACTER(forma.labelHost, MyUI.Enum.Message.TextMensaje.BACKSLAPSH);
            LabelStyleFactory.Label_FORM_CHARACTER(forma.labelPuerto, MyUI.Enum.Message.TextMensaje.TWO_POINTS);
            LabelStyleFactory.Label_FORM(forma.labelToken, MyUI.Enum.Message.TextMensaje.TOKEN);
          
           

            TextBoxStyleFactory.TEXT(forma.tbToken);
            TextBoxStyleFactory.TEXT(forma.tbHost);
            List<string> protocolos = new List<string>();
            protocolos.Add(Protocol.HTTP.ToString());
            protocolos.Add(Protocol.HTTPS.ToString());
            ComboBoxStyleFactory.LIST(forma.cbProtocolo, protocolos);
            TextBoxStyleFactory.MULTILINE(forma.tbRutaBackend);
            CheckBoxStyleFactory.NORMAL(forma.cbCheckApi,MyUI.Enum.Message.TextMensaje.CHECK_API.ToString());

            FormularioStyleFactory.WINDOWS_FORM(this.forma, Message.TextMensaje.API_REST_CONFIG);
        }
        public override void initDataForm()
        {            
            forma.btGuardar.Enabled= false;
            forma.tbToken.Text = VentasPymesClientMetadata.serverRestInfo.token;
            forma.tbHost.Text = VentasPymesClientMetadata.serverRestInfo.host;
            forma.tbPuerto.Text = VentasPymesClientMetadata.serverRestInfo.port.ToString();
            forma.tbRutaBackend.Text = VentasPymesClientMetadata.serverRestInfo.rutaBackend;
            forma.cbProtocolo.Text = VentasPymesClientMetadata.serverRestInfo.protocol.ToString();
            forma.cbCheckApi.Checked = VentasPymesClientMetadata.serverRestInfo.checkApi;
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(VentasPymesClientMetadata.serverRestInfo);
                apiRestService.GuardarApiRest();
                forma.Close();
                forma.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
        public async void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                this.isValidado = false;
                ServerRestInfoToSaveDTO prueba = new ServerRestInfoToSaveDTO();
                capturarDatos(prueba);                  
                forma.btGuardar.Enabled = await apiRestService.ProbarApiRest(prueba); ;
                DialogService.SUCCESS(Message.TextMensaje.API_REST_TEST_OK);
            }
            catch (Exception ex)
            {
                forma.btGuardar.Enabled = false;
                DialogService.EXCEPTION(ex.Message);
            }
        }
        public new void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                isValidado = false;
                forma.Close();
                forma.DialogResult = DialogResult.Cancel;                
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
        private void capturarDatos(ServerRestInfoToSaveDTO apiRestDestino)
        {
            try
            {
                apiRestDestino.token = forma.tbToken.Text;
                apiRestDestino.protocol = forma.cbProtocolo.Text == Protocol.HTTP.ToString() ? Protocol.HTTP : Protocol.HTTPS;
                apiRestDestino.port = ((int)forma.tbPuerto.Value);
                apiRestDestino.host = forma.tbHost.Text;
                apiRestDestino.rutaBackend = forma.tbRutaBackend.Text;
                apiRestDestino.checkApi = forma.cbCheckApi.Checked;
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
