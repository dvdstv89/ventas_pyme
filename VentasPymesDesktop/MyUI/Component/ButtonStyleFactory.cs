using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GlobalContracts.Message;
using GlobalContracts.Color;

namespace MyUI.Component
{
    public static class ButtonStyleFactory
    {
        private static ButtonComponent BasicButton(IconButton button)
        {
            ButtonComponent buttonComponent = new ButtonComponent(button);           
            buttonComponent.textColor = PalleteColor.COLOR_DARK;
            buttonComponent.backColor = PalleteColor.COLOR_WARNING;
            buttonComponent.font = FontStyle.BUTTON;           
            buttonComponent.iconColor = PalleteColor.COLOR_DARK;
            buttonComponent.textImageRelation = TextImageRelation.ImageBeforeText;
            buttonComponent.padding = new Padding(0, 0, 0, 0);
            buttonComponent.size = new Size(100, 30);
            buttonComponent.iconSize = 24;
            buttonComponent.imageAling = ContentAlignment.MiddleLeft;
            return buttonComponent;
        }

        public static void ACEPTAR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.ACEPTAR.getMensaje();          
            buttonComponent.iconChar = IconChar.Check;          
            buttonComponent.applyStyle();         
        }
        public static void GUARDAR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.GUARDAR.getMensaje();
            buttonComponent.iconChar = IconChar.Save;
            buttonComponent.applyStyle();
        }
        public static void CANCELAR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.CANCELAR.getMensaje();
            buttonComponent.iconChar = IconChar.Cancel;
            buttonComponent.applyStyle();
        }
        public static void ELIMINAR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.ELIMINAR.getMensaje();
            buttonComponent.iconChar = IconChar.Remove;
            buttonComponent.applyStyle();
        }
        public static void ABRIR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.ABRIR.getMensaje();
            buttonComponent.iconChar = IconChar.LockOpen;
            buttonComponent.applyStyle();
        }
        public static void CERRAR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.CERRAR.getMensaje();
            buttonComponent.iconChar = IconChar.Lock;
            buttonComponent.applyStyle();
        }
        public static void PROBAR(IconButton button)
        {
            ButtonComponent buttonComponent = BasicButton(button);
            buttonComponent.text = LabelText.PROBAR.getMensaje();
            buttonComponent.iconChar = IconChar.SquareCheck;
            buttonComponent.applyStyle();
        }
    }
}
