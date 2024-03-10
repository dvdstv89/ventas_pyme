using Database;
using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class ParteServicioDiarioRDB
    {
        private ParteServicioDiarioRepository repo;
        public ParteServicioDiarioRDB()
        {
            repo = RepositoryFactory.ParteMetrocontador_Postgres();
        }
        public List<ParteServicioDiario> getAll()
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
        public ParteServicioDiario getById(Atributo_PK<string> id)
        {
            try
            {
                return repo.getById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromLocalData(List<ParteServicioDiario> partesLocales)
        {
            try
            {
                foreach (ParteServicioDiario parte in partesLocales)
                {
                    SicronizacionResult result = repo.sincronizarDatos(parte);
                }
                return (partesLocales.Count > 0) ? true : false;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ParteServicioDiario> getNoSincronizadosMesActual()
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
    }
}
