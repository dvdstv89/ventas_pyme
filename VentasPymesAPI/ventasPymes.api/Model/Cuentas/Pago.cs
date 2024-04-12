using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Cuentas
{
    internal class Pago
    {
        [Key]
        public Guid Id { get; set; }
        public Nomenclador TipoPago { get; set; }
        public FormaPago FormaPago { get; set; }
        public double Saldo { get; set; }
        public string Descripcion { get; set; }      
        public DateTime Fecha { get; set; }

        public Pago()
        {
            Id = Guid.NewGuid();
            TipoPago = new Nomenclador(TipoNomenclador.TipoPago);
        }
    }
}
