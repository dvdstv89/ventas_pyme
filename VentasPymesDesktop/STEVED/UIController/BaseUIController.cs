using NucleoEV.Model;
using System;
using System.Windows.Forms;

namespace NucleoEV.UIController
{
    internal class BaseUIController
    {       
        protected Session session;       
        public Form forma { get; set; }
        public BaseUIController(Session session, Form forma)
        {
            try
            {
                this.session = session;
                this.forma = forma;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        public void cerrarFormulario()
        {
            (forma as Form).Close();
        }
        public void configurarFormulario()
        {
            (forma as Form).TopLevel = false;
            (forma as Form).FormBorderStyle = FormBorderStyle.None;
            (forma as Form).Dock = DockStyle.Fill;
            (forma as Form).BringToFront();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.DialogResult = DialogResult.Cancel; return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     
    }
}
