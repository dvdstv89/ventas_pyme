using FontAwesome.Sharp;
using MyUI.Component;
using MyUI.Enum.Message;
using MyUI.Model;
using MyUI.Service;

namespace MyUI.Factories
{
    public static class ButtonIconStyleFactory
    {
        public static void ACEPTAR(IconButton button)
        {
            BasicButton(button, MensajeTextService.LABEL(TextMensaje.ACEPTAR), IconChar.Check);                   
        }       
        public static void GUARDAR(IconButton button)
        {
            BasicButton(button, MensajeTextService.LABEL(TextMensaje.GUARDAR), IconChar.Save);           
        }
        public static void CANCELAR(IconButton button)
        {
           BasicButton(button, MensajeTextService.LABEL(TextMensaje.CANCELAR), IconChar.Cancel);           
        }
        public static void ELIMINAR(IconButton button)
        {
           BasicButton(button, MensajeTextService.LABEL(TextMensaje.ELIMINAR), IconChar.Remove);           
        }
        public static void ABRIR(IconButton button)
        {
            BasicButton(button, MensajeTextService.LABEL(TextMensaje.ABRIR), IconChar.LockOpen);           
        }
        public static void CERRAR(IconButton button)
        {
           BasicButton(button, MensajeTextService.LABEL(TextMensaje.CERRAR), IconChar.Lock);           
        }
        public static void PROBAR(IconButton button)
        {
            BasicButton(button, MensajeTextService.LABEL(TextMensaje.PROBAR), IconChar.SquareCheck);
        }

        private static void BasicButton(IconButton button, MensajeLabel message, IconChar iconChar)
        {
            ButtonIconComponent buttonComponent = new ButtonIconComponent(button);
            buttonComponent.textColor = ModuleConfig.skin.buttonTextColor;
            buttonComponent.backColor = ModuleConfig.skin.buttonBackColor;
            buttonComponent.font = ModuleConfig.skin.buttonFont;
            buttonComponent.iconColor = ModuleConfig.skin.buttonIconColor;
            buttonComponent.textImageRelation = ModuleConfig.skin.buttonTextImageRelation;
            buttonComponent.padding = ModuleConfig.skin.buttonPadding;
            buttonComponent.size = ModuleConfig.skin.buttonSize;
            buttonComponent.iconSize = ModuleConfig.skin.buttonIconSize;
            buttonComponent.imageAling = ModuleConfig.skin.buttonImageAling;
            buttonComponent.text = message.ToString();
            buttonComponent.iconChar = iconChar;           
            buttonComponent.applyStyle();       
            button.FlatStyle=System.Windows.Forms.FlatStyle.Flat;
        }
    }
}
