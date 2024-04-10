using System.Net;
using ventasPymesClient.Dto;

namespace ventasPymesClient.Client
{
    internal class StatusClient: BaseClient
    {
        private readonly string GetStatus = String.Empty;

        public StatusClient() : base("/api/Status")  {  }

        public StatusClient(ServerRestInfoToSaveDTO apiRestToTest) : base("/api/Status", apiRestToTest) { }

        public HttpWebRequest enpointStatusServer()
        {
            try
            {
                return base.getApiRestConection(GetStatus);
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
