using System;
using System.Net;
using System.Text;
using ventasPymesClient.Dto;
using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Client
{
    internal abstract class BaseClient
    {
        private string controllerName;
        protected readonly static string EmptyString = String.Empty;
        private readonly ServerRestInfoToSaveDTO apiRest;
        private readonly SecurityTokenDTO securityToken;

        public BaseClient(string controllerName)
        {
            this.controllerName = controllerName;
            this.apiRest = VentasPymesClientMetadata.serverRestInfo;
            this.securityToken = VentasPymesClientMetadata.securityToken;
        }
        public BaseClient(string controllerName, ServerRestInfoToSaveDTO apiRest)
        {
            this.controllerName = controllerName;
            this.apiRest = apiRest;
            this.securityToken = VentasPymesClientMetadata.securityToken;
        }      

        protected HttpWebRequest getApiRestConectionWithSecurity(string restPoint, Funcionalidad funcionalidad)
        {
            try
            {
                chekHasPermission(funcionalidad);               
                return getApiRestConection(restPoint) ;
            }
            catch (Exception)
            {
                throw;
            }
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
                if (!restPoint.Equals(EmptyString))
                    builder.Append(restPoint);
                if (!apiRest.token.Equals(EmptyString))
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

        private void chekHasPermission(Funcionalidad funcionalidad)
        {
            try
            {
                if (!securityToken.existFunctionality(funcionalidad))
                    throw new Exception("El usuario no tiene permiso para acceder a la funcionalidad " + funcionalidad.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
