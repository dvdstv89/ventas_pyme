using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;
using LocalData.Model;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class ComplejoLDB
    {
        private ComplejoRepository repo;
        public ComplejoLDB()
        {
            repo = RepositoryFactory.Complejo_Local();
        }
        public List<Complejo> getComplejos(int annoActual, string tokenId)
        {
            try
            {
                List<Complejo> complejos = repo.inicializar();
                foreach (Complejo complejo in complejos)
                {
                    if (complejo.planesVentas.Count == 0)
                    {
                        complejo.planesVentas = new PlanVentaMensualLDB().inicializarPlanVentaComplejo(complejo, annoActual, tokenId);
                    }
                    if(complejo.planesAgua.Count == 0)
                    {
                        complejo.planesAgua = new PlanServicioMensualLDB().inicializarPlanServicio_Complejo(complejo, annoActual, tokenId, TipoServicioData.Agua);
                    }
                    if (complejo.planesElectricidad.Count == 0)
                    {
                        complejo.planesElectricidad = new PlanServicioMensualLDB().inicializarPlanServicio_Complejo(complejo, annoActual, tokenId, TipoServicioData.Electricidad);
                    }
                    complejo.tiendas = TiendaData.getByIdComplejo(complejo.id);
                }
                return complejos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromRemoteData(List<Complejo> complejosRemotos)
        {
            try
            {
                if (complejosRemotos.Count > 0)
                {
                    foreach (Complejo complejo in complejosRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(complejo);
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
