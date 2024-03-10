using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;

namespace ModelData.Repository
{
    internal class MetrocontadorRepository : BaseRepository<Metrocontador, MetrocontadorRepository, int>,ICrudRepository<Metrocontador>, ISqlReaderble<Metrocontador>
    {
        public MetrocontadorRepository(Metrocontador tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Metrocontador readSQLReader(object sqlReader)
        {
            try
            {
                return new Metrocontador((DbDataReader)sqlReader,tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(Metrocontador metrocontador)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<Metrocontador, int>(metrocontador, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(metrocontador.denominacion, tipoBaseDatos));             
                parameters.Add(ParameterFactory.Insert(metrocontador.tipoServicio, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(metrocontador.descripcion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(metrocontador.id, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(metrocontador.idComplejo, tipoBaseDatos)); 
                insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(Metrocontador metrocontador)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<Metrocontador, int>(metrocontador, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(metrocontador.denominacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(metrocontador.tipoServicio, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(metrocontador.descripcion, tipoBaseDatos)); 
                parameters.Add(ParameterFactory.Update(metrocontador.idComplejo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(metrocontador.id, tipoBaseDatos));
                update(parameters);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Metrocontador_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
