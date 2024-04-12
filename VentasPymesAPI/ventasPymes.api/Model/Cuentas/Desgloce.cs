using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Enums;

namespace ventasPymes.api.Model.Cuentas
{
    internal class Desgloce
    {
        [Key]
        public Guid Id { get; set; }
        public RegistroFinanciero RegistroFinanciero { get; set; }     
        public decimal Monto { get; set; }       
        public string Descripcion { get; set; }       
        public Nomenclador TipoDesgloceFinanciero { get; set; }

        public Desgloce()
        {
            Id = Guid.NewGuid();
            TipoDesgloceFinanciero = new Nomenclador(TipoNomenclador.TipoDesgloceFinanciero);
        }
    }
}
