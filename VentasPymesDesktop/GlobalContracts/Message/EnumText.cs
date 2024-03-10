namespace GlobalContracts.Message
{
    public class EnumText
    {
        public static string TIPO_BASE_DATOS_LOCAL = MensajeFactory.ENUM("Local", "Local").getMensaje();
        public static string TIPO_BASE_DATOS_POSTGRES = MensajeFactory.ENUM("Postgres", "Postgres").getMensaje();
        public static string TIPO_BASE_DATOS_SQLSERVER = MensajeFactory.ENUM("SqlServer", "SqlServer").getMensaje();
        public static string TIPO_BASE_DATOS_SQLITE = MensajeFactory.ENUM("Sqlite", "Sqlite").getMensaje();
        public static string TIPO_ENVIROMENT_OBJECT_DATASOURSE = MensajeFactory.ENUM("Datasourse", "Datasourse").getMensaje();
        public static string VERSION_MODULO_STATUS_OBSOLETO = MensajeFactory.ENUM("Obsoleto", "Old").getMensaje();
        public static string VERSION_MODULO_STATUS_CORRECTO = MensajeFactory.ENUM("OK", "OK").getMensaje();
        public static string VERSION_MODULO_STATUS_NUEVA_VERSION = MensajeFactory.ENUM("Nueva", "New").getMensaje();
    }
}
