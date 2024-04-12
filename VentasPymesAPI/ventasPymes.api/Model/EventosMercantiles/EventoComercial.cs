using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Cuentas;

namespace ventasPymes.api.Model.EventosMercantiles
{
    internal abstract class EventoComercial
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public RegistroFinanciero registroFinanciero { get; set; }
        public ActorNegocio Actor { get; set; } // proveedor, elaborador o cliente
        public Negocio negocio { get; set; }

        public EventoComercial()
        {
            Id = Guid.NewGuid();
        }
    }
}