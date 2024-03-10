using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanServicioMetrocontadorLDB
    {
        private PlanServicioMetrocontadorRepository repo;
        public PlanServicioMetrocontadorLDB()
        {
            repo = RepositoryFactory.PlanServicioMetrocontador_Local();
        }
        public void insert(PlanServicioMetrocontador plan)
        {
            repo.insert(plan);
        }
    }
}
