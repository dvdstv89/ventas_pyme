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
        static void Main(string[] args)
        {
            CultureInfo cultureInfo = new CultureInfo("es-ES");           
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            AppService appService = new AppService(cultureInfo);
            Application.Run(appService.ejecutarApp());                       
        }     
    }

}
