using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;

namespace ModelData.Repository
{
    internal class ParteVentaDiarioRepository : BaseRepository<ParteVentaDiario, ParteVentaDiarioRepository, string>,ICrudRepository<ParteVentaDiario>, ISqlReaderble<ParteVentaDiario>
    {
        public ParteVentaDiarioRepository(ParteVentaDiario tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new ParteVentaDiario readSQLReader(object sqlReader)
        {
            try
            {
                return new ParteVentaDiario((DbDataReader)sqlReader, tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public new void insert(ParteVentaDiario parteVentaDiario)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<ParteVentaDiario, string>(parteVentaDiario, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(parteVentaDiario.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_DateTime(parteVentaDiario.fecha, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(parteVentaDiario.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(parteVentaDiario.formaPago, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(parteVentaDiario.saldo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(parteVentaDiario.idConsiliacion, tipoBaseDatos));            
                parameters.Add(ParameterFactory.Insert_Money(parteVentaDiario.comision, tipoBaseDatos));           
                parameters.Add(ParameterFactory.Insert(parteVentaDiario.idTienda, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(ParteVentaDiario parteVentaDiario)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<ParteVentaDiario, string>(parteVentaDiario, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(parteVentaDiario.moneda, tipoBaseDatos));                
                parameters.Add(ParameterFactory.Update_Money(parteVentaDiario.saldo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(parteVentaDiario.idConsiliacion, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update_Money(parteVentaDiario.comision, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(parteVentaDiario.id, tipoBaseDatos));
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ParteVentaDiario> getNoSincronizadosMesActual()
        {
            try
            {
                ParteVentaDiario parte = new ParteVentaDiario();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime(new Atributo_Datetime(VariablesEntorno.primeraFechaValida, parte.fecha.ColumnName), new Atributo_Datetime(VariablesEntorno.ultimaFechaValida, parte.fecha.ColumnName), tipoBaseDatos));
                if (tipoBaseDatos == TipoBaseDatos.Local)
                    parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, parte.isSincronizada.ColumnName), tipoBaseDatos));
                return getBy(parameters);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        public List<ParteVentaDiario> getByTienda(int idTienda)
        {            
            try
            {               
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<int>(idTienda, data.idTienda.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime(new Atributo_Datetime(VariablesEntorno.primeraFechaValida, data.fecha.ColumnName), new Atributo_Datetime(VariablesEntorno.ultimaFechaValida, data.fecha.ColumnName), tipoBaseDatos));
                return getBy(parameters); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ParteVentaDiario> getByConciliacion(Conciliacion conciliacion)
        {
            try
            {
                Tienda tienda = new Tienda();
                FormaPago formaPago = new FormaPago();
                Complejo complejo = new Complejo();

                string query = $"SELECT {aliasTableName}.* from {tableName} {aliasTableName} " +
                $"join {tienda.getTableName()} {tienda.getAliasTableName()} on {aliasTableName}.{data.idTienda.ColumnName} = {tienda.getAliasTableName()}.{Tienda.ID}" +
                $" join  {complejo.getTableName()} {complejo.getAliasTableName()} on {tienda.getAliasTableName()}.{tienda.idComplejo.ColumnName} = {complejo.getAliasTableName()}.{Complejo.ID}" +
                $" join {formaPago.getTableName()} {formaPago.getAliasTableName()} on {aliasTableName}.{data.formaPago.ColumnName} = {formaPago.getAliasTableName()}.{FormaPago.ID}";
                query +=" {0}";
                
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_Alias(formaPago.getAliasTableName(), new Atributo<string>(conciliacion.grupoConciliacion.getId(), formaPago.grupoConciliacion.ColumnName), tipoBaseDatos));                
                parameters.Add(ParameterFactory.Where_Alias(complejo.getAliasTableName(), new Atributo<string>(conciliacion.complejo.getId(), complejo.id.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime(new Atributo_Datetime(conciliacion.fechaInicio.Fecha, data.fecha.ColumnName), new Atributo_Datetime(conciliacion.fechaFin.Fecha, data.fecha.ColumnName), tipoBaseDatos));
                return selectQueryNative(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.ParteVentaDiario_Local().updateSincronizadoTrue(id as Atributo_PK<string>);
        }
    }
}
