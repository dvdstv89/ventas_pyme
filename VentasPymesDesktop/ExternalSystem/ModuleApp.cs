using ExternalSystem.Model;
using GlobalContracts;
using GlobalContracts.Enum;
using GlobalContracts.Message;
using GlobalContracts.Model;
using GlobalContracts.Model.DataSourse;
using GlobalContracts.Model.Mensaje;
using MyUI.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace ExternalSystem
{
    public class ModuleApp : BaseModuleApp
    {
        private static string nameApp = "External System";
        private static double versionApp = 1.0;
        private static DateTime fechaApp = new DateTime(2023, 10, 7);
        public ModuleApp(): base(nameApp, versionApp, fechaApp, VariablesEntorno.defaultAuthor, true,false,VariablesEntorno.defaultConection) 
        {
            this.id.setValue(ModulesID.ExternalSystem.ToString());
        }
        public ModuleApp(DbDataReader sqlReader) : base(sqlReader) { }
        protected override void setNameByUI()
        {
            nameByUI = new Mensaje(MensajeType.Title, "Módulo de Aplicación", "App Module");
        }
        public override string InstallScript()
        {
            throw new Exception("los servicios de DatabaseChangeLog interactuan a traves de scripts. Script no es una tabla sino un objeto de intercambio interno. Crear datasourse por defecto nulo para los modulos que trabajan offline");

            string script = new EnviromentObjectDatasourse(false).getCreateTableScript()
                            + new DatabaseChangeLog().getCreateTableScript();
            return script;
        }
        public override List<Script> LiquibaseScript()
        {

            // los servicios de DatabaseChangeLog interactuan a traves de scripts
            List<Script> scripts = new List<Script>();
           
            Script script = new Script();
            script.id = "5+5464";           
            script.version = 1.0;
            script.app = ModulesID.ExternalSystem.ToString();
            script.description = string.Empty;
            script.code = "CREATE TABLE ...";

            scripts.Add(script);
            return scripts;
        }
        protected override void initInternalData()
        {
            this.versionInstalada.setValue(versionApp);
            this.obligatorio = true;
            return;
        }
    }
}
