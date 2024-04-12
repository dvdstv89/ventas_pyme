using System.ComponentModel.DataAnnotations;

namespace ventasPymes.api.Model.Cuentas
{
    internal class FormaPago
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
