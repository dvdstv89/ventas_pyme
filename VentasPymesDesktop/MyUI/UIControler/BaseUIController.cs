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
        public virtual void initDataForm()
        {
            return;
        }
        protected void cerrarFormulario()
        {
            if (forma.Owner != null)
            {
                forma.Owner.Enabled = true;
            }
            forma.Close();
        }
        protected void configurarFormulario()
        {
            forma.TopLevel = false;
            forma.FormBorderStyle = FormBorderStyle.None;
            forma.Dock = DockStyle.Fill;
            forma.BringToFront();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
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
    }
}
