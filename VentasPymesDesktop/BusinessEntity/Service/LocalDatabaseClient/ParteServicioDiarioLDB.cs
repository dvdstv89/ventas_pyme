using Database;
using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{
    public class ParteServicioDiarioLDB
    {
        private ParteServicioDiarioRepository repo;
        public ParteServicioDiarioLDB()
        {
            repo = RepositoryFactory.ParteServicioDiario_Local();
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
        public bool updateFromRemoteData(List<ParteServicioDiario> partesRemotos)
        {
            try
            {
                if (partesRemotos.Count > 0)
                {
                    foreach (ParteServicioDiario parte in partesRemotos)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(parte);
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
        public void guardarList(List<ParteServicioDiario> parteMetros)
        {
            foreach (var parte in parteMetros)
            {
                ParteServicioDiario parteAux = repo.getByIdMetroFecha(parte.idMetro.Value, parte.fecha.Fecha);
                if (parteAux != null)
                {
                    parte.id = parteAux.id;
                    parte.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                    if(parte.consumo.Value != parteAux.consumo.Value)
                        repo.update(parte);
                }
                else
                {
                    parte.preInsertObjecto(VariablesEntorno.securityToken.token.Value);
                    repo.insert(parte);
                }               
            }
        }
    }
}
