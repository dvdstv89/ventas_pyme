using System.Collections.Generic;
using ModelData.Model;
using System;
using Database;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class PlanServicioMetrocontadorRepository : BaseRepository<PlanServicioMetrocontador, PlanServicioMetrocontadorRepository, int>, ICrudRepository<PlanServicioMetrocontador>, ISqlReaderble<PlanServicioMetrocontador>
    {
        public PlanServicioMetrocontadorRepository(PlanServicioMetrocontador tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new PlanServicioMetrocontador readSQLReader(object sqlReader)
        {
            try
            {
                return new PlanServicioMetrocontador((DbDataReader)sqlReader);                           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public new void insert(PlanServicioMetrocontador plan)
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Insert(plan.idPlanServicio, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(plan.idMetrocontador, tipoBaseDatos));
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
            RepositoryFactory.PlanServicioMetrocontador_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
