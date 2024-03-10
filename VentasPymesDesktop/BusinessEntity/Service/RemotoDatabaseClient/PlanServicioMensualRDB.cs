using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanServicioMensualRDB
    {
        private PlanServicioMensualRepository repo;
        public PlanServicioMensualRDB()
        {
            repo = RepositoryFactory.PlanServicioMensual_Postgres();
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
        public List<PlanServicioMensual> inicializarPlanServicioMetrocontador(Metrocontador metrocontador, int anno, string tokenId)
        {
            List<PlanServicioMensual> planServicioMensuales = PlanServicioMensualData.getByDefault_Metrocontador(metrocontador, anno, tokenId);           
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
        public List<PlanServicioMensual> getByAnno()
        {
            try
            {
                return repo.getByAnno();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromLocalData(List<PlanServicioMensual> planServicioMensualLocales)
        {
            try
            {
                if (planServicioMensualLocales.Count > 0)
                {
                    foreach (PlanServicioMensual planServicioMensual in planServicioMensualLocales)
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
    }
}
