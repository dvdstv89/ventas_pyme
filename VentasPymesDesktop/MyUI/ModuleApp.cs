using GlobalContracts;
using GlobalContracts.Enum;
using GlobalContracts.Model;
using GlobalContracts.Model.Mensaje;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace MyUI
{
    public class ModuleApp : BaseModuleApp
    {
        private static string nameApp = "MyUI";
        private static double versionApp = 1.0;
        private static DateTime fechaApp = new DateTime(2023, 10, 7);
        public ModuleApp() : base(nameApp, versionApp, fechaApp, VariablesEntorno.defaultAuthor, true, false, VariablesEntorno.defaultConection)
        {
            this.id.setValue(ModulesID.MyUI.ToString());
        }
        public ModuleApp(DbDataReader sqlReader) : base(sqlReader) { }
        protected override void setNameByUI()
        {
            nameByUI = new Mensaje(MensajeType.Title, "Módulo de Aplicación", "App Module");
        }     
        public override List<Script> LiquibaseScript()
        {
            // Implementa la lógica para generar el script de la base de datos
            // "CREATE TABLE ...";
            return default;
        }
        protected override void initInternalData()
        {
            this.versionInstalada.setValue(versionApp);
            this.obligatorio = true;
            return;
        }
    }
}
