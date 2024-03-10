using GlobalContracts.Enum;
using GlobalContracts.Model.Mensaje;

namespace GlobalContracts.Message
{
    public static class MensajeFactory
    {
        internal static Mensaje LABEL(string spanish, string english)
        {            
            return new Mensaje(MensajeType.Label, spanish, english);
        }
        internal static Mensaje TITLE(string spanish, string english)
        {
            return new Mensaje(MensajeType.Title, spanish, english);
        }
        internal static Mensaje ERROR(string spanish, string english)
        {
            return new Mensaje(MensajeType.Error, spanish, english);
        }
        internal static Mensaje ENUM(string spanish, string english)
        {
            return new Mensaje(MensajeType.Enum, spanish, english);
        }
        internal static Mensaje SUCCESS(string spanish, string english)
        {
            return new Mensaje(MensajeType.Success, spanish, english);
        }
        internal static Mensaje SYSTEM(string spanish, string english)
        {
            return new Mensaje(MensajeType.System, spanish, english);
        }
        public static Mensaje EXCEPTION(string exception)
        {
            return new Mensaje(MensajeType.Exception, exception, exception);
        }
    }
}
