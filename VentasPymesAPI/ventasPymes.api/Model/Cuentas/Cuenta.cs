using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Cuentas
{
    internal class Cuenta
    {
        [Key]
        public int Id { get; set; }
        public Nomenclador TipoMoneda { get; set; }
        public string Nombre { get; set; }
        public decimal SaldoActual { get; set; }
        public ICollection<FormaPago> FormasPago { get; set; }
        public Negocio Negocio { get; set; }

        public Cuenta()
        {
            TipoMoneda = new Nomenclador(TipoNomenclador.TipoMoneda);
        }
    }
}
