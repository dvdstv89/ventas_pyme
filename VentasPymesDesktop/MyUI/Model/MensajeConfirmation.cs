using FontAwesome.Sharp;
using MyUI.Enum;
using MyUI.Enum.Message;
using MyUI.Service;

namespace MyUI.Model
{
    internal class MensajeConfirmation : Notificacion
    {       
        public MensajeConfirmation(MensajeText mensajeText)
             : base(MensajeType.Confirmation, mensajeText.diccionario, ModuleConfig.skin.colorMensajeConfirmation, MensajeTextService.TITLE(TextMensaje.CONFIRMATION), IconChar.Question)
        {
           
        }
    } 
}
