using ModelData.Model;
using ModelData.Repository;
using System;
using Database;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class EmpresaLDB
    {
        private EmpresaRepository repo;
        public EmpresaLDB()
        {
            repo = RepositoryFactory.Empresa_Local();
        }
        public bool updateFromRemoteData(Empresa empresaRemoto)
        {
            try
            {
                if (empresaRemoto != null)
                {
                    SicronizacionResult result = repo.sincronizarDatos(empresaRemoto);         
                    return (result!= SicronizacionResult.Fail)? true : false;
                }
               return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Empresa> inicializar()
        {
            return repo.inicializar();
        }
        public void update(Empresa empresa)
        {
            try
            {
                repo.update(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
