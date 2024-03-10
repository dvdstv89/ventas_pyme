using ModelData.Model;
using System;
using System.Collections.Generic;
using ModelData.Repository;
using Database;

namespace ModelData.Service.LocalDatabaseClient
{
    public class PlanVentaTiendaLDB
    {
        private PlanVentaTiendaRepository repo;
        public PlanVentaTiendaLDB()
        {
            repo = RepositoryFactory.PlanVentaTienda_Local();
        }  
        public void insert(PlanVentaTienda plan)
        {
            repo.insert(plan);
        }
    }
}
