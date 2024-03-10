using ExternalSystem.Service;
using GlobalContracts;
using GlobalContracts.Model.DataSourse;
using System.Collections.Generic;

namespace ExternalSystem.Data
{
    public static class EnviromentObjectDataSourseData
    {
        public static List<EnviromentObjectDatasourse> datasourses  = new List<EnviromentObjectDatasourse>();

        public static void inicializar(bool forceInicialization = false)
        {
            try
            {
                if (datasourses.Count == 0 || forceInicialization)
                {
                    datasourses = new EnviromentObjectDatasourseService().inicializar();
                    datasourses.Add(VariablesEntorno.defaultConection);
                    datasourses.Add(VariablesEntorno.nullConection);
                }
            }
            catch
            {
                datasourses = new List<EnviromentObjectDatasourse>
                {
                    VariablesEntorno.defaultConection,
                    VariablesEntorno.nullConection
            };
            }
           
        }      
        public static List<string> getAllAsStringList()
        {
            inicializar();
            List<string> result = new List<string>();
            foreach (EnviromentObjectDatasourse enviromentObject in datasourses)
            {
                result.Add(enviromentObject.name.Value);
            }
            return result;
        }
        public static EnviromentObjectDatasourse getById(string id)
        {
            inicializar();
            return datasourses.Find(f => f.id.getId().Equals(id));
        }
    }
}
