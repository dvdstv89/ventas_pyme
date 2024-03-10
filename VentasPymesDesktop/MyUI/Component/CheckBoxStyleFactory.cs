using System.Windows.Forms;
using GlobalContracts.Color;

namespace MyUI.Component
{
    public static class CheckBoxStyleFactory
    {
        private static CheckBoxComponent BasicCheckBox(CheckBox checkBox, string text)
        {
            CheckBoxComponent checkBoxComponent = new CheckBoxComponent(checkBox);           
            checkBoxComponent.textColor = PalleteColor.BLACK;
          //  checkBoxComponent.backColor = PalleteColor.COLOR_LINK;
            checkBoxComponent.font = FontStyle.LABEL; 
            checkBoxComponent.padding = new Padding(5, 0, 0, 0);
           // checkBoxComponent.size = new Size(260, 45);   
            checkBoxComponent.text = text;
            return checkBoxComponent;
        }

        public static void NORMAL_DISABLE(CheckBox checkBox, string text)
        {
            CheckBoxComponent checkBoxComponent = BasicCheckBox(checkBox, text);
            checkBoxComponent.enable = false;
            checkBoxComponent.applyStyle();         
        }
        public static void NO_TEXT_DISABLE(CheckBox checkBox)
        {
            CheckBoxComponent checkBoxComponent = BasicCheckBox(checkBox, "");
            checkBoxComponent.enable = false;
            checkBoxComponent.applyStyle();
        }
        public static void NORMAL(CheckBox checkBox, string text)
        {
            CheckBoxComponent checkBoxComponent = BasicCheckBox(checkBox, text);
            checkBoxComponent.enable = true;
            checkBoxComponent.applyStyle();
        }
    }
}
