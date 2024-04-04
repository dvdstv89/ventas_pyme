using System;
using System.Threading.Tasks;
using ExternalSystem.Fichero;
using ExternalSystem.LocalService;
using ventasPymesClient;
using ventasPymesClient.Dto;
using ventasPymesClient.Service;

namespace ExternalSystem.Service
{
    public class ApiRestService : BaseService
    {            
        private readonly FicheroService<ServerRestInfoToSaveDTO> ficheroService;       

        public ApiRestService()
        {
            this.ficheroService = new FicheroService<ServerRestInfoToSaveDTO>();            
            VentasPymesClientMetadata.initMetadata(ficheroService.AbrirFichero());
        }

        internal async Task<bool> ProbarApiRest(ServerRestInfoToSaveDTO apiRestToTest)
        {            
            try
            {      
                new TaskManagerService(apiRestToTest).EjecutarServidorApiRest();
                var statusService = new StatusService(apiRestToTest);
                return await ejecutarEndpoint<bool>(MyUI.Enum.Message.TextMensaje.CHECK_CONEXION, () => statusService.getStatusAsync());
            }
            catch (Exception) { throw; }
        } 

        internal FileSaveResult GuardarApiRest()
        {
            try
            {
                return ficheroService.GuardarFichero(VentasPymesClientMetadata.serverRestInfo);
            }
            catch (Exception) { throw; }
        }       
    }
}
