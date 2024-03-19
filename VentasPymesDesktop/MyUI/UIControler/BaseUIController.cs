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
        public virtual void forma_Load(object sender, EventArgs e)
        {
            aplicarTema();
            initDataForm();
        }
        public virtual void aplicarTema()
        {
            return;
        }
        public virtual void initDataForm()
        {
            return;
        }
        public void cerrarFormulario()
        {
            forma.Close();
        }
        public void configurarFormulario()
        {
            forma.TopLevel = false;
            forma.FormBorderStyle = FormBorderStyle.None;
            forma.Dock = DockStyle.Fill;
            forma.BringToFront();
        }
        public void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.DialogResult = DialogResult.Cancel; return;               
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }        
        public Forma getForma()
        {
            return forma;
        }       
    }
}
