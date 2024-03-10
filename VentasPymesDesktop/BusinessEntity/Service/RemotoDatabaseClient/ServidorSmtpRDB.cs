using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class ServidorSmtpRDB
    {
        private ServidorSmtpRepository repo;
        public ServidorSmtpRDB()
        {
            repo = RepositoryFactory.ServidorSmtp_Postgres();
        }
        public List<ServidorSMTP> getAll()
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
        public int getNextId()
        {
            try
            {
                return repo.getNextId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromLocalData(List<ServidorSMTP> conciliacionesLocales)
        {
            try
            {
                foreach (ServidorSMTP conciliacion in conciliacionesLocales)
                {
                    updateFromLocalData(conciliacion);
                }
                return (conciliacionesLocales.Count > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateFromLocalData(ServidorSMTP servidorSMTP)
        {
            try
            {
                SicronizacionResult result = repo.sincronizarDatos(servidorSMTP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insertarSMTP(ServidorSMTP servidorSMTP)
        {
            try
            {
                servidorSMTP.preInsertObjecto(VariablesEntorno.securityToken.token.Value);
                repo.insert(servidorSMTP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateSMTP(ServidorSMTP servidorSMTP)
        {
            try
            {
                servidorSMTP.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(servidorSMTP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
