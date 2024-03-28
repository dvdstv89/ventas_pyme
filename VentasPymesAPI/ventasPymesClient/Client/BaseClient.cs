using System;
using System.Net;
using System.Text;
using ventasPymesClient.Dto;
using ventasPymesClient.Model;

namespace ventasPymesClient.Client
{
    internal abstract class BaseClient
    {
        private string controllerName;
        private readonly ServerRestInfoToSaveDTO apiRest;

        public BaseClient(string controllerName)
        {
            this.controllerName = controllerName;
            this.apiRest = VentasPymesClientMetadata.serverRestInfo;
        }
        public BaseClient(string controllerName, ServerRestInfoToSaveDTO apiRest)
        {
            this.controllerName = controllerName;
            this.apiRest = apiRest;
        }

        protected HttpWebRequest getApiRestConection(string restPoint)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                string protocol = apiRest.protocol == Protocol.HTTP ? "http://" : "https://";
                builder.Append(protocol)
                    .Append(apiRest.host)
                    .Append(':')
                    .Append(apiRest.port)
                    .Append(controllerName);
                if (!restPoint.Equals(String.Empty))
                    builder.Append(restPoint);
                if (!apiRest.token.Equals(String.Empty))
                    builder.Append(apiRest.token);
                return createUri(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private HttpWebRequest createUri(string uri)
        {
            try
            {
                return (HttpWebRequest)WebRequest.Create(uri);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
