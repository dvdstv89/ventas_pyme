using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class PeriodoAbiertoRepository : BaseRepository<PeriodoAbierto, PeriodoAbiertoRepository, int>,ICrudRepository<PeriodoAbierto>, ISqlReaderble<PeriodoAbierto>
    {
        public PeriodoAbiertoRepository(PeriodoAbierto tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new PeriodoAbierto readSQLReader(object sqlReader)
        {   
            return new PeriodoAbierto((DbDataReader)sqlReader, tipoBaseDatos);           
        }      
        public new void insert(PeriodoAbierto periodoAbierto)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<PeriodoAbierto, int>(periodoAbierto, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(periodoAbierto.annoAbierto, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(periodoAbierto.mesAbierto, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(periodoAbierto.id, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(PeriodoAbierto periodoAbierto)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<PeriodoAbierto, int>(periodoAbierto, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(periodoAbierto.annoAbierto, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(periodoAbierto.mesAbierto, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Where(periodoAbierto.id, tipoBaseDatos));
                update(parameters);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.PeriodoAbierto_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
