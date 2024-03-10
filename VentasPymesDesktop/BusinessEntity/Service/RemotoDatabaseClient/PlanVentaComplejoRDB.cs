using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanVentaComplejoRDB
    {
        private PlanVentaComplejoRepository repo;
        public PlanVentaComplejoRDB()
        {
            repo = RepositoryFactory.PlanVentaComplejo_Postgres();
        }
        public void insert(PlanVentaComplejo plan)
        {
            repo.insert(plan);
        }
    }
}
