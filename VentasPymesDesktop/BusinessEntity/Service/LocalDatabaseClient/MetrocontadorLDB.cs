using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class MetrocontadorLDB
    {
        private MetrocontadorRepository repo;
        public MetrocontadorLDB()
        {
            repo = RepositoryFactory.Metrocontador_Local();
        }
        public List<Metrocontador> getMetrocontadores(int annoActual, string tokenId)
        {
            try
            {
                List<Metrocontador> metrocontadores = repo.inicializar();
                foreach (Metrocontador metrocontador in metrocontadores)
                {
                    if (metrocontador.planesConsumo.Count == 0)
                    {
                        metrocontador.planesConsumo = new PlanServicioMensualLDB().inicializarPlanServicio_Metrocontador(metrocontador, annoActual, tokenId);
                    }
                }
                return metrocontadores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromRemoteData(List<Metrocontador> metrocontadoresRemotos)
        {
            try
            {
                if (metrocontadoresRemotos.Count > 0)
                {
                    foreach (Metrocontador metro in metrocontadoresRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(metro);
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
