using ExternalSystem.Service;
using ExternalSystem.UI;
using ExternalSystem.UIController;
using System;
using System.Windows.Forms;

namespace ExternalSystem.LocalService
{
    internal class ExternalSystemService
    {       
        private readonly ApiRestService apiRestService;       

        public ExternalSystemService()
        {         
            apiRestService = new ApiRestService();
        }          

        internal Form gestionarApiRest()
        {
            try
            {
                var apiRestUI = new ApiRestUI();
                var apiRestController = new ApiRestController(apiRestService, apiRestUI);
                return apiRestController.ejecutar();
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
