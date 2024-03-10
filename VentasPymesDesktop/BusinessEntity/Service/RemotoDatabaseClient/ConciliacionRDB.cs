using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class ConciliacionRDB
    {
        private ConciliacionRepository repo;
        public ConciliacionRDB()
        {
            repo = RepositoryFactory.Conciliacion_Postgres();
        }
        public List<Conciliacion> getAll()
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
        public List<Conciliacion> getNoSincronizadosMesActual()
        {
            try
            {
                return repo.getNoSincronizadosMesActual();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromLocalData(List<Conciliacion> conciliacionesLocales)
        {
            try
            {
                foreach (Conciliacion conciliacion in conciliacionesLocales)
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
        public void updateFromLocalData(Conciliacion conciliacion)
        {
            try
            {
                SicronizacionResult result = repo.sincronizarDatos(conciliacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
