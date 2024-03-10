using GlobalContracts;
using GlobalContracts.Model.DataSourse;

namespace ExternalSystem.Repository
{
    internal static class RepositoryFactory
    {
        public static EnviromentObjectDatasourseRepository EnviromentObjectDatasourseRepository()
        {
            return new EnviromentObjectDatasourseRepository(new EnviromentObjectDatasourse(false), VariablesEntorno.defaultConection);
        } 
    }
}
