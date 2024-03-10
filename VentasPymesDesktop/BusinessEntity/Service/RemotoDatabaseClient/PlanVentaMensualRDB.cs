using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class PlanVentaMensualRDB
    {
        private PlanVentaMensualRepository repo;
        public PlanVentaMensualRDB()
        {
            repo = RepositoryFactory.PlanVentaMensual_Postgres();
        }       
        public List<PlanVentaMensual> getByAnno()
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
        public bool updateFromLocalData(List<PlanVentaMensual> planVentaMensualLocales)
        {
            try
            {
                if (planVentaMensualLocales.Count > 0)
                {
                    foreach (PlanVentaMensual planVentaMensual in planVentaMensualLocales)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(planVentaMensual);
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
