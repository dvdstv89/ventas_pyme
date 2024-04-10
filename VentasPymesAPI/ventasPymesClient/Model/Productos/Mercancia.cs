using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model.Productos
{
    public abstract class Mercancia
    {
        public string Id { get; set; }
        public string Nombre { get; set; }        
        public Nomenclador UnidadMedida { get; set; }
        public ActorNegocio proveedor { get; set; }

        public Mercancia()
        {
            Id = Guid.NewGuid().ToString();
            UnidadMedida = new Nomenclador(TipoNomenclador.UnidadMedida);           
        }
    }
}