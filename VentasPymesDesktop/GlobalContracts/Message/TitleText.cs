
namespace GlobalContracts.Message
{
    public static class TitleText
    {
        public static string COMUN_DATA = MensajeFactory.TITLE("Datos Comunes", "Comun Data").getMensaje();
        public static string DATASOURSE = MensajeFactory.TITLE("Datasourse", "Datasourse").getMensaje();
        public static string ERROR = MensajeFactory.TITLE("Error", "Error").getMensaje();
        public static string SUCCESS = MensajeFactory.TITLE("Guardado", "Saved").getMensaje();
        public static string EXCEPTION = MensajeFactory.TITLE("Excepción", "Exception").getMensaje();       
    }
}
