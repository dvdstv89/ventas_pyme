using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Almacenes;
using ventasPymes.api.Model.Productos;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal class VentaProducto
    {
        [Key]
        public Guid Id { get; set; }
        StockAlmacen Almacen { get; set; }
        ProductoPrecioVenta Producto { get; set; }
        public double Cantidad { get; set; }
        public VentaProducto()
        {
            Id = Guid.NewGuid();
        }
    }
}
