using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class FormaPagoLDB
    {
        private FormaPagoRepository repo;
        public FormaPagoLDB()
        {
            repo = RepositoryFactory.FormaPago_Local();
        }
        public bool updateFromRemoteData(List<FormaPago> formaPagosRemotos)
        {
            try
            {
                if (formaPagosRemotos.Count > 0)
                {
                    foreach (FormaPago formaPago in formaPagosRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(formaPago);
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
