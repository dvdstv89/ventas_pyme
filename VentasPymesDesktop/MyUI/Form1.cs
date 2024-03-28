using MyUI.Enum.Message;
using MyUI.Service;
using System;
using System.Windows.Forms;

namespace MyUI
{
    public partial class Form1 : Form
    {
        ModuleConfigService moduleConfigService;      
        public Form1()
        {
            InitializeComponent();
           
            moduleConfigService = new ModuleConfigService();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                    
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
