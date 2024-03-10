using ModelData.Model;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData.Service.RemotoDatabaseClient;
using ModelData.Service.LocalDatabaseClient;
using System.Collections.Generic;

namespace NucleoEV.UIController
{
    internal class AdicionarTiendaUIController : TiendaUIController
    {       
        public AdicionarTiendaUIController(Session session, List<Complejo> listaComplejos) : base(session, listaComplejos,  new Tienda(session.getTokenId()))
        {           
            formularioModoModificar = false;            
        }      
        public override TiendaUI Ejecutar()
        {
            base.Ejecutar();           
            base.forma.btnGuardar.Click += new EventHandler(btnAdicionar_Click);
            base.forma.cbMonedas.SelectedIndexChanged += new EventHandler(cbComplejos_SelectedIndexChanged);
            return forma;
        }

        private void cbComplejos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {    
                LlenarListadoFormasPago(listaMonedas.Find(m => m.denominacion.Value == forma.cbMonedas.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void restablecerFormulario()
        {
            base.restablecerFormulario();
            base.forma.Text = "Crear tienda";           
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);
            forma.btnGuardar.Text = "Crear";
            base.forma.tbTienda.Text = tienda.denominacion.Value;
            base.forma.btnAbrir.Visible = false;
            base.forma.btnCerrar.Visible = false;
            base.forma.btnEliminar.Visible = false;
        }       
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarTiendaDesdeFormulario();
                if (validacion)
                {                    
                    if (session.chequearConectividadConServidor())
                    {
                        int idTienda = new TiendaRDB().getNextId();                        
                        Tienda tiendaNueva = new TiendaLDB().crearTienda(tienda, idTienda);
                        new PlanVentaMensualLDB().inicializarPlanVentaTienda(tiendaNueva, session.periodoAbierto.annoAbierto.Value, session.getTokenId());                       
                        new TiendaRDB().crearTienda(tienda);                    
                        tiendaNueva.isSincronizada.Value = true;                      
                        new TiendaLDB().modificarTienda(tienda);
                    }
                    else
                    {
                        dialogResultOk = false;
                        new MensajeBox().creacionErrorByConexionFail();
                        btnCancelar_Click(sender, e);
                    }
                    new MensajeBox().creacionOk();
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
