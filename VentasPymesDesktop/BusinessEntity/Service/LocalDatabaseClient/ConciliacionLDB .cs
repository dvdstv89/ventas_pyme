using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class ConciliacionLDB
    {
        private ConciliacionRepository repo;
        public ConciliacionLDB()
        {
            repo = RepositoryFactory.Conciliacion_Local();
        }     

        public Conciliacion ultimaConciliacionRealizada(GrupoConciliacion grupo, Complejo complejo)
        {
            try
            {
                return repo.ultimaConciliacionRealizada(grupo, complejo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        public Conciliacion findByParteVenta(ParteVentaDiario parte)
        {
            try
            {
                return repo.findByParteVenta(parte);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void guardarConciliacion(Conciliacion conciliacion)
        {
            try
            {
                conciliacion.preInsertObjecto(VariablesEntorno.securityToken.token.Value);
                repo.insert(conciliacion);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateConciliacion(Conciliacion conciliacion)
        {
            try
            {
                conciliacion.setExistenDiferencias();
                conciliacion.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(conciliacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void update(Conciliacion conciliacion)
        {
            try
            {
                conciliacion.setExistenDiferencias();
                conciliacion.version.Value++;
                conciliacion.isSincronizada.Value = false;
                repo.update(conciliacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromRemoteData(List<Conciliacion> conciliacionesRemotas)
        {
            try
            {
                if (conciliacionesRemotas.Count > 0)
                {
                    foreach (Conciliacion conciliacion in conciliacionesRemotas)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(conciliacion);
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
        public List<Conciliacion> getByComplejoAndGrupo(string idComplejo, string idGrupo)
        {
            try
            {
                return repo.getByComplejoAndGrupo(idComplejo, idGrupo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
