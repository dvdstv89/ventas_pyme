using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanServicioMetrocontadorRDB
    {
        private PlanServicioMetrocontadorRepository repo;
        public PlanServicioMetrocontadorRDB()
        {
            repo = RepositoryFactory.PlanServicioMetrocontador_Postgres();
        }
        public void insert(PlanServicioMetrocontador plan)
        {
            repo.insert(plan);
        }
    }
}
