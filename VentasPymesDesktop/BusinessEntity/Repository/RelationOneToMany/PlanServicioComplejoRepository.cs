using System.Collections.Generic;
using ModelData.Model;
using System;
using Database;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class PlanServicioComplejoRepository : BaseRepository<PlanServicioComplejo, PlanServicioComplejoRepository, int>, ICrudRepository<PlanServicioComplejo>, ISqlReaderble<PlanServicioComplejo>
    {
        public PlanServicioComplejoRepository(PlanServicioComplejo tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new PlanServicioComplejo readSQLReader(object sqlReader)
        {
            try
            {
                return new PlanServicioComplejo((DbDataReader)sqlReader);                           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public new void insert(PlanServicioComplejo plan)
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Insert(plan.idPlanServicio, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(plan.idComplejo, tipoBaseDatos));
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
            RepositoryFactory.PlanServicioComplejo_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
