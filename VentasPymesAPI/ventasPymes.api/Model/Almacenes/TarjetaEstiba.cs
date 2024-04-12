using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;
using ventasPymes.api.Model.Productos;

namespace ventasPymes.api.Model.Almacenes
{
    internal class TarjetaEstiba
    {
        [Key]
        public Guid Id { get; set; }
        public StockAlmacen AlmacenOrigen { get; set; }
        public StockAlmacen AlmacenDestino { get; set; }
        public Mercancia Mercancia { get; set; }
        public double Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Nomenclador TipoMovimientoMercancia { get; set; }

        public TarjetaEstiba()
        {
            Id = Guid.NewGuid();
            TipoMovimientoMercancia = new Nomenclador(TipoNomenclador.TipoMovimientoMercancia);
        }
    }
}
