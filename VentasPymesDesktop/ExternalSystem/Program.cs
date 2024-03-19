using ExternalSystem.Service;
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
            Application.Run(new ExternalSystemService().gestionarrApiRest());
        }
    }
}
