using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class MonedaLDB
    {
        private MonedaRepository repo;
        public MonedaLDB()
        {
            repo = RepositoryFactory.Moneda_Local();
        }        
        public bool updateFromRemoteData(List<Moneda> monedasRemotas)
        {
            try
            {
                if (monedasRemotas.Count > 0)
                {
                    foreach (Moneda moneda in monedasRemotas)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(moneda);
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
