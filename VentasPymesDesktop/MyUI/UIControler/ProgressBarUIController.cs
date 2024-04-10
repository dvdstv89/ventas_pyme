using System;
using System.Windows.Forms;
using MyUI.Factories;
using MyUI.Model;
using MyUI.UI;

namespace MyUI.UIControler
{  
    internal class ProgressBarUIController : BaseUIController<ProgressBarUI>
    {       
        private MensajeText mensaje;

        public ProgressBarUIController(MensajeText mensaje):base(new ProgressBarUI())
        {
            this.mensaje = mensaje; 
        }
        protected override void aplicarTema()
        {
            FormularioStyleFactory.PROGRESS_BAR(forma, mensaje);
            LabelStyleFactory.Label_TITLE_MENSAJE(forma.lbEstado, mensaje);
            forma._progressBarCommand.Style = ProgressBarStyle.Marquee;
        }

        public void Start()
        {
            try
            {
                if (Form.ActiveForm != null)
                {
                    forma.Owner = Form.ActiveForm;
                    forma.Owner.Enabled = false;
                }
                show();
            }
            catch (Exception)
            {
                throw;
            }           
        }          
    }
}
