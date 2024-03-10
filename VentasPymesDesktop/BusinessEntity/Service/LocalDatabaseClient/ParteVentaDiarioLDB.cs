using Database;
using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{
    public class ParteVentaDiarioLDB
    {
        private ParteVentaDiarioRepository repo;
        public ParteVentaDiarioLDB()
        {
            repo = RepositoryFactory.ParteVentaDiario_Local();
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
        public bool updateFromRemoteData(List<ParteVentaDiario> partesRemotos)
        {
            try
            {
                if (partesRemotos.Count > 0)
                {
                    foreach (ParteVentaDiario parte in partesRemotos)
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
        public void guardarList(List<ParteVentaDiario> parteVentaDiarios)
        {
            foreach (var parte in parteVentaDiarios)
            {
                ParteVentaDiario parteAux = repo.getById(parte.getPK());
                if (parteAux != null)
                {
                    parte.id = parteAux.id;
                    parte.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                    if(parte.saldo.MoneyAccount != parteAux.saldo.MoneyAccount)
                        repo.update(parte);
                }
                else
                {
                    parte.preInsertObjecto(VariablesEntorno.securityToken.token.Value);
                    repo.insert(parte);
                }               
            }
        }

        public List<ParteVentaDiario> revisarConciliacion(Conciliacion conciliacion)
        {
            try
            {
                List<ParteVentaDiario> partes = getByConciliacion(conciliacion);
                foreach (var parte in partes)
                {
                    parte.idConsiliacion.Value = conciliacion.id.Value;
                    parte.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                    repo.update(parte);
                }
                return partes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ParteVentaDiario> getByConciliacion(Conciliacion conciliacion)
        {
            try
            {
               return repo.getByConciliacion(conciliacion);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
