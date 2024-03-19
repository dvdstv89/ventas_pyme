using MyUI.Component;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class CheckBoxStyleFactory
    {
        public static void NORMAL_DISABLE(CheckBox checkBox, string text)
        {
            BasicCheckBox(checkBox, text, false);
        }
        public static void NO_TEXT_DISABLE(CheckBox checkBox)
        {
            BasicCheckBox(checkBox, "", false);           
        }
        public static void NORMAL(CheckBox checkBox, string text)
        {
            BasicCheckBox(checkBox, text, true); 
        }

        private static void BasicCheckBox(CheckBox checkBox, string text, bool enable)
        {
            CheckBoxComponent checkBoxComponent = new CheckBoxComponent(checkBox);
            checkBoxComponent.textColor = ModuleConfig.skin.checkBoxTextColor;          
            checkBoxComponent.font = ModuleConfig.skin.checkBoxFont;
            checkBoxComponent.padding = ModuleConfig.skin.checkBoxPadding;
            checkBoxComponent.text = text;
            checkBoxComponent.enable = enable;
            checkBoxComponent.applyStyle();            
        }
    }
}
