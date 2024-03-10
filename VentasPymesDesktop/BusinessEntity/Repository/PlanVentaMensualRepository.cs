using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using System.Numerics;
using Database.Class;
using ModelData.Service.LocalDatabaseClient;

namespace ModelData.Repository
{
    internal class PlanVentaMensualRepository : BaseRepository<PlanVentaMensual, PlanVentaMensualRepository, string>,ICrudRepository<PlanVentaMensual>, ISqlReaderble<PlanVentaMensual>
    {
        public PlanVentaMensualRepository(PlanVentaMensual tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new PlanVentaMensual readSQLReader(object sqlReader)
        {
            try
            {
                return new PlanVentaMensual((DbDataReader)sqlReader, tipoBaseDatos);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(PlanVentaMensual planVentaMensual)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<PlanVentaMensual, string>(planVentaMensual, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(planVentaMensual.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_DateTime(planVentaMensual.fecha, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(planVentaMensual.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(planVentaMensual.saldo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(planVentaMensual.realDetallado, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(planVentaMensual.realResumido, tipoBaseDatos));
                base.insert(parameters,false);                

                if(planVentaMensual.planVentaComplejo!= null)
                {
                    if(tipoBaseDatos == TipoBaseDatos.Local)
                    {
                        new PlanVentaComplejoLDB().insert(planVentaMensual.planVentaComplejo);
                    }
                    else
                    {
                        new PlanVentaComplejoRDB().insert(planVentaMensual.planVentaComplejo);
                    }
                }
                else
                {
                    if (tipoBaseDatos == TipoBaseDatos.Local)
                    {
                        new PlanVentaTiendaLDB().insert(planVentaMensual.planVentaTienda);
                    }
                    else
                    {
                        new PlanVentaTiendaRDB().insert(planVentaMensual.planVentaTienda);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(PlanVentaMensual planVentaMensual)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<PlanVentaMensual, string>(planVentaMensual, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(planVentaMensual.moneda, tipoBaseDatos));                 
                parameters.Add(ParameterFactory.Update_Money(planVentaMensual.saldo, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(planVentaMensual.realDetallado, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(planVentaMensual.realResumido, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(planVentaMensual.id, tipoBaseDatos));               
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PlanVentaMensual> getByTienda(int idTienda)
        {
            try
            {
                PlanVentaTienda planVentaTienda = new PlanVentaTienda();
                string query = $"SELECT {aliasTableName}.* from {tableName} {aliasTableName} " +
                $"join {planVentaTienda.getTableName()} {planVentaTienda.getAliasTableName()} on {aliasTableName}.{data.id.ColumnName} = {planVentaTienda.getAliasTableName()}.{planVentaTienda.idPlanVenta.ColumnName}";               
                query += " {0}";
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_Alias(planVentaTienda.getAliasTableName(), new Atributo<int>(idTienda, planVentaTienda.idTienda.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_Alias(aliasTableName, new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                return selectQueryNative(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PlanVentaMensual> getByComplejo(int idComplejo)
        {
            try
            {
                PlanVentaComplejo planVentaComplejo = new PlanVentaComplejo();
                string query = $"SELECT {aliasTableName}.* from {tableName} {aliasTableName} " +
                $"join {planVentaComplejo.getTableName()} {planVentaComplejo.getAliasTableName()} on {aliasTableName}.{data.id.ColumnName} = {planVentaComplejo.getAliasTableName()}.{planVentaComplejo.idPlanVenta.ColumnName}";
                query += " {0}";
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_Alias(planVentaComplejo.getAliasTableName(), new Atributo_PK<int>(idComplejo, planVentaComplejo.idComplejo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_Alias(aliasTableName, new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                return selectQueryNative(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      

        public List<PlanVentaMensual> getByAnno()
        {
            try
            {               
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                List<PlanVentaMensual> planesVentaMensual = getBy(parameters);
                return planesVentaMensual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PlanVentaMensual> getByAnnoNoSincronizados()
        {
            try
            {              
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, data.isSincronizada.ColumnName), tipoBaseDatos));                      
                List<PlanVentaMensual> planesVentaMensual = getBy(parameters);
                return planesVentaMensual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insertList(List<PlanVentaMensual> planVentas)
        {
            for (int i = 0; i < planVentas.Count; i++)
            {
                insert(planVentas[i]);
            }
        }      
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.PlanVentaMensual_Local().updateSincronizadoTrue(id as Atributo_PK<string>);
        }
    }
}
