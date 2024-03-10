using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using ModelData.Service.LocalDatabaseClient;

namespace ModelData.Repository
{
    internal class PlanServicioMensualRepository : BaseRepository<PlanServicioMensual, PlanServicioMensualRepository, string>,ICrudRepository<PlanServicioMensual>, ISqlReaderble<PlanServicioMensual>
    {
        public PlanServicioMensualRepository(PlanServicioMensual tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new PlanServicioMensual readSQLReader(object sqlReader)
        {
            try
            {
                return new PlanServicioMensual((DbDataReader)sqlReader, tipoBaseDatos);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(PlanServicioMensual planServicioMensual)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<PlanServicioMensual, string>(planServicioMensual, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(planServicioMensual.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_DateTime(planServicioMensual.fecha, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Consumo(planServicioMensual.planMes, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert_Consumo(planServicioMensual.realConsumidoMes, tipoBaseDatos));            
                parameters.Add(ParameterFactory.Insert(planServicioMensual.tipoServicio, tipoBaseDatos));
                base.insert(parameters, false);
                if (planServicioMensual.planServicioComplejo != null)
                {
                    if (tipoBaseDatos == TipoBaseDatos.Local)
                    {
                        new PlanServicioComplejoLDB().insert(planServicioMensual.planServicioComplejo);
                    }
                    else
                    {
                        new PlanServicioComplejoRDB().insert(planServicioMensual.planServicioComplejo);
                    }
                }
                else
                {
                    if (tipoBaseDatos == TipoBaseDatos.Local)
                    {
                        new PlanServicioMetrocontadorLDB().insert(planServicioMensual.planServicioMetrocontador);
                    }
                    else
                    {
                        new PlanServicioMetrocontadorRDB().insert(planServicioMensual.planServicioMetrocontador);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(PlanServicioMensual planVentaMensual)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<PlanServicioMensual, string>(planVentaMensual, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update_Consumo(planVentaMensual.planMes, tipoBaseDatos));   
                parameters.Add(ParameterFactory.Update_Consumo(planVentaMensual.realConsumidoMes, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Where(planVentaMensual.id, tipoBaseDatos));             
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     

        public List<PlanServicioMensual> getByMetrocontador(int idMetrocontador)
        {
            try
            {
                PlanServicioMetrocontador planServicioMetrocontador = new PlanServicioMetrocontador();
                string query = $"SELECT {aliasTableName}.* from {tableName} {aliasTableName} " +
                $"join {planServicioMetrocontador.getTableName()} {planServicioMetrocontador.getAliasTableName()} on {aliasTableName}.{data.id.ColumnName} = {planServicioMetrocontador.getAliasTableName()}.{planServicioMetrocontador.idPlanServicio.ColumnName}";
                query += " {0}";
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_Alias(planServicioMetrocontador.getAliasTableName(), new Atributo<int>(idMetrocontador, planServicioMetrocontador.idMetrocontador.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_Alias(aliasTableName, new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                return selectQueryNative(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PlanServicioMensual> getByComplejo(int idComplejo, int idServicio)
        {
            try
            {
                PlanServicioComplejo planServicioComplejo = new PlanServicioComplejo();
                string query = $"SELECT {aliasTableName}.* from {tableName} {aliasTableName} " +
                $"join {planServicioComplejo.getTableName()} {planServicioComplejo.getAliasTableName()} on {aliasTableName}.{data.id.ColumnName} = {planServicioComplejo.getAliasTableName()}.{planServicioComplejo.idPlanServicio.ColumnName}";
                query += " {0}";
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where_Alias(planServicioComplejo.getAliasTableName(), new Atributo<int>(idComplejo, planServicioComplejo.idComplejo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_Alias(aliasTableName, new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_Alias(aliasTableName, new Atributo<int>(idServicio, data.tipoServicio.ColumnName), tipoBaseDatos));
                return selectQueryNative(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PlanServicioMensual> getByAnno()
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                List<PlanServicioMensual> planesServicioMensual = getBy(parameters);
                return planesServicioMensual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PlanServicioMensual> getByAnnoNoSincronizados()
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(true, data.isActivo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, data.isSincronizada.ColumnName), tipoBaseDatos));
                List<PlanServicioMensual> planesServicioMensual = getBy(parameters);
                return planesServicioMensual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insertList(List<PlanServicioMensual> planVentas)
        {
            for (int i = 0; i < planVentas.Count; i++)
            {
                insert(planVentas[i]);
            }
        }      
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.PlanServicioMensual_Local().updateSincronizadoTrue(id as Atributo_PK<string>);
        }
    }
}
