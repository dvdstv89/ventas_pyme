using ExternalSystem.Repository;
using MyUI.Service;
using System;
using GlobalContracts.Model.DataSourse;
using GlobalContracts.Service;
using GlobalContracts.Message;
using ExternalSystem.UIController;
using System.Collections.Generic;
using ExternalSystem.Data;

namespace ExternalSystem.Service
{
    public class EnviromentObjectDatasourseService : BaseService<EnviromentObjectDatasourse, EnviromentObjectDatasourseRepository>
    {
        public EnviromentObjectDatasourseService()
        {           
            repo = RepositoryFactory.EnviromentObjectDatasourseRepository();
        }

       //gestionar enviroments
             

        public static bool CrearConectionDatabase(List<string> dominios, string idEnviromentObject)
        {
            try
            {
                EnviromentObjectDatasourse enviromentObjectDatasourse = ExisteEnviromentObject(idEnviromentObject);

                if (enviromentObjectDatasourse != null && ProbarDatasourse(enviromentObjectDatasourse, false))
                    return true;

                enviromentObjectDatasourse = (enviromentObjectDatasourse != null) ? enviromentObjectDatasourse : new EnviromentObjectDatasourse(true);
                return ConfigDatasourse_Form(new EnviromentObjectDatasourse(true), dominios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool ProbarDatasourse(EnviromentObjectDatasourse enviromentObject, bool showSuccessMessage = true)
        {
            try
            {
                bool result = EjecutarSQLService.ProbarConexion(enviromentObject);

                if (!result)
                    DialogService.ShowDialog(ErrorMessage.DATABASE_NO_DISPONIBLE);
                else if (showSuccessMessage)
                    DialogService.ShowDialog(SuccessMessage.PRUEBA_CONECTIVIDAD_DATABASE);

                return result;
            }
            catch (Exception ex)
            {
                if (showSuccessMessage)
                {
                    DialogService.ShowDialog(MensajeFactory.EXCEPTION(ex.Message));
                    return false;
                }
                throw new Exception(ex.Message);
            }
        }
        private static EnviromentObjectDatasourse ExisteEnviromentObject(string idEnviromentObject)
        {
            try
            {
                EnviromentObjectDatasourse enviromentObjectDatasourse = EnviromentObjectDataSourseData.getById(idEnviromentObject);
                return (enviromentObjectDatasourse!=null) ? enviromentObjectDatasourse : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static bool ConfigDatasourse_Form(EnviromentObjectDatasourse enviromentObject, List<string> dominios)
        {
            try
            {
                ExternalSystemUIController<EnviromentObjectDatasourse> externalSystemUIController = new ExternalSystemUIController<EnviromentObjectDatasourse>(enviromentObject, dominios, true, true);
                externalSystemUIController.ejecutar().ShowDialog();
                if (externalSystemUIController.isValidado)
                {
                    EnviromentObjectDatasourse newEnviromentObjectDatasourse = externalSystemUIController.enviromentObject as EnviromentObjectDatasourse;
                    GuardarEnviromentObject(newEnviromentObjectDatasourse);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void GuardarEnviromentObject(EnviromentObjectDatasourse enviromentObject)
        {
            try
            {
                new EnviromentObjectDatasourseService().save(enviromentObject);
                EnviromentObjectDataSourseData.inicializar(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
