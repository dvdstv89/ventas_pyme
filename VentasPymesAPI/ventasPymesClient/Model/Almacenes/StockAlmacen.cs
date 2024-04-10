using ventasPymesClient.Model.EventosMercantiles;
using ventasPymesClient.Model.Productos;

namespace ventasPymesClient.Model.Almacenes
{
    public class StockAlmacen
    {
        public string Id { get; set; }
        public Almacen Almacen { get; set; }
        public Mercancia Mercancia { get; set; }
        public double CantidadActual { get; set; }
        public List<TarjetaEstiba> Tarjeta { get; set; }
        public List<VentaProducto> ventaProductos { get; set; }

        public StockAlmacen()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
