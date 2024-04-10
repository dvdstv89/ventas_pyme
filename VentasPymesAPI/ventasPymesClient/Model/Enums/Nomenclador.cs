using System.CodeDom;

namespace ventasPymesClient.Model.Enums
{
    public class Nomenclador
    {
        public TipoNomenclador TipoNomenclador { get;}
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nomenclador NomencladorPadre { get; set; }
        public int Orden { get; set; }
        public bool Activo { get; set; }

        public Nomenclador(TipoNomenclador TipoNomenclador)
        {            
            this.TipoNomenclador = TipoNomenclador;
        }
    }
}
