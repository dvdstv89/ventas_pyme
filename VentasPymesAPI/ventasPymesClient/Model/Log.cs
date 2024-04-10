using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model
{
    public class Log
    {
        public string Id { get; set; }
        public Nomenclador TipoLog { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Pyme pyme { get; set; }

        public Log()
        {
            Id = Guid.NewGuid().ToString();
            TipoLog = new Nomenclador(TipoNomenclador.TipoLog);
        }
    }
}
