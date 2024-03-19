using FontAwesome.Sharp;
using MyUI.Enum;
using MyUI.Enum.Message;
using MyUI.Service;

namespace MyUI.Model
{
    internal class MensajeException : Notificacion
    {
        public MensajeException(string exception)
           : base(MensajeType.Exception, exception, ModuleConfig.skin.colorMensajeException, MensajeTextService.TITLE(TextMensaje.EXCEPTION), IconChar.Fire)
        {

        }
    } 
}
