using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class MonedaRDB
    {
        private MonedaRepository repo;
        public MonedaRDB()
        {
            repo = RepositoryFactory.Moneda_Postgres();
        }
        public List<Moneda> getAll()
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
