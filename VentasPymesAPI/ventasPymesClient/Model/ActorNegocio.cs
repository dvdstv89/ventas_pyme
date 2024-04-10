using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model
{
    public class ActorNegocio
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string InformacionContacto { get; set; }
        public Nomenclador TipoActorNegocio { get; set; }
        public Pyme Pyme { get; set; }
        public ActorNegocio()
        {
            Id = Guid.NewGuid().ToString();
            TipoActorNegocio = new Nomenclador(TipoNomenclador.TipoActorNegocio);
        }
    }
}
