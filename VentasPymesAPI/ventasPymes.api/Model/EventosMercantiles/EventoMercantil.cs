using ventasPymes.api.Model.Cuentas;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal abstract class EventoMercantil : EventoComercial
    {
        public List<EventoMercantilMateriaPrima> MateriasPrimas { get; set; }//materias primas de entradas
    }
}