using ventasPymes.api.Model.EventosMercantiles;

namespace ventasPymes.api.Model
{
    internal class PuntoVenta : Negocio
    {
        public Pyme pyme { get; set; }
        public bool conciliacion { get; set; }
        public ActorNegocio Actor { get; set; }//dueno del punto de venta, o proveedor principal para la tienda en conciliacion
        public List<Venta> ventas { get; set; }
    }
}
