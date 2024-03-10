using ModelData.Model;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData.Service.LocalDatabaseClient;
using ModelData.Service.RemotoDatabaseClient;

namespace NucleoEV.UIController
{
    internal class AdicionarConciliacionUIController : ConciliacionUIController
    {       
        public AdicionarConciliacionUIController(Session session, Complejo complejo, GrupoConciliacion grupoConciliacion, Conciliacion conciliacion) : base(session, complejo, grupoConciliacion, conciliacion)
        {           
            formularioModoModificar = false;            
        }      
        public override ConciliacionUI Ejecutar()
        {
            base.Ejecutar();           
            base.forma.btnGuardar.Click += new EventHandler(btnAdicionar_Click);           
            return forma;
        }
        protected override void restablecerFormulario()
        {
            base.restablecerFormulario();
            base.forma.Text = "Crear conciliación";           
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);
            forma.btnGuardar.Text = "Crear";           
        }       
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarConciliacionDesdeFormulario();
                if (validacion)
                {
                    new ConciliacionLDB().guardarConciliacion(conciliacion);
                    conciliacion.partesVentas = new ParteVentaDiarioLDB().revisarConciliacion(conciliacion);                  
                    new ConciliacionLDB().updateConciliacion(conciliacion);
                    //revisar partes afectados
                    try
                    {
                        //sincronizar solo lo que tenga que ver con la conciliacion creada
                        new ConciliacionRDB().updateFromLocalData(conciliacion);                   
                        session.sincronizarParteVenta(conciliacion);
                        new MensajeBox().creacionOk();
                        cerrarFormulario();
                    }
                    catch (Exception)
                    {
                        dialogResultOk = false;
                        new MensajeBox().creacionErrorByConexionFail();
                        btnCancelar_Click(sender, e);
                    }
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
