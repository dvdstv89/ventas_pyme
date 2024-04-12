using System.Net;
using ventasPymesClient.Client;

namespace ventasPymesClient.Service
{
    public class SecurityTokenService : BaseService
    {
        private readonly SecurityTokenClient securityTokenClient;    
      
        public SecurityTokenService()
        {
            this.securityTokenClient = new SecurityTokenClient();
        }       

        public async Task<bool> UpdateSecurityTokenFunctionalitiesByTokenSelectedAsync()
        {
            try
            {
                HttpWebRequest request = securityTokenClient.endPointStatusServer();
                var json = await getJsonResponseFromGetEnpointAsync(request);
                mappingFromJson<bool>(json);

                //en este punto lo conexion esta de maravilla   
                //todo buscar los permisos  updateSecurityToken()
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
