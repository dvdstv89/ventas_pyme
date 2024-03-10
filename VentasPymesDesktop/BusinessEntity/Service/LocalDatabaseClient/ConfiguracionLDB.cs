using ModelData.Model;
using ModelData.Repository;
using System;

namespace ModelData.Service.LocalDatabaseClient
{ 
    public class ConfiguracionLDB
    {
        private ConfiguracionRepository repo;
        public ConfiguracionLDB()
        {
            repo = RepositoryFactory.Configuracion_Local();
        }
        public Configuracion getConfiguracion()
        {
            try
            {
                return repo.getById(VariablesEntorno.idConfiguracionSistema);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    
        public void update(Configuracion configuracion)
        {
            try
            {
                repo.update(configuracion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
