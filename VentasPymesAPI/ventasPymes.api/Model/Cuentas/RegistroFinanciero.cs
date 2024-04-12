using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Cuentas
{
    internal class RegistroFinanciero
    {
        [Key]
        public Guid Id { get; set; }
        public Nomenclador TipoRegistroFinanciero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<Desgloce> Desgloces { get; set; }
        public List<Pago> Pagos { get; set; }
        public string Descripcion { get; set; }
        public ActorNegocio Actor { get; set; } // proveedor, elaborador o cliente
        public Nomenclador EstadoRegistroFinanciero { get; set; }
        public Negocio Negocio { get; set; }

        public RegistroFinanciero()
        {
            Id = Guid.NewGuid();
            TipoRegistroFinanciero = new Nomenclador(TipoNomenclador.TipoRegistroFinanciero);
            EstadoRegistroFinanciero = new Nomenclador(TipoNomenclador.EstadoRegistroFinanciero);
        }
    }
}
