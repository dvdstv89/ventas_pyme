using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class GrupoConciliacionLDB
    {
        private GrupoConciliacionRepository repo;
        public GrupoConciliacionLDB()
        {
            repo = RepositoryFactory.GrupoConciliacion_Local();
        }       
        public bool updateFromRemoteData(List<GrupoConciliacion> grupoConsiliacionesLDBRemotos)
        {
            try
            {
                if (grupoConsiliacionesLDBRemotos.Count > 0)
                {
                    foreach (GrupoConciliacion grupoConsiliacion in grupoConsiliacionesLDBRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(grupoConsiliacion);
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
