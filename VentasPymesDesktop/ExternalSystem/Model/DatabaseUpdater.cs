using GlobalContracts.Model;
using System;


namespace ExternalSystem.Model
{
    internal class DatabaseUpdater
    {
        public static void UpdateDatabase(string applicationName, Version currentVersion)
        {
           // var scripts = ScriptManager.Scripts.Where(script => !script.IsExecuted).ToList();

            //foreach (var script in scripts)
            //{
            //    Console.WriteLine($"Applying script with Id {script.Id}: {script.Code}");
            //    ExecuteScript(script.Code);
            //    MarkScriptAsExecuted(script);
            //}
        }

        private static void ExecuteScript(string script)
        {
            // Implementa la lógica para ejecutar el script en la base de datos
            // (Dependerá del sistema de base de datos que estés utilizando)
            // Puedes utilizar ADO.NET, Entity Framework, u otra herramienta que prefieras.
            //Console.WriteLine($"Executing script: {script}");
        }

        private static void MarkScriptAsExecuted(Script script)
        {
           // script.IsExecuted = true;
            // Aquí puedes registrar en la base de datos que el script se ha ejecutado
            // Puedes usar Script.Id y applicationName para registrar en qué aplicación y script se ejecutó.
            //Console.WriteLine($"Marking script with Id {script.Id} as executed.");
        }

    }
}
