using ventasPymes.api.Model.Cuentas;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal class Venta: EventoComercial
    {   
        public List<VentaProducto> Productos { get; set; }
        public bool PagarPlazo { get; set; }      
    }
}
