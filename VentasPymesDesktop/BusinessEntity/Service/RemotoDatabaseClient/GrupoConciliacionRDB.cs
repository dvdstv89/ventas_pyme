using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class GrupoConciliacionRDB
    {
        private GrupoConciliacionRepository repo;
        public GrupoConciliacionRDB()
        {
            repo = RepositoryFactory.GrupoConciliacion_Postgres();
        }
        public List<GrupoConciliacion> getAll()
        {
            try
            {
                return repo.getAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
    }
}
