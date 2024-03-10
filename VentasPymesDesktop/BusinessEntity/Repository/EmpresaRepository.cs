using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;
using System.Xml;
using System.Configuration;

namespace ModelData.Repository
{
    internal class EmpresaRepository : BaseRepository<Empresa, EmpresaRepository, int>,ICrudRepository<Empresa>, ISqlReaderble<Empresa>
    {
        public EmpresaRepository(Empresa tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Empresa readSQLReader(object sqlReader)
        {
            try
            {
                return new Empresa((DbDataReader)sqlReader, tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
        public new void insert(Empresa empresa)
        {           
            try
            {               
                List<Parameter> parameters = BaseModelRepository.insert<Empresa, int>(empresa, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(empresa.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(empresa.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(empresa.email, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(empresa.servidorSMTP, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(empresa.salarioJefesBrigada, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(empresa.salarioDependienteComercial, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Money(empresa.planVentaAnno, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Consumo(empresa.planElectricoAnno, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert_Consumo(empresa.planAguaAnno, tipoBaseDatos));
                base.insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(Empresa empresa)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<Empresa, int>(empresa, tipoBaseDatos);            
                parameters.Add(ParameterFactory.Update(empresa.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(empresa.email, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(empresa.servidorSMTP, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(empresa.salarioJefesBrigada, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(empresa.salarioDependienteComercial, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Money(empresa.planVentaAnno, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Consumo(empresa.planElectricoAnno, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update_Consumo(empresa.planAguaAnno, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(empresa.id, tipoBaseDatos));
                update(parameters);           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Empresa_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
