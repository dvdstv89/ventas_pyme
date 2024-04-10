namespace ventasPymesClient.Model.Productos
{

    public class Producto : Mercancia
    {
        public double PrecioMinimo { get; set; } //precio promedio de elaboracion costura (150) + precio de materia prima tela (750) + precio del hilo (500/ 30 rinde) alrededor de 920
        public List<ProductoPrecioVenta> PreciosVentas { get; set; }       
        public bool Insumo { get; set; }      
    }
}
