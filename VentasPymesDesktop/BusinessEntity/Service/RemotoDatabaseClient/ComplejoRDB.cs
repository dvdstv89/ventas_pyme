using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class ComplejoRDB
    {
        ComplejoRepository complejoRepository;
        public ComplejoRDB()
        {
            complejoRepository = RepositoryFactory.Complejo_Postgres();
        }
        public List<Complejo> getAll()
        {
            try
            {
                return complejoRepository.getAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
