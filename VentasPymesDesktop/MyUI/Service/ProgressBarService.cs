using MyUI.Model;
using MyUI.UIControler;

namespace MyUI.Service
{
    public class ProgressBarService
    {
        ProgressBarUIController progressBar;      

        public ProgressBarService(MensajeText mensaje)
        {
            progressBar = new ProgressBarUIController(mensaje);
        }

        public void start()
        {            
            progressBar.Start();
        }

        public void stop()
        {
            progressBar.Stop();
        }
    }
}
