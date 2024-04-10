using ventasPymesClient.Model.Productos;

namespace ventasPymesClient.Model.EventosMercantiles
{
    public class EventoMercantilMateriaPrima
    {
        public string Id { get; set; }
        public double Cantidad { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
        public double Rendimiento { get; set; } // en el caso del hilo que rinde para hacer 30 sabanas
        public EventoMercantil EventoMercantil { get; set; }
        public EventoMercantilMateriaPrima()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
