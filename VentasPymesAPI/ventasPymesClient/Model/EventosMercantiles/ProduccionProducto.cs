using ventasPymesClient.Model.Productos;

namespace ventasPymesClient.Model.EventosMercantiles
{
    public class ProduccionProducto
    {
        public string Id { get; set; }
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }
        public ProduccionProducto()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
