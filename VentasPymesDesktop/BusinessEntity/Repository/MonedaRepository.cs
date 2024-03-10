using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class MonedaRepository : BaseRepository<Moneda, MonedaRepository, int>,ICrudRepository<Moneda>, ISqlReaderble<Moneda>
    {
        public MonedaRepository(Moneda tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Moneda readSQLReader(object sqlReader)
        {
            try
            {
               return new Moneda((DbDataReader)sqlReader, tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(Moneda moneda)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<Moneda, int>(moneda, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(moneda.denominacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert_Money(moneda.tazaCambioRespectoDefecto, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(moneda.isByDefault, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(moneda.isOnline, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(moneda.id, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(Moneda moneda)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<Moneda, int>(moneda, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(moneda.denominacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update_Money(moneda.tazaCambioRespectoDefecto, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(moneda.isByDefault, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(moneda.isOnline, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(moneda.id, tipoBaseDatos));
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Moneda_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
