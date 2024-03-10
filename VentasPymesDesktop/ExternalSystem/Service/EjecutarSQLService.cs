using System;
using GlobalContracts.Model.DataSourse;
using GlobalContracts.Model;
using GlobalContracts.Atributos;
using ExternalSystem.Data;

namespace ExternalSystem.Service
{
    public static class EjecutarSQLService
    {
        public static bool ExisteTabla(Tabla tabla, string idEnviromentObjectDatasourse)
        {
            try
            {
                EnviromentObjectDatasourse enviromentObject = EnviromentObjectDataSourseData.getById(idEnviromentObjectDatasourse);
                DbConection connection = new DbConection(enviromentObject);
                return connection.ExisteTabla(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool ProbarConexion(EnviromentObjectDatasourse enviromentObject)
        {
            try
            {
                DbConection connection = new DbConection(enviromentObject);
                try
                {
                    connection.openConnection();
                    connection.closeConection();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool EjecutarIntallScript(string script, string idEnviromentObjectDatasourse)
        {
            try
            {               
                 EnviromentObjectDatasourse enviromentObject = EnviromentObjectDataSourseData.getById(idEnviromentObjectDatasourse);
                 DbConection connection = new DbConection(enviromentObject);
                 return connection.EjecutarInstallScript(script);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
