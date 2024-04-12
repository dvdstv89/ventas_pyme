using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model
{
    internal class ActorNegocio
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string InformacionContacto { get; set; }
        public Nomenclador TipoActorNegocio { get; set; }
        public Pyme Pyme { get; set; }
        public ActorNegocio()
        {
            Id = Guid.NewGuid();
            TipoActorNegocio = new Nomenclador(TipoNomenclador.TipoActorNegocio);
        }
    }
}
