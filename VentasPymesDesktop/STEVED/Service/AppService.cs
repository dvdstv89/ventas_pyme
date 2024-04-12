using ExternalSystem.Service;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using System.Globalization;
using System.Threading.Tasks;
using MyUI.Service;
using NucleoEV.UIController;
using ExternalSystem.Fichero;

namespace NucleoEV.Service
{
    internal class AppService
    {
        internal FileSaveResult ficheroStatus { get; set; }
        Session session;       
        readonly ExternalSystemService externalSystemService;       
        readonly MainUIService mainUIService;
        readonly MainUIController mainUIController;        

        public AppService(CultureInfo cultureInfo)
        {
           ficheroStatus = FileSaveResult.CANCEL;
           this.session = new Session(cultureInfo);
           this.externalSystemService = new ExternalSystemService();          
           this.mainUIService = new MainUIService(session);
           this.mainUIController = new MainUIController(mainUIService);
        }

        public Form ejecutarApp()
        {
            _ = ejecutarAppAsync().ConfigureAwait(true);          
            return null;
        }

        private async Task ejecutarAppAsync()
        {
            try
            { 
                ficheroStatus = await externalSystemService.verificarFicheroConfiguracionAsync();
                if (ficheroStatus == FileSaveResult.CANCEL)
                {
                    return;
                }
                bool conexionEstablecida =  await externalSystemService.probarServicioRestAsync();
                if (!conexionEstablecida && ficheroStatus != FileSaveResult.CANCEL)
                {
                    conexionEstablecida = (await externalSystemService.TryRepairConexionAsync() == FileSaveResult.OVERRIDED) ? true : false;
                }
                if (conexionEstablecida)
                {    
                    mainUIController.MostrarSelectorPyme();
                    mainUIController.showDialog();
                }
            }           
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);               
            }
            finally
            {               
                Environment.Exit(0);
            }
        }      
    }
}
