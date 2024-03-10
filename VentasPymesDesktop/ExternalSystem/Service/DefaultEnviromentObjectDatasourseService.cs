using MyUI.Service;
using System.Collections.Generic;
using ExternalSystem.UIController;
using System;
using GlobalContracts.Model.DataSourse;
using GlobalContracts;
using GlobalContracts.Message;

namespace ExternalSystem.Service
{
    public class DefaultEnviromentObjectDatasourseService
    {       
        // esta conexcion por defecto nunca se configura en la base de datos. simpre esta en un fichero, es privada y no se puede editar
        // si da error se muestra el dialogo para repararla

        public static bool CrearConectionDefaultDatabase(List<string> dominios)
        {
            try
            {
                return (DefaultEnviromentObjectConfig_FromFile() && EnviromentObjectDatasourseService.ProbarDatasourse(VariablesEntorno.defaultConection, false))
                        ? true
                        : DefaultEnviromentObjectConfig_Form(dominios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static bool DefaultEnviromentObjectConfig_Form(List<string> dominios)
        {
            try
            {
                ExternalSystemUIController<EnviromentObjectDatasourse> externalSystemUIController = new ExternalSystemUIController<EnviromentObjectDatasourse>(VariablesEntorno.defaultConection, dominios, true, true);
                externalSystemUIController.ejecutar().ShowDialog();
                if (externalSystemUIController.isValidado)
                {
                    VariablesEntorno.defaultConection = externalSystemUIController.enviromentObject as EnviromentObjectDatasourse;
                    GuardarFichero();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static bool DefaultEnviromentObjectConfig_FromFile()
        {
            try
            {
                return (VariablesEntorno.defaultConection.isDefaultData && AbrirFichero()) ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static bool AbrirFichero()
        {
            try
            {
                FicheroService<EnviromentObjectDTO> ficheroService = new FicheroService<EnviromentObjectDTO>(new EnviromentObjectDTO());
                bool ficheroAbierto = ficheroService.AbrirFichero();
                if (ficheroAbierto)
                {
                    EnviromentObjectDatasourse temporal = new EnviromentObjectDatasourse(ficheroService.GetTipo());
                    if(temporal.mac == VariablesEntorno.mac && temporal.nombrePC == VariablesEntorno.nombrePC)
                    {
                        VariablesEntorno.defaultConection = temporal;
                    }
                    else
                    {
                        DialogService.ShowDialog(ErrorMessage.FICHERO_CONFIGURACION_CORRUPTO);
                        return false;
                    }
                   
                }
                return ficheroAbierto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static void GuardarFichero()
        {
            try
            {
                FicheroService<EnviromentObjectDTO> ficheroService = new FicheroService<EnviromentObjectDTO>(VariablesEntorno.defaultConection.getEnviromentObjectDTO());
                ficheroService.GuardarFichero();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
    }
}
