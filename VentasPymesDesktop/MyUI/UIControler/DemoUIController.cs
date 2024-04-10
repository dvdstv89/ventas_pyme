using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUI.Enum.Message;
using MyUI.Service;

namespace MyUI.UIControler
{  
    internal class DemoUIController : BaseUIController<Form1>
    {   
        public DemoUIController():base(new Form1())
        {           
                   
        }

        protected override Form1 ejecutar()
        {     
            forma.iconButtonProgressBar.Click += new EventHandler(btnAceptar_Click);
            return base.ejecutar();
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

        public Form mostrarFormulario()
        {
            showDialog();
            return null;
        }
    }
}
