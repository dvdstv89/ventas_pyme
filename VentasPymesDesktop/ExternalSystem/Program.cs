using ExternalSystem.LocalService;
using MyUI.Service;
using System;
using System.Windows.Forms;

namespace ExternalSystem
{
    internal static class Program
    {      
        [STAThread]
        static void Main()
        {                 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new ExternalSystemService().gestionarApiRest());
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
    }
}
