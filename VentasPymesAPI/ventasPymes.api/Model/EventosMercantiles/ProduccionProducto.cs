using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Productos;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal class ProduccionProducto
    {
        [Key]
        public Guid Id { get; set; }
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }
        public ProduccionProducto()
        {
            Id = Guid.NewGuid();
        }
    }
}
