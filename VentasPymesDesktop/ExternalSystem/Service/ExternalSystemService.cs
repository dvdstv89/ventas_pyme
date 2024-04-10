using ExternalSystem.Fichero;
using ExternalSystem.Message;
using ExternalSystem.UI;
using ExternalSystem.UIController;
using MyUI.Service;
using System;
using System.Threading.Tasks;
using ventasPymesClient;

namespace ExternalSystem.Service
{
    public class ExternalSystemService
    {       
        private readonly ApiRestService apiRestService;        

        public ExternalSystemService()
        {           
            apiRestService = new ApiRestService();
        }       

        public async Task<FileSaveResult> verificarFicheroConfiguracionAsync()
        {
            try
            {
                return !VentasPymesClientMetadata.serverRestInfo.apiRestHasInformation() ? await gestionarExternalApiRestAsync() : FileSaveResult.SKIP;               
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public async Task<bool> probarServicioRestAsync()
        {           
            try
            {          
                return await apiRestService.ProbarApiRest(ventasPymesClient.VentasPymesClientMetadata.serverRestInfo);

            }
            catch (Exception)
            {             
                return false;                
            }                   
        }

        public async Task<FileSaveResult> TryRepairConexionAsync()
        {
            try
            {
                return DialogService.CONFIRMATION(TextMensaje.CONFIRMAR_CONFIGURAR_CONEXION_SERVIDOR) ? await gestionarExternalApiRestAsync() : FileSaveResult.ERROR;
            }
            catch (Exception)
            {
                throw;
            }                           
        }

        private async Task<FileSaveResult> gestionarExternalApiRestAsync()
        {
            try
            {
                var apiRestController = new ApiRestController(apiRestService, new ApiRestUI());
                apiRestController.showDialog();
                return apiRestController.ficheroCreado;
            }
            catch (Exception)
            {
                throw;               
            }
        }
    }
}
