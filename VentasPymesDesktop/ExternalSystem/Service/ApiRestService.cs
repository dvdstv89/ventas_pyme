using System;
using System.Threading.Tasks;
using ExternalSystem.LocalService;
using MyUI.Service;
using ventasPymesClient;
using ventasPymesClient.Dto;
using ventasPymesClient.Service;

namespace ExternalSystem.Service
{
    public class ApiRestService
    {            
        private readonly FicheroService<ServerRestInfoToSaveDTO> ficheroService;
        private readonly StatusService statusService;       
        private readonly TaskManagerService taskManagerService;

        public ApiRestService(FicheroService<ServerRestInfoToSaveDTO> ficheroService, TaskManagerService taskManagerService)
        {
            this.ficheroService = ficheroService;
            this.taskManagerService = taskManagerService;
            this.statusService = new StatusService();           
        }

        internal async Task<bool> ProbarApiRest(ServerRestInfoToSaveDTO apiRestToTest)
        {            
            try
            {
                StatusService statusServiceTest = new StatusService(apiRestToTest);
                taskManagerService.EjecutarServidorApiRest();
                var progressBarService = new ProgressBarService(MyUI.Enum.Message.TextMensaje.CHECK_CONEXION);
                return await progressBarService.start(() => statusServiceTest.getStatusAsync());
            }
            catch (Exception) { throw; }
        }

        internal async Task<bool> AutoProbarApiRest()
        {         
            try
            {
                taskManagerService.EjecutarServidorApiRest();
                var progressBarService = new ProgressBarService(MyUI.Enum.Message.TextMensaje.CHECK_CONEXION);
                return await progressBarService.start(() => statusService.getStatusAsync());
            }
            catch (Exception) { throw; }
        }

        internal void GuardarApiRest()
        {
            try
            {
                ficheroService.GuardarFichero(VentasPymesClientMetadata.serverRestInfo);
            }
            catch (Exception) { throw; }
        }       
    }
}
