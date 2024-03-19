using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUI.Factories;
using MyUI.Model;
using MyUI.UI;

namespace MyUI.UIControler
{  
    internal class ProgressBarUIController
    {             
        private bool isFormShown;
        private ProgressBarUI frm;
        private CancellationTokenSource cancellationTokenSource;
        private MensajeText mensaje;

        public ProgressBarUIController(MensajeText mensaje)
        {   
            this.isFormShown = false;            
            this.mensaje= mensaje;          
        }

        private void SetEstiloForm()
        {
            FormularioStyleFactory.PROGRESS_BAR(frm, mensaje);            
            LabelStyleFactory.Label_TITLE_MENSAJE(frm.lbEstado, mensaje);
            frm._progressBarCommand.Style = ProgressBarStyle.Marquee;
        }

        public void Start()
        {
            if (!isFormShown)
            {
                cancellationTokenSource = new CancellationTokenSource();
                Task.Run(() => ShowForm(), cancellationTokenSource.Token);
            }
            else
            {
                frm.Invoke((MethodInvoker)delegate
                {
                    frm.Show();
                });
            }
        }

        private void ShowForm()
        {
            if (!isFormShown)
            {
                frm = new ProgressBarUI();
                SetEstiloForm();
                frm.Load += (sender, e) =>
                {
                    frm.Show();
                };
                isFormShown = true;
                frm.ShowDialog();
                frm.Dispose();

                isFormShown = false;
            }
        }

        public void Stop()
        {
            if (isFormShown)
            {
                cancellationTokenSource?.Cancel();
                frm.Invoke((MethodInvoker)delegate
                {
                    frm.Close();
                });
                isFormShown = false;
            }
        }
    }
}
