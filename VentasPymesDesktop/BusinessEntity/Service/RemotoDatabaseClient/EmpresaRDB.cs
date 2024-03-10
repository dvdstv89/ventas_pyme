using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class EmpresaRDB
    {
        private EmpresaRepository repo;
        public EmpresaRDB()
        {
            repo = RepositoryFactory.Empresa_Postgres();
        }       
        public Empresa getById(int id)
        {
            try
            {
                return repo.getById(new Atributo_PK<int> (id, BaseModel<Empresa, int>.ID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateEmpresa(Empresa empresa)
        {
            try
            {
                empresa.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
