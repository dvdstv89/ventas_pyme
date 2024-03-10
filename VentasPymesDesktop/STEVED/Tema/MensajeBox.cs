using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucleoEV.Tema
{
    public class MensajeBox
    {
        public MensajeBox()
        {

        }

        public void modificacionOk()
        {
            MessageBox.Show("Modificación realizada satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void creacionOk()
        {
            MessageBox.Show("El nuevo elemento fue creado satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void eliminacionOk()
        {
            MessageBox.Show("El elemento fue eliminado satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void eliminacionFail()
        {
            MessageBox.Show("El elemento no puede ser eliminado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void parteDeVentaFail()
        {
            MessageBox.Show("No se pueden crear el parte de venta hasta que se habilite el proximo dia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void creacionErrorByConexionFail()
        {
            MessageBox.Show("No existe conexión con el servidor central, no se puede crear el elemento en estos momentos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void tokenNoExiste()
        {
            MessageBox.Show("El token no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void validacionFail()
        {
            MessageBox.Show("Se deben llenar todos los campos o llenarlos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DialogResult confirmarEliminacion()
        {
           return MessageBox.Show("Está segura que desea eliminar el elemento seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);           
        }
    }
}
