using ventasPymesClient.Model.Cuentas;

namespace ventasPymesClient.Model.EventosMercantiles
{
    public abstract class EventoComercial
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public RegistroFinanciero registroFinanciero { get; set; }
        public ActorNegocio Actor { get; set; } // proveedor, elaborador o cliente
        public Negocio negocio { get; set; }

        public EventoComercial()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}