using ExternalSystem.Model;
using ExternalSystem.UI;
using ExternalSystem.UIController;
using System.Text;
using System.Windows.Forms;

namespace ExternalSystem.Service
{
    public class ExternalSystemService
    {
        private ApiRest apiRest;
        private readonly FicheroService<ApiRest> ficheroService;
        private readonly ApiRestService apiRestService;

        public ExternalSystemService()
        {
            this.apiRest = new ApiRest();
            ficheroService = new FicheroService<ApiRest>();
            apiRestService = new ApiRestService(ficheroService, apiRest);
            apiRestService.CargarConfiguracionApiRest();
        }

        public void gestionarExternalApiRest()
        {            
            gestionarrApiRest().ShowDialog();
        }

        internal Form gestionarrApiRest()
        {  
            var apiRestUI = new ApiRestUI();
            var apiRestController = new ApiRestController(apiRestService, apiRestUI);
            return apiRestController.ejecutar();
        }

        public string getApiRestConection(string restPoint)
        {
            StringBuilder builder= new StringBuilder();
            builder.Append(apiRest.uri).Append(restPoint).Append(apiRest.token);
            return builder.ToString();
        }
    }
}
