using ModelData.Model;
using LocalData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanServicioMensualLDB
    {
        private PlanServicioMensualRepository repo;
        public PlanServicioMensualLDB()
        {
            repo = RepositoryFactory.PlanServicioMensual_Local();
        }        
       
        public bool updateFromRemoteData(List<PlanServicioMensual> planServicioMensualRemotos)
        {
            try
            {
                if (planServicioMensualRemotos.Count > 0)
                {
                    foreach (PlanServicioMensual planServicioMensual in planServicioMensualRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(planServicioMensual);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
        public List<PlanServicioMensual> inicializarPlanServicio_Metrocontador(Metrocontador metrocontador, int anno, string tokenId)
        {
            List<PlanServicioMensual> planServicioMensuales = PlanServicioMensualData.getByDefault_Metrocontador(metrocontador, anno, tokenId);           
            repo.insertList(planServicioMensuales);
            return planServicioMensuales;
        }
        public List<PlanServicioMensual> inicializarPlanServicio_Complejo(Complejo complejo, int anno, string tokenId, TipoServicio tipoServicio)
        {
            List<PlanServicioMensual> planServicioMensuales = PlanServicioMensualData.getByDefault_Complejo(complejo.id.getValueAsString(), anno, tokenId, tipoServicio);
            repo.insertList(planServicioMensuales);
            return planServicioMensuales;
        }

        public void updateList(List<PlanServicioMensual> planServiciosMensual)
        {   
            foreach (var plan in planServiciosMensual)
            {
                repo.update(plan);
            }            
        }
        public List<PlanServicioMensual> getByAnnoNoSincronizados()
        {
            try
            {
                return repo.getByAnnoNoSincronizados();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
