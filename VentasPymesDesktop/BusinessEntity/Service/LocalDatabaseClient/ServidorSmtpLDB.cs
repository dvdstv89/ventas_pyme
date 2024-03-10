using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class ServidorSmtpLDB
    {
        private ServidorSmtpRepository repo;
        public ServidorSmtpLDB()
        {
            repo = RepositoryFactory.ServidorSmtp_Local();
        }        
        public bool updateFromRemoteData(List<ServidorSMTP> servidorSmtpRemotos)
        {
            try
            {
                if (servidorSmtpRemotos.Count > 0)
                {
                    foreach (ServidorSMTP smtp in servidorSmtpRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(smtp);
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
        public void update(ServidorSMTP servidorSmtp)
        {
            try
            {
               repo.update(servidorSmtp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insert(ServidorSMTP servidorSmtp)
        {
            try
            {
                repo.insert(servidorSmtp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ServidorSMTP> getNoSincronizados()
        {
            try
            {
                return repo.getNoSincronizados();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
