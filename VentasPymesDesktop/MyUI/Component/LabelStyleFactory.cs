using System.Windows.Forms;
using GlobalContracts.Color;

namespace MyUI.Component
{
    public static class LabelStyleFactory
    {
        private static LabelComponent BasicLabel(Label label)
        {
            LabelComponent labelComponent = new LabelComponent(label);           
            labelComponent.textColor = PalleteColor.COLOR_DARK;
            labelComponent.backColor = PalleteColor.COLOR_TRANSPARENT;
            labelComponent.font = FontStyle.LABEL;  
            return labelComponent;
        }       

        public static void Label_FORM(Label label, string text)
        {
            LabelComponent labelComponent = BasicLabel(label);
            labelComponent.text = text+":";           
            labelComponent.applyStyle();         
        }
        public static void Label_MENSAJE(Label label, string text)
        {
            LabelComponent labelComponent = new LabelComponent(label);
            labelComponent.text = text;
            labelComponent.applyStyle();
        }

        public static void Label_TITLE_MENSAJE(Label label, string text)
        {
            LabelComponent labelComponent = new LabelComponent(label);
            labelComponent.font = FontStyle.TITLE;
            labelComponent.text = text;
            labelComponent.applyStyle();
        }
        public static void Label_FOOTER(Label label, string text)
        {
            LabelComponent labelComponent = new LabelComponent(label);
            labelComponent.textColor = PalleteColor.WHITE;
            labelComponent.backColor = PalleteColor.COLOR_CARACOL_BANNER;
            labelComponent.font = FontStyle.LABEL;
            labelComponent.text = text;
            labelComponent.applyStyle();
        }
    }
}
