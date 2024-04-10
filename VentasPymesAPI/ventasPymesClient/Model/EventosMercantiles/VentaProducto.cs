using ventasPymesClient.Model.Almacenes;
using ventasPymesClient.Model.Productos;

namespace ventasPymesClient.Model.EventosMercantiles
{
    public class VentaProducto
    {
        public string Id { get; set; }
        StockAlmacen Almacen { get; set; }
        ProductoPrecioVenta Producto { get; set; }
        public double Cantidad { get; set; }
        public VentaProducto()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
