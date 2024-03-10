using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class MetrocontadorRDB
    {
        private MetrocontadorRepository repo;
        public MetrocontadorRDB()
        {
            repo = RepositoryFactory.Metrocontador_Postgres();
        }
        public List<Metrocontador> getAll()
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
