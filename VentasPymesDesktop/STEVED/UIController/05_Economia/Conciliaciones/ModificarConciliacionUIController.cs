using ModelData.Model;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData.Service.LocalDatabaseClient;

namespace NucleoEV.UIController
{
    internal class ModificarConciliacionUIController : ConciliacionUIController
    {       
        public ModificarConciliacionUIController(Session session, Complejo complejo, GrupoConciliacion grupoConciliacion, Conciliacion conciliacion) : base(session, complejo, grupoConciliacion, conciliacion)
        {
            formularioModoModificar = true;          
        }      
        public override ConciliacionUI Ejecutar()
        {
            base.Ejecutar();           
            base.forma.btnGuardar.Click += new EventHandler(btnModificar_Click);           
            return forma;
        }      
        protected override void restablecerFormulario()
        {
            base.restablecerFormulario();
            base.forma.Text = "Modificar conciliación";
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);
            forma.btnGuardar.Text = "Modificar";
            base.forma.dtFechaFin.Enabled = false;
            base.forma.dtFechaInicio.Enabled = false;
        }                    
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = actualizarConciliacionDesdeFormulario();
                if (validacion)
                {                    
                    new ConciliacionLDB().updateConciliacion(conciliacion);
                    session.sincronizarConciliacion();
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
