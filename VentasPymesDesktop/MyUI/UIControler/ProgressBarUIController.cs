using System;
using System.Windows.Forms;
using MyUI.Factories;
using MyUI.Model;
using MyUI.UI;

namespace MyUI.UIControler
{  
    internal class ProgressBarUIController
    {
        private ProgressBarUI frm;
        private MensajeText mensaje;

        public ProgressBarUIController(MensajeText mensaje)
        {
            this.mensaje = mensaje;
            frm = new ProgressBarUI();
            SetEstiloForm();
        }

        private void SetEstiloForm()
        {
            FormularioStyleFactory.PROGRESS_BAR(frm, mensaje);
            LabelStyleFactory.Label_TITLE_MENSAJE(frm.lbEstado, mensaje);
            frm._progressBarCommand.Style = ProgressBarStyle.Marquee;
        }

        public void Start()
        {
            try
            {
                if (Form.ActiveForm != null)
                {
                    frm.Owner = Form.ActiveForm;
                    frm.Owner.Enabled = false;
                }
                frm.Show();
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public void Stop()
        {
            try
            {
                if (frm.Owner != null)
                {
                    frm.Owner.Enabled = true;
                }
                frm.Close();
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
