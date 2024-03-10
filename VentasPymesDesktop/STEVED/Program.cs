using NucleoEV.Controller;
using NucleoEV.Model;
using NucleoEV.UIController;
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
            bool allReady = MyInstaller.Service.InstallerService.InstallSystem();
            if (allReady)
            {
                // loguin
            }


            //Application.Run(form.Ejecutar());

/*
            //CultureInfo cultureInfo = new CultureInfo("es-ES");
            CultureInfo cultureInfo = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            MainUIController form;
            do
            {
                ProgressBarUIController progressBar = new ProgressBarUIController("Cargando datos ...");
                progressBar.MostrarProgresoCircular();               
                form = new MainUIController(new Session(cultureInfo));
                progressBar.Close();
                Application.Run(form.Ejecutar());
            } while (form.reiniciarAplicacionPorModificacionEnToken);
*/
        }     
    }

}
