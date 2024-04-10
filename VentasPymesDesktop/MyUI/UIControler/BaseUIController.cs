using MyUI.Service;
using System;
using System.Windows.Forms;

namespace MyUI.UIControler
{
    public class BaseUIController<Forma> where Forma : Form
    {   
        protected Forma forma { get; }
        public bool dialogResultOk;
        public bool formularioModoModificar;       
        public BaseUIController(Forma forma)
        {
            try
            {              
                this.forma = forma;
                this.dialogResultOk = false;
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);                
            }
        }
        protected virtual void forma_Load(object sender, EventArgs e)
        {
            aplicarTema();
            initDataForm();
        }
        protected virtual void aplicarTema()
        {
            return;
        }
        protected virtual void initDataForm()
        {
            return;
        }
        protected virtual Forma ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            return forma;
        }
        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.Close();
                forma.DialogResult = DialogResult.Cancel;
                if (forma.Owner != null)
                {
                    forma.Owner.Enabled = true;
                }
                return;               
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
        protected Forma getForma()
        {
            return forma;
        }
        public void cerrarFormulario()
        {
            try
            {
                if (forma.Owner != null)
                {
                    forma.Owner.Enabled = true;
                }
                forma.Close();
            }
            catch (Exception)
            {
                throw;
            }           
        }
        public void configurarFormularioComoPanel()
        {
            forma.TopLevel = false;
            forma.FormBorderStyle = FormBorderStyle.None;
            forma.Dock = DockStyle.Fill;
            forma.BringToFront();
        }
        public Form getForm()
        {
            return forma;
        }

        public DialogResult showDialog()
        {
            return ejecutar().ShowDialog();
        }
        public void show()
        {
             ejecutar().Show();
        }

    }
}
