using ExternalSystem.Service;
using MyUI.Service;
using NucleoEV.Model;
using NucleoEV.Service;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace NucleoEV
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            CultureInfo cultureInfo = new CultureInfo("es-ES");           
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);  

            try
            {
                Session session = new Session(cultureInfo);
                AppService appService = new AppService(session);
                Application.Run(appService.ejecutarApp());
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }     
    }

}
