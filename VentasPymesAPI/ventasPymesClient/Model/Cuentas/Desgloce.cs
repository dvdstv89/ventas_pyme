using ventasPymesClient.Model.Enums;

namespace ventasPymesClient.Model.Cuentas
{
    public class Desgloce
    {
        public string Id { get; set; }
        public RegistroFinanciero RegistroFinanciero { get; set; }     
        public decimal Monto { get; set; }       
        public string Descripcion { get; set; }       
        public Nomenclador TipoDesgloceFinanciero { get; set; }

        public Desgloce()
        {
            Id = Guid.NewGuid().ToString();
            TipoDesgloceFinanciero = new Nomenclador(TipoNomenclador.TipoDesgloceFinanciero);
        }
    }
}
