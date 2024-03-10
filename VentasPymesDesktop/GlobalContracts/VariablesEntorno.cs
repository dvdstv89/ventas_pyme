using GlobalContracts.Enum;
using GlobalContracts.Model;
using System;
using System.Linq;

namespace GlobalContracts
{
    public static class VariablesEntorno
    {
        public static Idioma idioma = Idioma.SPANISH;
        //public static string defaultDomain = "privateDomain";
        //public static string defaultDatasourseName = "default";
        //public static string defaultUser = "SetupAdmin";
        //public static string defaultPass = "caracol";
        //public static string defaultEmail = "david.estevez@veste.caracol.cu";
        //public static string defaultRol = "Superadmin";
        //public static string defaultAuthor = "David Estévez Díaz";
        //public static string defaultLogDatasourseName = "log";
        public static string nombrePC = Environment.MachineName;      
        public static string mac = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        public static Session session;
        //public static EnviromentObjectDatasourse defaultConection;
        //public static EnviromentObjectDatasourse logConection;
        //public static EnviromentObjectDatasourse nullConection;      
    }
}
