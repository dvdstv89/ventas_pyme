using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanVentaTiendaRDB
    {
        private PlanVentaTiendaRepository repo;
        public PlanVentaTiendaRDB()
        {
            repo = RepositoryFactory.PlanVentaTienda_Postgres();
        }  
        public void insert(PlanVentaTienda plan)
        {
            repo.insert(plan);
        }
    }
}
