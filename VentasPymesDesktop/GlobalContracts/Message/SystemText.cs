namespace GlobalContracts.Message
{
    public static class SystemText
    {
        public static string CHECK_CONEXION = MensajeFactory.SYSTEM("Conectando con la base de datos", "Connecting to the database").getMensaje();
        public static string CHECK_ESTRUCTURA = MensajeFactory.SYSTEM("Revisando estructura de datos", "Reviewing data structure").getMensaje();
        public static string CHECK_DATOS_INICIALES = MensajeFactory.SYSTEM("Revisando datos iniciales", "Reviewing initial data").getMensaje();
        public static string CHECK_MODULOS = MensajeFactory.SYSTEM("Revisando versiones de los modulos", "Reviewing module versions").getMensaje();
        public static string CHECK_LOGS = MensajeFactory.SYSTEM("Revisando modulos de registros", "Reviewing logs module").getMensaje();
        public static string FOOTER = MensajeFactory.SYSTEM("PV_Caracol Vedado - Versión 0.1 beta", "PV_Caracol Vedado - Versión 0.1 beta").getMensaje();         
    }
}
