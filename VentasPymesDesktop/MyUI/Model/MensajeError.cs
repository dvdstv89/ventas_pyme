using FontAwesome.Sharp;
using MyUI.Enum;
using MyUI.Enum.Message;
using MyUI.Service;

namespace MyUI.Model
{
    internal class MensajeError : Notificacion
    {
        public MensajeError(MensajeText mensajeText)
             : base(MensajeType.Error, mensajeText.diccionario, ModuleConfig.skin.colorMensajeError, MensajeTextService.TITLE(TextMensaje.ERROR), IconChar.Radiation)
        {
           
        }
    } 
}
