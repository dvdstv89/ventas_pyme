using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using System.Numerics;
using Database.Class;

namespace ModelData.Repository
{
    internal class SecurityTokenRepository : BaseRepository<SecurityToken, SecurityTokenRepository, string>, ICrudRepository<SecurityToken>, ISqlReaderble<SecurityToken>
    {
        public SecurityTokenRepository(SecurityToken tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new SecurityToken readSQLReader(object sqlReader)
        {
            try
            {
               return new SecurityToken((DbDataReader)sqlReader, tipoBaseDatos); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(SecurityToken securityToken)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<SecurityToken,string>(securityToken, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(securityToken.token, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.empresa, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.complejos, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.grupoTiendas, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.permisos, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.gruposConciliacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.mac, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(securityToken.namePC, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Insert(securityToken.superadmin, tipoBaseDatos));                                       
                insert(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(SecurityToken securityToken)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<SecurityToken, string>(securityToken, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(securityToken.empresa, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.complejos, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.grupoTiendas, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.permisos, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.gruposConciliacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.denominacion, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.mac, tipoBaseDatos));
                parameters.Add(ParameterFactory.Update(securityToken.namePC, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(securityToken.superadmin, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Where(securityToken.token, tipoBaseDatos));
                update(parameters);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
        public SecurityToken getByToken(string token)
        {
            try
            {
                SecurityToken securityToken = new SecurityToken();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<string>(token, securityToken.token.ColumnName), tipoBaseDatos));
                List<SecurityToken> securityTokens = getBy(parameters);
                return (securityTokens.Count > 0) ? securityTokens[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new List<SecurityToken> getAllNotEliminated()
        {
            try
            {
                SecurityToken securityToken = new SecurityToken();
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, securityToken.isEliminada.ColumnName), tipoBaseDatos));
                parameters.Add(ParameterFactory.Order_By(securityToken.token.ColumnName, tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.SecurityToken_Local().updateSincronizadoTrue(id as Atributo_PK<string>);
        }
    }
}
