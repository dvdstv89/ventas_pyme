using ModelData.Model;
using ModelData.Service.LocalDatabaseClient;
using NucleoEV.Model;
using NucleoEV.Tema;
using NucleoEV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NucleoEV.UIController
{
    internal class ModificarTiendaUIController : TiendaUIController
    {

        public ModificarTiendaUIController(Session session, Tienda tienda, List<Complejo> listaComplejo) : base(session, listaComplejo, tienda)
        {
            formularioModoModificar = true;
        }
        public override TiendaUI Ejecutar()
        {
            base.Ejecutar();
            base.forma.btnGuardar.Click += new EventHandler(btnModificar_Click);
            return forma;
        }
        protected override void restablecerFormulario()
        {
            base.restablecerFormulario();
            base.forma.Text = "Modificar tienda";
           
            forma.btnGuardar.Text = "Modificar";
          
            base.forma.cbMonedas.Enabled = false;
            base.forma.lwFormaPago.Enabled = true;
         
            base.forma.tbEmail.Clear();
            //for (int i = 0; i < tienda.email.emails.Count; i++)
            //{
            //    base.forma.tbEmail.AppendText(tienda.email.emails[i].Value + Environment.NewLine);
            //}
            seleccionarMoneda();
            seleccionarFormasPago();
        }
        private void seleccionarMoneda()
        {
            //forma.cbMonedas.Text = listaMonedas.FirstOrDefault(m => m.getId() == tienda.moneda.getId())?.denominacion.Value ?? "";
            //if (forma.cbMonedas.Text != "")
            //    LlenarListadoFormasPago(tienda.moneda.Objeto);
        }
        private void seleccionarFormasPago()
        {
            //for (int i = 0; i < tienda.formasPagosUtiliza.Count; i++)
            //{
            //    forma.lwFormaPago.Items[listaFormasPagos.FindIndex(fp => fp.id == tienda.formasPagosUtiliza[i].id)].Checked = true;
            //}
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarTiendaDesdeFormulario();
                if (validacion)
                {
                    new TiendaLDB().modificarTienda(tienda);
                    new MensajeBox().modificacionOk();
                    cerrarFormulario();
                }
                else
                {
                    new MensajeBox().validacionFail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
