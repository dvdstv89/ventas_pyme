using FontAwesome.Sharp;
using MyUI.Enum;
using MyUI.Enum.Message;
using MyUI.Service;

namespace MyUI.Model
{
    internal class MensajeSuccess : Notificacion
    {  
        public MensajeSuccess(MensajeText mensajeText) 
            : base(MensajeType.Success, mensajeText.diccionario, ModuleConfig.skin.colorMensajeSuccess, MensajeTextService.TITLE(TextMensaje.SUCCESS), IconChar.Star)
        {
           
        }
    } 
}
