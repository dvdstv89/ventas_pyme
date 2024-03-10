using ModelData.Repository;
using System.Collections.Generic;

namespace ModelData.Model
{
    public static class FormaPagoData
    {
        static List<FormaPago> formasPago { get; set; } = new List<FormaPago>();
        public static void inicializar()
        {
            if (formasPago.Count == 0)
            {
                formasPago = RepositoryFactory.FormaPago_Local().inicializar();
            }
        }
        public static FormaPago getFormaPagoById(string id)
        {
            inicializar();
            return formasPago.Find(x => x.getId() == id);
        }
        public static List<FormaPago> getAllFormaPago()
        {
            inicializar();
            return formasPago;
        }
        public static List<FormaPago> getFormasPagos(bool isOnline, bool isResumen = false)
        {
            inicializar();
            return formasPago.FindAll(x => x.moneda.Objeto.getIsOnline() == isOnline && x.getIsResumen() == isResumen);
        }
        public static List<FormaPago> getByMoneda(Moneda moneda, bool isResumen = false)
        {
            inicializar();
            return formasPago.FindAll(x => x.moneda.Objeto.getId() == moneda.getId() && x.getIsResumen() == isResumen);
        }       
    }
}
