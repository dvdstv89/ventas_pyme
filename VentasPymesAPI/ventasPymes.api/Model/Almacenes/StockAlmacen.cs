using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.EventosMercantiles;
using ventasPymes.api.Model.Productos;

namespace ventasPymes.api.Model.Almacenes
{
    internal class StockAlmacen
    {
        [Key]
        public Guid Id { get; set; }
        public Almacen Almacen { get; set; }
        public Mercancia Mercancia { get; set; }
        public double CantidadActual { get; set; }
        public List<TarjetaEstiba> Tarjeta { get; set; }
        public List<VentaProducto> ventaProductos { get; set; }

        public StockAlmacen()
        {
            Id = Guid.NewGuid();
        }
    }
}
