using MyUI.Model;

namespace NucleoEV.Message 
{
    internal static class TextMensajeNucleo
    {        
        public static readonly MensajeText APP_ABRIENDO = new MensajeText("APP_ABRIENDO", "APP_ABRIENDO");
        public static readonly MensajeText ABRIR_BACKEND_APP_ERROR = new MensajeText("El archivo del backend no fue encontrado en la ruta especificada.", "APP_ABRIENDO");
        public static readonly MensajeText METADADOS_INCORRECTOS = new MensajeText("Los datos de conexión son incorrectos", "La informacion del servicio externo no ha podido ser verificada");
        public static readonly MensajeText VERIFICANDO_CONEXION_SERVIDOR_ERROR = new MensajeText("La conexión con la API fue verificada", "La informacion del servicio externo no ha podido ser verificada");
    }
}
