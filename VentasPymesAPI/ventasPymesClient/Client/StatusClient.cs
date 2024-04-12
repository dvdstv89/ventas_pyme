using System.Net;
using ventasPymesClient.Dto;

namespace ventasPymesClient.Client
{
    internal class StatusClient: BaseClient
    {        
        private readonly static string API_URL = "/api/Status";

        public StatusClient() : base(API_URL)  {  }

        public StatusClient(ServerRestInfoToSaveDTO apiRestToTest) : base(API_URL, apiRestToTest) { }

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
