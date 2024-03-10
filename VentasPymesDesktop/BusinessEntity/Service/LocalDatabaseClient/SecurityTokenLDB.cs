using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{
    public class SecurityTokenLDB
    {
        private SecurityTokenRepository repo;
        public SecurityTokenLDB()
        {
            repo = RepositoryFactory.SecurityToken_Local();
        }
        public SecurityToken getSecurityTokenSistema()
        {
            try
            {
                List<SecurityToken> tokens = repo.getAll();
                return (tokens.Count > 0) ? tokens[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
        public void update(SecurityToken securityToken)
        {
            try
            {
                repo.update(securityToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromRemoteData(SecurityToken securityTokenRemoto)
        {
            try
            {
                if (securityTokenRemoto != null)
                {
                    update(securityTokenRemoto);                   
                }
                else
                {                   
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
