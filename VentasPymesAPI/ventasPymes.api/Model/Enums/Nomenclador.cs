using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ventasPymes.api.Model.Enums
{
    internal class Nomenclador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(TipoNomenclador))]
        public TipoNomenclador TipoNomenclador { get;}

        [Required]        
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [ForeignKey("NomencladorPadreId")]
        public Nomenclador NomencladorPadre { get; set; }       

        public int Orden { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public bool ReadOnly { get; set; }// categorias padres y los entrados por defecto

        [Required]
        public bool Visible { get; set; }//todos

        public Nomenclador(TipoNomenclador TipoNomenclador)
        {            
            this.TipoNomenclador = TipoNomenclador;
            Visible = true;
            ReadOnly = false;
            Activo = true;
        }

        public Nomenclador()
        {            
            Visible = true;
            ReadOnly = false;
            Activo = true;
        }
    }
}
