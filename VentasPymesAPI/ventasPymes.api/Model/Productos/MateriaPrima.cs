namespace ventasPymes.api.Model.Productos
{
    internal class MateriaPrima : Mercancia
    {      
        public double PrecioCostoReal { get; set; } //precio real de costo
        public double PrecioCostoCalculdo { get; set; } //precio real de costo + gastos de la factura (transporte, merienda / cantidad de productos)       
    }
}
