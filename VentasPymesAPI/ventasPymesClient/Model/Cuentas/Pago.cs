using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model.Cuentas
{
    public class Pago
    {
        public string Id { get; set; }
        public Nomenclador TipoPago { get; set; }
        public FormaPago FormaPago { get; set; }
        public double Saldo { get; set; }
        public string Descripcion { get; set; }      
        public DateTime Fecha { get; set; }

        public Pago()
        {
            Id = Guid.NewGuid().ToString();
            TipoPago = new Nomenclador(TipoNomenclador.TipoPago);
        }
    }
}
