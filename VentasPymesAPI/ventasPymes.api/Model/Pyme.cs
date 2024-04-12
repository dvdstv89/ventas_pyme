using ventasPymes.api.Model.Cuentas;
using ventasPymes.api.Model.Enums;
using ventasPymes.api.Model.EventosMercantiles;
using ventasPymes.api.Model.Seguridad;

namespace ventasPymes.api.Model
{
    internal class Pyme : Negocio
    {        
        public Nomenclador TipoMonedaBase { get; set; }//moneda base en las que se registran todas las operaciones, si se usa una moneda distinta debe ser convertida
        public List<PuntoVenta> PuntoVentas { get; set; }
        public List<TazaCambio> TazasCambios { get; set; } //Valores de las monedas respecto a otras
        public List<SecurityToken> SecurityTokens { get; set; } // claves de acceso
        public double ProcentajeEnDeclaraciones { get; set; }
        public Nomenclador TipoRedondeo { get; set; }              
        public List<EventoMercantil> producciones { get; set; } //facturas de Materias primas recibidas por los proveedores materias primas elaborandoce para ser convertidas en productos y pasar al almacenProductos
        public List<ActorNegocio> actorNegocios { get; set; }//clientes, elaboradores, proveedores
        public List<Log> logs { get; set; }
        public List<Nomenclador> Nomencladores { get; set; }

        public Pyme()
        {
            TipoRedondeo = new Nomenclador(TipoNomenclador.TipoRedondeo);
        }
    }
}
