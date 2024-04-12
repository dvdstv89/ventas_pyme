using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Almacenes
{
    internal class Almacen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nomenclador TipoAlmacen { get; set; }
        public List<StockAlmacen> Stock { get; set; }
        public Negocio negocio { get; set; }

        public Almacen()
        {
            TipoAlmacen = new Nomenclador(TipoNomenclador.TipoAlmacen);
        }
    }
}
