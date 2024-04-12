using System.ComponentModel.DataAnnotations;
using ventasPymes.api.Model.Almacenes;
using ventasPymes.api.Model.Cuentas;

namespace ventasPymes.api.Model
{
    internal abstract class Negocio
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Cuenta> cuentas { get; set; } //donde se deposita el dinero de las ventas
        public List<FormaPago> formaPagos { get; set; } //formas en las que se cobra los productos
        public List<RegistroFinanciero> registroFinanciero { get; set; } // cuentas por cobrarle a los clientes fiados, gastos y por pagarle a los proveedores
        public List<Almacen> Almacenes { get; set; }

    }
}
