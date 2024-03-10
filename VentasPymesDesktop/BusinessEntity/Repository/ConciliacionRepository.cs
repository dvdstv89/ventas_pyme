using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;

namespace ModelData.Repository
{
    internal class ConciliacionRepository : BaseRepository<Conciliacion, ConciliacionRepository, string>,ICrudRepository<Conciliacion>, ISqlReaderble<Conciliacion>
    {
        public ConciliacionRepository(Conciliacion tipo,  string conextionString, TipoBaseDatos tipoBaseDatos): base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Conciliacion readSQLReader(object sqlReader)
        {
            try
            {
               return new Conciliacion((DbDataReader)sqlReader, tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(Conciliacion consiliacion)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<Conciliacion, string>(consiliacion, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(consiliacion.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(consiliacion.documento, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(consiliacion.complejo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(consiliacion.grupoConciliacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(consiliacion.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_DateTime(consiliacion.fechaInicio, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_DateTime(consiliacion.fechaFin, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(consiliacion.saldoVenta, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(consiliacion.saldoComision, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(consiliacion.existenDiferencias, tipoBaseDatos));              
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(Conciliacion consiliacion)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<Conciliacion, string>(consiliacion, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(consiliacion.documento, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(consiliacion.complejo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(consiliacion.grupoConciliacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(consiliacion.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_DateTime(consiliacion.fechaInicio, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_DateTime(consiliacion.fechaFin, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(consiliacion.saldoVenta, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(consiliacion.saldoComision, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(consiliacion.existenDiferencias, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Where(consiliacion.id, tipoBaseDatos));
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public Conciliacion ultimaConciliacionRealizada(GrupoConciliacion grupo, Complejo complejo)
        {
            try
            {
                Conciliacion conciliacion = new Conciliacion();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<string>(grupo.getId(), conciliacion.grupoConciliacion.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<string>(complejo.getId(), conciliacion.complejo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_MAX_DateTime(conciliacion.fechaFin.ColumnName, tipoBaseDatos));
                List<Conciliacion> conciliaciones = getBy(parameters);
                return (conciliaciones.Count > 0) ? conciliaciones[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Conciliacion findByParteVenta(ParteVentaDiario parte)
        {
            try
            {
                Tienda tienda = new Tienda();
                FormaPago formaPago = new FormaPago();              
                GrupoConciliacion grupo = new GrupoConciliacion();
                string query = $"SELECT {aliasTableName}.* from {tableName} {aliasTableName} " +
                $"join {grupo.getTableName()} {grupo.getAliasTableName()} on {aliasTableName}.{data.grupoConciliacion.ColumnName} = {grupo.getAliasTableName()}.{grupo.id.ColumnName}" +
                $" join {formaPago.getTableName()} {formaPago.getAliasTableName()} on {grupo.getAliasTableName()}.{grupo.id.ColumnName} = {formaPago.getAliasTableName()}.{formaPago.grupoConciliacion.ColumnName}" +
                $" join  {tienda.getTableName()} {tienda.getAliasTableName()} on {tienda.getAliasTableName()}.{tienda.idComplejo.ColumnName} = {aliasTableName}.{data.complejo.ColumnName}";               
                query += " {0}";
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_Alias(tienda.getAliasTableName(), new Atributo<int>(parte.idTienda.Value, tienda.id.ColumnName), tipoBaseDatos));               
                parameters.Add(ParameterFactory.Where_Alias(formaPago.getAliasTableName(), new Atributo<string>(parte.formaPago.getId(), formaPago.id.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime_Reverse(aliasTableName, parte.fecha,  data.fechaInicio, data.fechaFin, tipoBaseDatos));
                List<Conciliacion> conciliaciones = selectQueryNative(query, parameters);
                return (conciliaciones.Count > 0) ? conciliaciones[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Conciliacion> getNoSincronizadosMesActual()
        {
            try
            {              
                List<Parameter> parameters = new List<Parameter>();
                data.fechaInicio.setFecha(VariablesEntorno.primeraFechaValida);
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime(new Atributo_Datetime(VariablesEntorno.primeraFechaValida, data.fechaInicio.ColumnName), new Atributo_Datetime(VariablesEntorno.ultimaFechaValida, data.fechaFin.ColumnName), tipoBaseDatos));
                      
                if (tipoBaseDatos == TipoBaseDatos.Local)
                    parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, data.isSincronizada.ColumnName), tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
        public List<Conciliacion> getByComplejoAndGrupo(string idComplejo, string idGrupo)
        {
            try
            {              
                List<Parameter> parameters = new List<Parameter>();
                data.fechaInicio.setFecha(VariablesEntorno.primeraFechaValida);
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime(new Atributo_Datetime(VariablesEntorno.primeraFechaValida, data.fechaInicio.ColumnName), new Atributo_Datetime(VariablesEntorno.ultimaFechaValida, data.fechaFin.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<string>(idComplejo, data.complejo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<string>(idGrupo, data.grupoConciliacion.ColumnName), tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Conciliacion_Local().updateSincronizadoTrue(id as Atributo_PK<string>);
        }
    }
}
