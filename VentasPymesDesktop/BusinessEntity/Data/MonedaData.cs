using ModelData.Repository;
using System.Collections.Generic;

namespace ModelData.Model
{
    public static class MonedaData
    {
        public static string CUP = "CUP";
        public static string MLC = "MLC";
        static List<Moneda> monedas { get; set; } = new List<Moneda>();
        static void inicializar()
        {
            if (monedas.Count == 0)
            {
                monedas = RepositoryFactory.Moneda_Local().inicializar();
            }
        }
        public static Moneda getMonedaById(int id)
        {
            inicializar();
            return monedas.Find(x => x.id.getValueAsInt() == id);
        }
        public static Moneda getMonedaByDefaul(bool isOnline = false)
        {
            inicializar();
            return monedas.Find(x => x.isByDefault.Value == true && x.isOnline.Value == isOnline);            
        }      
        public static List<Moneda> getAllMonedas(bool isOnline = false)
        {
            inicializar();
            return monedas.FindAll(x => x.isOnline.Value == isOnline);
        }
        public static Moneda getMoneda(Moneda moneda, bool isOnline)
        {
            inicializar();
            return monedas.Find(x => x.denominacion.Value == moneda.denominacion.Value && x.isOnline.Value == isOnline);
        }
    }
}
