using System.Net;
using ventasPymesClient.Client;
using ventasPymesClient.Dto;

namespace ventasPymesClient.Service
{
    public class StatusService : BaseService
    {
        private readonly StatusClient statusClient;      
        public StatusService() 
        {  
            this.statusClient = new StatusClient();
        }
        public StatusService(ServerRestInfoToSaveDTO apiRestToTest)
        {
            this.statusClient = new StatusClient(apiRestToTest);
        }


        public async Task<bool> getStatusAsync()
        {
            try
            {
                HttpWebRequest request = statusClient.enpointStatusServer();
                var json = await getJsonResponseFromGetEnpointAsync(request);  
                return mappingFromJson<bool>(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
