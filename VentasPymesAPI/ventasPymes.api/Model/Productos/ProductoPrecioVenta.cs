using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.EventosMercantiles;

namespace ventasPymes.api.Model.Productos
{
    internal class ProductoPrecioVenta
    {
        [Key]
        public Guid Id { get; set; }       
        public Producto Producto { get; set; }
        public double Precio { get; set; }
        public ProductoPrecioVenta()
        {
            Id = Guid.NewGuid();
        }
    }
}
