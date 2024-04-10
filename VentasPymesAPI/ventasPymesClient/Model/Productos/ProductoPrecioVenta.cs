
using ventasPymesClient.Model.EventosMercantiles;

namespace ventasPymesClient.Model.Productos
{
    public class ProductoPrecioVenta
    {
        public string Id { get; set; }       
        public Producto Producto { get; set; }
        public double Precio { get; set; }
        public ProductoPrecioVenta()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
