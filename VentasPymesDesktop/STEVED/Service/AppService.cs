using ExternalSystem.Service;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using System.Globalization;
using System.Threading.Tasks;
using MyUI.Service;
using NucleoEV.UIController;
using NucleoEV.UI;
using ExternalSystem.Fichero;

namespace NucleoEV.Service
{
    internal class AppService
    {
        internal FileSaveResult ficheroStatus { get; set; }
        Session session;       
        readonly ExternalSystemService externalSystem;
        readonly EmpresaService empresaService;
        readonly MainUIService mainUIService;
        readonly MainUIController mainUIController;
        private readonly MainUI mainUI;

        public AppService(CultureInfo cultureInfo)
        {
            ficheroStatus = FileSaveResult.SKIP;
           this.session = new Session(cultureInfo);
           this.externalSystem = new ExternalSystemService();              
           this.empresaService = new EmpresaService();

           this.mainUI = new MainUI();
           this.mainUIService = new MainUIService(session);
           this.mainUIController = new MainUIController(mainUIService, mainUI);
        }

        public Form ejecutarApp()
        {
            _ = ejecutarAppAsync().ConfigureAwait(false);
            return null;
        }

        private async Task ejecutarAppAsync()
        {
            try
            {
                ficheroStatus = await externalSystem.verificarFicheroConfiguracionAsync();               

                bool conexionEstablecida = await externalSystem.probarServicioRestAsync();
                if (!conexionEstablecida && ficheroStatus != FileSaveResult.CANCEL)
                {
                    conexionEstablecida = (await externalSystem.TryRepairConexionAsync() == FileSaveResult.OVERRIDED) ? true : false;
                }
                if (conexionEstablecida)
                {
                    empresaService.buscarEmpresa();
                    mainUIController.Ejecutar().ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);               
            }
            finally
            {
                Application.Exit();
            }
        }      
    }
}
