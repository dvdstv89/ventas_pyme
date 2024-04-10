using ventasPymesClient.Model.Cuentas;
using ventasPymesClient.Model.Enums;
using ventasPymesClient.Model.EventosMercantiles;

namespace ventasPymesClient.Model
{
    public class Pyme : Negocio
    {        
        public Nomenclador TipoMonedaBase { get; set; }//moneda base en las que se registran todas las operaciones, si se usa una moneda distinta debe ser convertida
        public List<PuntoVenta> PuntoVentas { get; set; }
        public List<TazaCambio> TazasCambios { get; set; } //Valores de las monedas respecto a otras
        public string Token { get; set; } // clave de acceso
        public double ProcentajeEnDeclaraciones { get; set; }
        public Nomenclador TipoRedondeo { get; set; }              
        public List<EventoMercantil> producciones { get; set; } //facturas de Materias primas recibidas por los proveedores materias primas elaborandoce para ser convertidas en productos y pasar al almacenProductos
        public List<ActorNegocio> actorNegocios { get; set; }//clientes, elaboradores, proveedores
        public List<Log> logs { get; set; }

        public Pyme()
        {
            TipoRedondeo = new Nomenclador(TipoNomenclador.TipoRedondeo);
        }
    }
}
