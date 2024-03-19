using System;
using ExternalSystem.Model;

namespace ExternalSystem.Service
{
    public class ApiRestService
    {
        public ApiRest apiRest { get; set; }
        private readonly FicheroService<ApiRest> ficheroService;
        public ApiRestService(FicheroService<ApiRest> ficheroService, ApiRest apiRest)
        {
            this.ficheroService = ficheroService;
            this.apiRest = apiRest;                     
        }

        public void CargarConfiguracionApiRest()
        {
            try
            {
                apiRest = ficheroService.AbrirFichero();
                if (apiRest == null) apiRest = new ApiRest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ProbarApiRest(ApiRest apiRest)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarApiRest()
        {
            try
            {
                ficheroService.GuardarFichero(apiRest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
