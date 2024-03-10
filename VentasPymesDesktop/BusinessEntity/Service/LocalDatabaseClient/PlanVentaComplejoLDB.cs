using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanVentaComplejoLDB
    {
        private PlanVentaComplejoRepository repo;
        public PlanVentaComplejoLDB()
        {
            repo = RepositoryFactory.PlanVentaComplejo_Local();
        }
        public void insert(PlanVentaComplejo plan)
        {
            repo.insert(plan);
        }
    }
}
