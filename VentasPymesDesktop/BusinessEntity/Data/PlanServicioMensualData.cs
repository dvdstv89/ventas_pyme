using System;
using System.Collections.Generic;
using LocalData.Model;

namespace ModelData.Model
{
    public static class PlanServicioMensualData
    {      
        static List<PlanServicioMensual> inicializarComplejo(string idComplejo, int anno, string tokenId, TipoServicio tipoServicio)
        {
            List<PlanServicioMensual>  planServicioMensuales = new List<PlanServicioMensual>();
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 1, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 2, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 3, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 4, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 5, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 6, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 7, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 8, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 9, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 10, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 11, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 12, 1), tipoServicio, tokenId, TipoPlanServicio.Complejo, idComplejo));
            return planServicioMensuales;
        }
        static List<PlanServicioMensual> inicializarMetrocontador(string idMetrocontador, int anno, string tokenId, TipoServicio tipoServicio)
        {
            List<PlanServicioMensual> planServicioMensuales = new List<PlanServicioMensual>();
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 1, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 2, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 3, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 4, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 5, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 6, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 7, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 8, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 9, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 10, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 11, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            planServicioMensuales.Add(new PlanServicioMensual(new DateTime(anno, 12, 1), tipoServicio, tokenId, TipoPlanServicio.Metrocontador, idMetrocontador));
            return planServicioMensuales;
        }
        public static List<PlanServicioMensual> getByDefault_Complejo(string idComplejo, int anno, string tokenId, TipoServicio tipoServicio)
        {
            return inicializarComplejo(idComplejo, anno, tokenId, tipoServicio);           
        }
        public static List<PlanServicioMensual> getByDefault_Metrocontador(Metrocontador metrocontador, int anno, string tokenId)
        {
            return inicializarMetrocontador(metrocontador.getId(), anno, tokenId, metrocontador.tipoServicio.Objeto);
        }
    }
}
