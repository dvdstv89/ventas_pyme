using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Seguridad
{
    internal class Log
    {
        [Key]
        public Guid Id { get; set; }
        public Nomenclador TipoLog { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Pyme pyme { get; set; }

        public Log()
        {
            Id = Guid.NewGuid();
            TipoLog = new Nomenclador(TipoNomenclador.TipoLog);
        }
    }
}
