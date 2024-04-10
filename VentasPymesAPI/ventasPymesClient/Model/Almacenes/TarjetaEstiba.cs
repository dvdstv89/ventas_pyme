using ventasPymesClient.Model.Enums;
using ventasPymesClient.Model.Productos;

namespace ventasPymesClient.Model.Almacenes
{
    public class TarjetaEstiba
    {
        public string Id { get; set; }
        public StockAlmacen AlmacenOrigen { get; set; }
        public StockAlmacen AlmacenDestino { get; set; }
        public Mercancia Mercancia { get; set; }
        public double Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Nomenclador TipoMovimientoMercancia { get; set; }

        public TarjetaEstiba()
        {
            Id = Guid.NewGuid().ToString();
            TipoMovimientoMercancia = new Nomenclador(TipoNomenclador.TipoMovimientoMercancia);
        }
    }
}
