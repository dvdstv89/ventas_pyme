using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class FormaPagoRepository : BaseRepository<FormaPago, FormaPagoRepository, int>,ICrudRepository<FormaPago>, ISqlReaderble<FormaPago>
    {
        public FormaPagoRepository(FormaPago tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }

        public new FormaPago readSQLReader(object sqlReader)
        {
            try
            {
                return new FormaPago((DbDataReader)sqlReader, tipoBaseDatos);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(FormaPago formaPago)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<FormaPago, int>(formaPago, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(formaPago.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(formaPago.moneda, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(formaPago.isResumen, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(formaPago.grupoConciliacion, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(formaPago.id, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(FormaPago formaPago)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<FormaPago, int>(formaPago, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(formaPago.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(formaPago.moneda, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(formaPago.isResumen, tipoBaseDatos));             
                parameters.Add(ParameterFactory.Update(formaPago.grupoConciliacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Where(formaPago.id, tipoBaseDatos));
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.FormaPago_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
