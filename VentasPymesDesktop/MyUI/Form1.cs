using MyUI.Enum.Message;
using MyUI.Service;
using System;
using System.Windows.Forms;

namespace MyUI
{
    public partial class Form1 : Form
    {
        ModuleConfigService moduleConfigService;
        ProgressBarService progressBarService;

        public Form1()
        {
            InitializeComponent();
            progressBarService = new ProgressBarService(TextMensaje.PROGRESSBAR_CARGANDO);
            moduleConfigService = new ModuleConfigService();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                    
        }

        private void iconButtonProgressBar_Click(object sender, EventArgs e)
        {
            progressBarService.start();
        }

        private void iconButtonProgressBarStop_Click(object sender, EventArgs e)
        {
            progressBarService.stop();
        }

        private void iconButtonMensajeError_Click(object sender, EventArgs e)
        {
            DialogService.ERROR(TextMensaje.ERROR_EXAMPLE);
        }

        private void iconButtonSucess_Click(object sender, EventArgs e)
        {
            DialogService.SUCCESS(TextMensaje.SUCCESS_EXAMPLE);
        }

        private void iconButtonException_Click(object sender, EventArgs e)
        {
            DialogService.EXCEPTION("Ejemplo de mensaje de exception");
        }

        private void iconButtonConfirmation_Click(object sender, EventArgs e)
        {
            bool result = DialogService.CONFIRMATION(TextMensaje.CONFIRMATION_EXAMPLE);
            DialogService.EXCEPTION(result.ToString());
        }
    }
}
