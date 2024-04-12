using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Cuentas
{
    internal class TazaCambio
    {
        [Key]
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
