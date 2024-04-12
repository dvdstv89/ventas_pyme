using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Productos
{
    internal abstract class Mercancia
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }        
        public Nomenclador UnidadMedida { get; set; }
        public ActorNegocio proveedor { get; set; }

        public Mercancia()
        {
            Id = Guid.NewGuid();
            UnidadMedida = new Nomenclador(TipoNomenclador.UnidadMedida);           
        }
    }
}