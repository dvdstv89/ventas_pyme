using System.Net;
using ventasPymesClient.Dto;
using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Client
{
    internal class SecurityTokenClient : BaseClient
    {        
        private readonly static string API_URL = "/api/SecurityToken";

        public SecurityTokenClient() : base(API_URL)  {  }

        public HttpWebRequest endPointStatusServer()
        {           
            try
            {                
                return base.getApiRestConection(EmptyString);
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
