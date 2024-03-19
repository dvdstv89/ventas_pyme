using NucleoEV.Model;
using NucleoEV.UIController;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MyUI.Enum.Message;

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
            MainUIController form;
            do
            {
                Session session = new Session(cultureInfo);
                ProgressBarUIController progressBar = new ProgressBarUIController(LabelText.PROGRESSBAR_CARGANDO);
                progressBar.MostrarProgresoCircular();               
                form = new MainUIController(session);
                progressBar.Close();
                Application.Run(form.Ejecutar());
            } while (form.reiniciarAplicacionPorModificacionEnToken);
        }     
    }

}
