using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;

namespace ModelData.Repository
{
    internal class TiendaRepository : BaseRepository<Tienda, TiendaRepository, int>, ICrudRepository<Tienda>, ISqlReaderble<Tienda>
    {
        public TiendaRepository(Tienda tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new Tienda readSQLReader(object sqlReader)
        {
            try
            {             
                return new Tienda((DbDataReader)sqlReader, tipoBaseDatos);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  
        public new void insert(Tienda tienda)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<Tienda, int>(tienda, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(tienda.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.isAbierta, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(tienda.idComplejo, tipoBaseDatos));                         
                parameters.Add(ParameterFactory.Insert(tienda.email, tipoBaseDatos));            
                parameters.Add(ParameterFactory.Insert(tienda.ordenComercial, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.cantidadMaximaTrabajadores, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.cantidadRealTrabajadores, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.cantidadJefeBrigada, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.horarioServicio, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.grupoTienda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(tienda.id, tipoBaseDatos));
                insert(parameters, false);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(Tienda tienda)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<Tienda, int>(tienda, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(tienda.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.moneda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.isAbierta, tipoBaseDatos));            
                parameters.Add(ParameterFactory.Update(tienda.idComplejo, tipoBaseDatos));                        
                parameters.Add(ParameterFactory.Update(tienda.email, tipoBaseDatos));             
                parameters.Add(ParameterFactory.Update(tienda.ordenComercial, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.cantidadMaximaTrabajadores, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.cantidadRealTrabajadores, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.cantidadJefeBrigada, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.horarioServicio, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(tienda.grupoTienda, tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(tienda.id, tipoBaseDatos));
                update(parameters);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }            
        public List<Tienda> getActivasByComplejo(int idComplejo)
        {
            try
            {
                Tienda tienda = new Tienda();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<int>(idComplejo, tienda.idComplejo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, tienda.isEliminada.ColumnName), tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Tienda> getActivasByComplejoNotSincronizados(string idComplejo)
        {
            try
            {
                Tienda tienda = new Tienda();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<string>(idComplejo, tienda.idComplejo.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, tienda.isSincronizada.ColumnName), tipoBaseDatos));                 
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.Tienda_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
    }
}
