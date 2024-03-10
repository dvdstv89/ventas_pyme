using System.Collections.Generic;
using System;
using System.Data.Common;
using GlobalContracts.Repository;
using GlobalContracts.Model.DataSourse;
using GlobalContracts.Interface;
using GlobalContracts.Model;
using GlobalContracts.Atributos;
using System.Data;

namespace ExternalSystem.Repository
{
    public class EnviromentObjectDatasourseRepository : BaseRepository<EnviromentObjectDatasourse, EnviromentObjectDatasourseRepository>, ICrudRepository<EnviromentObjectDatasourse>, ISqlReaderble<EnviromentObjectDatasourse>, IService<EnviromentObjectDatasourse>
    {
        public EnviromentObjectDatasourseRepository(EnviromentObjectDatasourse tipo, EnviromentObjectDatasourse enviromentObject) : base(tipo, enviromentObject) { repo = this; }
        public new EnviromentObjectDatasourse readSQLReader(IDataReader sqlReader)
        {
            try
            {             
                return new EnviromentObjectDatasourse(sqlReader);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  
        public override void insert(EnviromentObjectDatasourse enviromentObject)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<EnviromentObjectDatasourse>(enviromentObject, tipoBaseDatos);              
                parameters.Add(ParameterFactory.Insert(enviromentObject.name));
                parameters.Add(ParameterFactory.Insert(enviromentObject.type));
                parameters.Add(ParameterFactory.Insert(enviromentObject.domain));     
                parameters.Add(ParameterFactory.Insert(enviromentObject.value));
                insert(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override void update(EnviromentObjectDatasourse enviromentObject)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<EnviromentObjectDatasourse>(enviromentObject, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(enviromentObject.name));
                parameters.Add(ParameterFactory.Update(enviromentObject.type));
                parameters.Add(ParameterFactory.Update(enviromentObject.domain));              
                parameters.Add(ParameterFactory.Update(enviromentObject.value));
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override List<EnviromentObjectDatasourse> inicializar()
        {
            try
            {
                EnviromentObjectDatasourse enviromentObject = new EnviromentObjectDatasourse (false);
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where<TipoEnviromentObject>(new Atributo<TipoEnviromentObject>(TipoEnviromentObject.Datasourse, enviromentObject.type.ColumnName), tipoBaseDatos));
                return base.getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
