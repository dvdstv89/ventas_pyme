using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class PeriodoAbiertoRDB
    {
        private PeriodoAbiertoRepository repo;
        public PeriodoAbiertoRDB()
        {
            repo = RepositoryFactory.PeriodoAbierto_Postgres();
        }
        public List<PeriodoAbierto> getAll()
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
        public PeriodoAbierto getById(Atributo_PK<int> id)
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
        public string getStringPeriodoById(Atributo_PK<int> id)
        {
            try
            {
                string result = string.Empty;
                PeriodoAbierto periodo = getById(id);
                result = ((int)periodo.mesAbierto.Value).ToString() + ";" + periodo.annoAbierto.ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void actualizarRemotoDesdeLocal(PeriodoAbierto periodoAbiertoLocal)
        {
            try
            {
                PeriodoAbierto periodoAbiertoRemoto = getById(periodoAbiertoLocal.getPK());
                //actualizar si esta
                if (periodoAbiertoRemoto != null)
                {
                    repo.update(periodoAbiertoLocal);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
