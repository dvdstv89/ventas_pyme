using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanServicioComplejoLDB
    {
        private PlanServicioComplejoRepository repo;
        public PlanServicioComplejoLDB()
        {
            repo = RepositoryFactory.PlanServicioComplejo_Local();
        }
        public void insert(PlanServicioComplejo plan)
        {
            repo.insert(plan);
        }
    }
}
