using ventasPymesClient.Model.Cuentas;

namespace ventasPymesClient.Model.EventosMercantiles
{
    public class Venta: EventoComercial
    {   
        public List<VentaProducto> Productos { get; set; }
        public bool PagarPlazo { get; set; }      
    }
}
