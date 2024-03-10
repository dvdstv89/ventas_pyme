using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class SecurityTokenRDB
    {
        private SecurityTokenRepository repo;
        public SecurityTokenRDB()
        {
            repo = RepositoryFactory.SecurityToken_Postgres();
        }        
        public List<SecurityToken> getAllNotEliminated()
        {
            try
            {
                return repo.getAllNotEliminated();
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
               return repo.getByToken(token);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insertarToken(SecurityToken token)
        {
            try
            {
                token.preInsertObjecto(VariablesEntorno.securityToken.token.Value);
                repo.insert(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void actualizarToken(SecurityToken token)
        {
            try
            {
                token.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void eliminarToken(SecurityToken token)
        {
            try
            {
                token.isEliminada.Value = true;
                token.isActivo.Value = false;
                token.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
