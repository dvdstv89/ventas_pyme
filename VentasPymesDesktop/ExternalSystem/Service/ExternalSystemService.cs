using ExternalSystem.LocalService;
using ExternalSystem.UI;
using ExternalSystem.UIController;
using MyUI.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventasPymesClient;
using ventasPymesClient.Dto;
using ventasPymesClient.Service;

namespace ExternalSystem.Service
{
    public class ExternalSystemService
    {
        private readonly FicheroService<ServerRestInfoToSaveDTO> ficheroService;
        private readonly ApiRestService apiRestService;
        private readonly TaskManagerService taskManagerService;

        public ExternalSystemService()
        {
            ficheroService = new FicheroService<ServerRestInfoToSaveDTO>();
            ServerRestInfoToSaveDTO serverRestInfo = ficheroService.AbrirFichero();
            taskManagerService = new TaskManagerService(serverRestInfo);
            apiRestService = new ApiRestService(ficheroService, taskManagerService);
        }

        public async Task<bool> probarServicioRestAsync()
        {
            try
            {
                return await apiRestService.AutoProbarApiRest();
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
                return false;
            }       
        }

        public bool verificarFicheroConfiguracion()
        {
            try
            {
                if (!VentasPymesClientMetadata.serverRestInfo.apiRestHasInformation())
                {                   
                    return gestionarExternalApiRest();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        private bool gestionarExternalApiRest()
        {
            try
            {
                DialogResult dialogResult = gestionarApiRest().ShowDialog();
                return dialogResult == DialogResult.OK;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Form gestionarApiRest()
        {
            try
            {
                var apiRestUI = new ApiRestUI();
                var apiRestController = new ApiRestController(apiRestService, apiRestUI);
                return apiRestController.ejecutar();
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
