using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class FormaPagoRDB
    {
        private FormaPagoRepository repo;
        public FormaPagoRDB()
        {
            repo = RepositoryFactory.FormaPago_Postgres();
        }
        public List<FormaPago> getAll()
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
