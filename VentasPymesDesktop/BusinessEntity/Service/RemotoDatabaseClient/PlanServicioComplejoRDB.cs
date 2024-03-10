using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanServicioComplejoRDB
    {
        private PlanServicioComplejoRepository repo;
        public PlanServicioComplejoRDB()
        {
            repo = RepositoryFactory.PlanServicioComplejo_Postgres();
        }
        public void insert(PlanServicioComplejo plan)
        {
            repo.insert(plan);
        }
    }
}
