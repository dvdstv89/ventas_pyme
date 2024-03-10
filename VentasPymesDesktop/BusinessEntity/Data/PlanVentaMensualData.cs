using System;
using System.Collections.Generic;

namespace ModelData.Model
{
    public static class PlanVentaMensualData
    {      
        static List<PlanVentaMensual> inicializarTienda(string idTienda, int anno, string tokenId)
        {
            List<PlanVentaMensual>  planVentaMensuales = new List<PlanVentaMensual>();
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 1, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 2, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 3, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 4, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 5, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 6, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 7, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 8, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 9, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 10, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 11, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 12, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Tienda, idTienda));
            return planVentaMensuales;
        }

        static List<PlanVentaMensual> inicializarComplejo(string idComplejo, int anno, string tokenId)
        {
            List<PlanVentaMensual> planVentaMensuales = new List<PlanVentaMensual>();
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 1, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 2, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 3, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 4, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 5, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 6, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 7, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 8, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 9, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 10, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 11, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            planVentaMensuales.Add(new PlanVentaMensual(new DateTime(anno, 12, 1), MonedaData.getMonedaByDefaul(), tokenId, TipoPlanVenta.Complejo, idComplejo));
            return planVentaMensuales;
        }

        public static List<PlanVentaMensual> getByDefault_Tienda(string idTienda, int anno, string tokenId)
        {
            return inicializarTienda(idTienda, anno, tokenId);           
        }
        public static List<PlanVentaMensual> getByDefault_Complejo(string idComplejo, int anno, string tokenId)
        {
            return inicializarComplejo(idComplejo, anno, tokenId);
        }
    }
}
