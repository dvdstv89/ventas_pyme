using System.Collections.Generic;
using ModelData.Model;
using System;
using Database;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class PlanVentaTiendaRepository : BaseRepository<PlanVentaTienda, PlanVentaTiendaRepository, int>, ICrudRepository<PlanVentaTienda>, ISqlReaderble<PlanVentaTienda>
    {
        public PlanVentaTiendaRepository(PlanVentaTienda tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new PlanVentaTienda readSQLReader(object sqlReader)
        {
            try
            {
                return new PlanVentaTienda((DbDataReader)sqlReader);                           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public new void insert(PlanVentaTienda plan)
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Insert(plan.idPlanVenta, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(plan.idTienda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(plan.anno, tipoBaseDatos));              
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
        public void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.PlanVentaTienda_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
