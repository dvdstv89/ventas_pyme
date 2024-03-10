using System.Collections.Generic;
using ModelData.Model;
using System;
using Database;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class ConfiguracionRepository : BaseRepository<Configuracion, ConfiguracionRepository, int>, ICrudRepository<Configuracion>, ISqlReaderble<Configuracion>
    {
        public ConfiguracionRepository(Configuracion tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Configuracion readSQLReader(object sqlReader)
        {
            try
            {
                return new Configuracion((DbDataReader)sqlReader);                           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }  
        public new void update(Configuracion configuracion)
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Update(configuracion.urlApiRest, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(configuracion.stringPostgresDb, tipoBaseDatos));            
                parameters.Add(ParameterFactory.Update(configuracion.tokenCreador, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(configuracion.tokenModificador, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_DateTime(configuracion.fechaCreacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_DateTime(configuracion.fechaModificacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(configuracion.id, tipoBaseDatos));
                update(parameters);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Configuracion_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
