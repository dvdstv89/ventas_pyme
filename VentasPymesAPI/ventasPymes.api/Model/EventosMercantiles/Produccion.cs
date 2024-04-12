using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal class Produccion : EventoMercantil
    {
        public List<EventoMercantilMateriaPrima> MateriasPrimas { get; set; }//materias primas de entradas 
        public Nomenclador TipoProduccion { get; set; } // si se esta creando nuevo o se esta reparando algo       
        public List<ProduccionProducto> ProductosResultantes { get; set; }// producto resultante
        public string NumeroProduccion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double CostoElaboracionUnitario { get; set; }
        public Nomenclador EstadoProduccion { get; set; } // para controlar el pase a almacen cuando termine
                                                          // 
        public Produccion()
        {
            TipoProduccion = new Nomenclador(TipoNomenclador.TipoProduccion);
            EstadoProduccion = new Nomenclador(TipoNomenclador.EstadoProduccion);
        }
    }
}
