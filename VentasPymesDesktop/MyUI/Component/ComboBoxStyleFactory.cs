using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GlobalContracts.Color;

namespace MyUI.Component
{
    public static class ComboBoxStyleFactory
    {
        private static ComboBoxComponent BasicComboBox(ComboBox comboBox, List<string> datos)
        {
            ComboBoxComponent comboBoxComponent = new ComboBoxComponent(comboBox, datos);           
            comboBoxComponent.textColor = PalleteColor.COLOR_DARK;
            comboBoxComponent.backColor = PalleteColor.COLOR_LINK;
            comboBoxComponent.font = FontStyle.LIST_ITEM; 
            comboBoxComponent.padding = new Padding(5, 0, 0, 0);
            comboBoxComponent.size = new Size(260, 45); 
            comboBoxComponent.dropDownStyle= ComboBoxStyle.DropDownList;
            return comboBoxComponent;
        }

        public static void LIST_READONLY(ComboBox comboBox, List<string> datos)
        {
            ComboBoxComponent comboBoxComponent = BasicComboBox(comboBox, datos);
            comboBoxComponent.enable = false;           
            comboBoxComponent.applyStyle();         
        }
        public static void LIST(ComboBox comboBox, List<string> datos)
        {
            ComboBoxComponent comboBoxComponent = BasicComboBox(comboBox, datos);
            comboBoxComponent.enable = true;
            comboBoxComponent.applyStyle();
        }
    }
}
