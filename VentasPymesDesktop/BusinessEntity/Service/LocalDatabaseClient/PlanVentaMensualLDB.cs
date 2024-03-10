using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanVentaMensualLDB
    {
        private PlanVentaMensualRepository repo;
        public PlanVentaMensualLDB()
        {
            repo = RepositoryFactory.PlanVentaMensual_Local();
        }        
        public List<PlanVentaMensual> getByAnnoNoSincronizados()
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
        public bool updateFromRemoteData(List<PlanVentaMensual> planVentaMensualRemotos)
        {
            try
            {
                if (planVentaMensualRemotos.Count > 0)
                {
                    foreach (PlanVentaMensual planVentaMensual in planVentaMensualRemotos)
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
        public List<PlanVentaMensual> inicializarPlanVentaTienda(Tienda tienda, int anno, string tokenId)
        {
            List<PlanVentaMensual> planVentaMensuales = PlanVentaMensualData.getByDefault_Tienda(tienda.getId(), anno, tokenId);           
            repo.insertList(planVentaMensuales);           
            return planVentaMensuales;
        }
        public List<PlanVentaMensual> inicializarPlanVentaComplejo(Complejo complejo, int anno, string tokenId)
        {
            List<PlanVentaMensual> planVentaMensuales = PlanVentaMensualData.getByDefault_Complejo(complejo.getId(), anno, tokenId);
            repo.insertList(planVentaMensuales);
            return planVentaMensuales;
        }
        public void updateList(List<PlanVentaMensual> planesVentaMensuales)
        {   
            foreach (var planVentaMensual in planesVentaMensuales)
            {
                repo.update(planVentaMensual);
            }            
        }
    }
}
