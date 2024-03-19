using FontAwesome.Sharp;
using MyUI.Enum;
using MyUI.Enum.Message;
using MyUI.Model;

namespace MyUI.Service
{
    public static class MensajeTextService
    {       
        private static IconChar defaultIconChar = IconChar.None;

        private static System.Drawing.Color BLACK = System.Drawing.Color.Black;

        public static MensajeLabel LABEL(MensajeText mensaje)
        {
            return new MensajeLabel(MensajeType.Label, mensaje.diccionario, BLACK, defaultIconChar);
        }
        public static MensajeLabel TITLE(MensajeText mensaje)
        {
            return new MensajeLabel(MensajeType.Title, mensaje.diccionario, BLACK, defaultIconChar);
        }
        public static MensajeLabel ENUM(MensajeText mensaje)
        {
            return new MensajeLabel(MensajeType.Enum, mensaje.diccionario, BLACK,  defaultIconChar);
        }
        public static MensajeLabel SYSTEM(MensajeText mensaje)
        {
            return new MensajeLabel(MensajeType.System, mensaje.diccionario, BLACK,  defaultIconChar);
        }

        public static MensajeLabel ABRIR = MensajeTextService.LABEL(TextMensaje.ABRIR);
        public static MensajeLabel CHECK_CONEXION = MensajeTextService.SYSTEM(TextMensaje.CHECK_CONEXION);
    }
}
