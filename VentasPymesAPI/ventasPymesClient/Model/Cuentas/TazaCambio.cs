using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model.Cuentas
{
    public class TazaCambio
    {
        public int Id { get; set; }
        public Nomenclador TipoMoneda { get; set; }
        public bool Activo { get; set; }
        public double TazaCambioRespectoMonedaBase { get; set; }
        public Pyme Pyme { get; set; }

        public TazaCambio()
        {
            TipoMoneda = new Nomenclador(TipoNomenclador.TipoMoneda);
        }
    }
}
