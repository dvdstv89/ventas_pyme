using ModelData.Model;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using System.Linq;
using ModelData.Service.RemotoDatabaseClient;
using ModelData.Service.LocalDatabaseClient;
using Database.Class;
using System.Collections.Generic;

namespace NucleoEV.UIController
{
    internal class ModificarTiendaCapitalHumanoUIController : TiendaUIController
    {
       
        public ModificarTiendaCapitalHumanoUIController(Session session, Tienda tienda, List<Complejo> listaComplejos) : base(session, listaComplejos, tienda)
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
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);
            forma.btnGuardar.Text = "Modificar";
            base.forma.tbTienda.Text = tienda.denominacion.Value;
            base.forma.cbMonedas.Enabled = false;  
            base.forma.lwFormaPago.Enabled = true;           
            base.forma.tbOrden.Value = tienda.ordenComercial.Value;
            base.forma.tbEmail.Clear();            
            for (int i = 0; i < tienda.email.emails.Count; i++)
            {
                base.forma.tbEmail.AppendText(tienda.email.emails[i].Value + Environment.NewLine);
            }
            seleccionarMoneda();
            seleccionarFormasPago();
        }        
        private void seleccionarMoneda()
        {
            forma.cbMonedas.Text = listaMonedas.FirstOrDefault(m => m.getId() == tienda.moneda.getId())?.denominacion.Value ?? "";
            if (forma.cbMonedas.Text != "")
                LlenarListadoFormasPago(tienda.moneda.Objeto);
        }
        private void seleccionarFormasPago()
        {          
            for (int i = 0; i < tienda.formasPagosUtiliza.Count; i++)
            {
                forma.lwFormaPago.Items[listaFormasPagos.FindIndex(fp => fp.id == tienda.formasPagosUtiliza[i].id)].Checked = true;
            }
        }      
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarTiendaDesdeFormulario();
                if (validacion)
                {                   
                    if (session.chequearConectividadConServidor())
                    {
                        new TiendaRDB().modificarTienda(tienda);                     
                        tienda.isSincronizada.Value = true;                     
                    }
                    else
                    {
                        tienda.isSincronizada.Value = false;
                    }                   
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
