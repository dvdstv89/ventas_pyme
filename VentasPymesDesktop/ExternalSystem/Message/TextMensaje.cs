using MyUI.Model;

namespace ExternalSystem.Message 
{
    internal static class TextMensaje
    {
        public static readonly MensajeText FICHERO_GUARDADO = new MensajeText("Fichero guardado satifactoriamente", "Fichero guardado satifactoriamente");
        public static readonly MensajeText API_REST_CONFIG = new MensajeText("Configurar ApiRest", "ApiRest Configuration");
        public static readonly MensajeText API_REST_TEST_OK = new MensajeText("Prueba realizada ok", "Prueba realizada ok");
        public static readonly MensajeText ABRIR_BACKEND_APP_ERROR = new MensajeText("El archivo del backend no fue encontrado en la ruta especificada.", "APP_ABRIENDO");       
    }
}
