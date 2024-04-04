using System;
using System.Net;
using System.Threading.Tasks;
using MyUI.Enum.Message;
using MyUI.Service;

namespace MyUI.UIControler
{  
    internal class DemoUIController
    {
        private Form1 frm;       

        public DemoUIController()
        {           
            frm = new Form1();            
        }

        public Form1 ejecutar()
        {     
            frm.iconButtonProgressBar.Click += new EventHandler(btnAceptar_Click);
            return frm;
        }

        public async void btnAceptar_Click(object sender, EventArgs e)
        {            
           var progressBarService = new ProgressBarService(TextMensaje.PROGRESSBAR_TESTING);
            try
            {
                await progressBarService.run(() => mostrarProgress());
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }       

        private Task<bool> mostrarProgress()
        {           
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12345");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())                             
                return Task.FromResult(true);
            }
            catch 
            {                        
                return Task.FromResult(false);
            }
        }
    }
}
