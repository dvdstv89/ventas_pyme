using System.Drawing;
using System.Windows.Forms;
using MyUI.Component;
using MyUI.Model;

namespace MyUI.Factories
{
    public static class LabelStyleFactory
    {
        public static void Label_FORM(Label label, MensajeText mensaje)
        {
            mensaje.showTwoPoints= true;           
            BasicLabel(label, mensaje, ModuleConfig.skin.labelNormalTextColor, ModuleConfig.skin.labelNormalBackColor, ModuleConfig.skin.labelNormalFont);                    
        }
        public static void Label_FORM_CHARACTER(Label label, MensajeText mensaje)
        {
            mensaje.showTwoPoints = false;
            BasicLabel(label, mensaje, ModuleConfig.skin.labelNormalTextColor, ModuleConfig.skin.labelNormalBackColor, ModuleConfig.skin.labelNormalFont);
        }
        public static void Label_MENSAJE(Label label, MensajeText mensaje)
        {
            BasicLabel(label, mensaje, ModuleConfig.skin.labelNormalTextColor, ModuleConfig.skin.labelNormalBackColor, ModuleConfig.skin.labelNormalFont);
        }

        public static void Label_TITLE_MENSAJE(Label label, MensajeText mensaje)
        {  
            BasicLabel(label, mensaje, ModuleConfig.skin.labelNormalTextColor, ModuleConfig.skin.labelNormalBackColor, ModuleConfig.skin.labelTitleFont);
        }

        public static void Label_FOOTER(Label label, MensajeText mensaje)
        {                      
            BasicLabel(label, mensaje, ModuleConfig.skin.labelFooterTextColor, ModuleConfig.skin.labelFooterBackColor, ModuleConfig.skin.labelNormalFont);
        }       

        private static void BasicLabel(Label label, MensajeText mensaje, Color textColor, Color backColor, Font font)
        {
            LabelComponent labelComponent = new LabelComponent(label);
            labelComponent.textColor = textColor;
            labelComponent.backColor = backColor;
            labelComponent.font = font;
            labelComponent.text = mensaje.ToString();
            labelComponent.applyStyle();            
        }
    }
}
