using Database;
using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class ParteVentaDiarioRDB
    {
        private ParteVentaDiarioRepository repo;
        public ParteVentaDiarioRDB()
        {
            repo = RepositoryFactory.ParteVentaDiario_Postgres();
        }
        public List<ParteVentaDiario> getAll()
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
        public ParteVentaDiario getById(Atributo_PK<string> id)
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
        public bool updateFromLocalData(List<ParteVentaDiario> partesLocales)
        {
            try
            {
                foreach (ParteVentaDiario parte in partesLocales)
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
        public List<ParteVentaDiario> getNoSincronizadosMesActual()
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
