using ventasPymes.api.Model.Productos;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal class EventoMercantilMateriaPrima
    {
        public Guid Id { get; set; }
        public double Cantidad { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
        public double Rendimiento { get; set; } // en el caso del hilo que rinde para hacer 30 sabanas
        public EventoMercantil EventoMercantil { get; set; }
        public EventoMercantilMateriaPrima()
        {
            Id = Guid.NewGuid();
        }
    }
}
