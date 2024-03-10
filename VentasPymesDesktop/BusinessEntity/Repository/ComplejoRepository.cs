using System.Collections.Generic;
using ModelData.Model;
using System;
using Database;
using System.Data.Common;
using Database.Class;

namespace ModelData.Repository
{
    internal class ComplejoRepository : BaseRepository<Complejo, ComplejoRepository, int>, ICrudRepository<Complejo>, ISqlReaderble<Complejo>
    {
        public ComplejoRepository(Complejo tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Complejo readSQLReader(object sqlReader)
        {
            try
            {
                return new Complejo((DbDataReader)sqlReader,tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(Complejo complejo)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<Complejo, int>(complejo, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(complejo.denominacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(complejo.idEmpresa, tipoBaseDatos));  
                parameters.Add(ParameterFactory.Insert(complejo.id, tipoBaseDatos));             
                parameters.Add(ParameterFactory.Insert(complejo.email, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(complejo.tipoDepartamento, tipoBaseDatos));
                insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(Complejo complejo)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<Complejo, int>(complejo, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(complejo.denominacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(complejo.idEmpresa, tipoBaseDatos));  
                parameters.Add(ParameterFactory.Update(complejo.email, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Update(complejo.tipoDepartamento, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(complejo.id, tipoBaseDatos));
                update(parameters);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Complejo_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
