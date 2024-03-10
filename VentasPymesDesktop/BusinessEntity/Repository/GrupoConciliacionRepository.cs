using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;

namespace ModelData.Repository
{
    internal class GrupoConciliacionRepository : BaseRepository<GrupoConciliacion, GrupoConciliacionRepository, int>,ICrudRepository<GrupoConciliacion>, ISqlReaderble<GrupoConciliacion>
    {
        public GrupoConciliacionRepository(GrupoConciliacion tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new GrupoConciliacion readSQLReader(object sqlReader)
        {
            return new GrupoConciliacion((DbDataReader)sqlReader, tipoBaseDatos);           
        }      
        public new void insert(GrupoConciliacion grupoConsiliacion)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<GrupoConciliacion, int>(grupoConsiliacion, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(grupoConsiliacion.denominacion, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(grupoConsiliacion.moneda, tipoBaseDatos)); 
                parameters.Add(ParameterFactory.Insert_Money(grupoConsiliacion.comision, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(grupoConsiliacion.id, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(GrupoConciliacion grupoConsiliacion)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<GrupoConciliacion, int>(grupoConsiliacion, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(grupoConsiliacion.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(grupoConsiliacion.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(grupoConsiliacion.comision, tipoBaseDatos));
                base.update(parameters);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new List<GrupoConciliacion> inicializar()
        {
            try
            {
                GrupoConciliacion grupo = new GrupoConciliacion();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, grupo.isEliminada.ColumnName), tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.GrupoConciliacion_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
