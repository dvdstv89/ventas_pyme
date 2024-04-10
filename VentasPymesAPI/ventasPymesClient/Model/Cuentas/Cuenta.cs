using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model.Cuentas
{
    public class Cuenta
    {
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
