using Database;
using ModelData.Model;
using ModelData.Repository;
using System;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PeriodoAbiertoLDB
    {
        private PeriodoAbiertoRepository repo;
        public PeriodoAbiertoLDB()
        {
            repo = RepositoryFactory.PeriodoAbierto_Local();
        }
        public PeriodoAbierto getPeriodoAbierto()
        {
            try
            {
                return repo.getById(VariablesEntorno.idPeriodoAbierto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromRemoteData(PeriodoAbierto periodoAbiertoRemoto)
        {
            try
            {
                if (periodoAbiertoRemoto != null)
                {
                    SicronizacionResult result = repo.sincronizarDatos(periodoAbiertoRemoto);
                    return (result != SicronizacionResult.Fail) ? true : false;
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
