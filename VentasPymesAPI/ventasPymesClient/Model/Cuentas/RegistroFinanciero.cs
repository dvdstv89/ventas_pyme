using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model.Cuentas
{
    public class RegistroFinanciero
    {
        public string Id { get; set; }
        public Nomenclador TipoRegistroFinanciero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<Desgloce> Desgloces { get; set; }
        public List<Pago> Pagos { get; set; }
        public string Descripcion { get; set; }
        public ActorNegocio Actor { get; set; } // proveedor, elaborador o cliente
        public Nomenclador EstadoRegistroFinanciero { get; set; }
        public Negocio Negocio { get; set; }

        public RegistroFinanciero()
        {
            Id = Guid.NewGuid().ToString();
            TipoRegistroFinanciero = new Nomenclador(TipoNomenclador.TipoRegistroFinanciero);
            EstadoRegistroFinanciero = new Nomenclador(TipoNomenclador.EstadoRegistroFinanciero);
        }
    }
}
