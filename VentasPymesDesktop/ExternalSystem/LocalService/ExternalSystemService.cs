using ExternalSystem.Service;
using ExternalSystem.UI;
using ExternalSystem.UIController;
using System;
using System.Windows.Forms;
using ventasPymesClient.Dto;
using ventasPymesClient.Service;

namespace ExternalSystem.LocalService
{
    internal class ExternalSystemService
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

        internal Form gestionarApiRest()
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
