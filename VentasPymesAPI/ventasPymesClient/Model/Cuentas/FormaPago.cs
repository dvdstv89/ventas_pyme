namespace ventasPymesClient.Model.Cuentas
{
    public class FormaPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
