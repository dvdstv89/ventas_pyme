using ventasPymesClient.Model.Cuentas;

namespace ventasPymesClient.Model.EventosMercantiles
{
    public abstract class EventoMercantil : EventoComercial
    {
        public List<EventoMercantilMateriaPrima> MateriasPrimas { get; set; }//materias primas de entradas
    }
}