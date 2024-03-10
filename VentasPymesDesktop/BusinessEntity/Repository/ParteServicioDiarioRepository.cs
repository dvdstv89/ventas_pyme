using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;

namespace ModelData.Repository
{
    internal class ParteServicioDiarioRepository : BaseRepository<ParteServicioDiario, ParteServicioDiarioRepository, string>,ICrudRepository<ParteServicioDiario>, ISqlReaderble<ParteServicioDiario>
    {
        public ParteServicioDiarioRepository(ParteServicioDiario tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new ParteServicioDiario readSQLReader(object sqlReader)
        {
            try
            {
                return new ParteServicioDiario((DbDataReader)sqlReader, tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public new void insert(ParteServicioDiario parteMetrocontador)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<ParteServicioDiario, string>(parteMetrocontador, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(parteMetrocontador.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_DateTime(parteMetrocontador.fecha, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(parteMetrocontador.lectura, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(parteMetrocontador.consumo, tipoBaseDatos)); 
                parameters.Add(ParameterFactory.Insert(parteMetrocontador.idMetro, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(parteMetrocontador.tipoServicio, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(ParteServicioDiario parteMetrocontador)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<ParteServicioDiario, string>(parteMetrocontador, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(parteMetrocontador.lectura, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(parteMetrocontador.consumo, tipoBaseDatos)); 
                parameters.Add(ParameterFactory.Where(parteMetrocontador.id, tipoBaseDatos));                
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ParteServicioDiario> getByMetrocontador(int idMetrocontador)
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<int>(idMetrocontador, data.idMetro.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where_BETWEEN_DateTime(new Atributo_Datetime(VariablesEntorno.primeraFechaValida, data.fecha.ColumnName), new Atributo_Datetime(VariablesEntorno.ultimaFechaValida, data.fecha.ColumnName), tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ParteServicioDiario> getNoSincronizadosMesActual()
        {
            try
            {
                ParteServicioDiario parte = new ParteServicioDiario();
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
        public ParteServicioDiario getByIdMetroFecha(int idMetro, DateTime fecha)
        {
            try
            {
                ParteServicioDiario parte = new ParteServicioDiario();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<int>(idMetro, parte.idMetro.ColumnName), tipoBaseDatos));            
                parameters.Add(ParameterFactory.Where_DateTime(new Atributo_Datetime(fecha, parte.fecha.ColumnName), tipoBaseDatos));
                List<ParteServicioDiario> partes = getBy(parameters);
                return (partes.Count > 0) ? partes[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.ParteServicioDiario_Local().updateSincronizadoTrue(id as Atributo_PK<string>);
        }
    }
}
