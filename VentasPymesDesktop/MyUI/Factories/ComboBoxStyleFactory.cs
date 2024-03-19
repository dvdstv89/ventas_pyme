using System.Windows.Forms;
using System.Collections.Generic;
using MyUI.Component;

namespace MyUI.Factories
{
    public static class ComboBoxStyleFactory
    {
        public static void LIST_READONLY(ComboBox comboBox, List<string> datos)
        {
            BasicComboBox(comboBox, datos, false);
        }
        public static void LIST(ComboBox comboBox, List<string> datos)
        {
            BasicComboBox(comboBox, datos, true);
        }

        private static void BasicComboBox(ComboBox comboBox, List<string> datos, bool enable)
        {
            ComboBoxComponent comboBoxComponent = new ComboBoxComponent(comboBox, datos);
            comboBoxComponent.textColor = ModuleConfig.skin.comboBoxTextColor;
            comboBoxComponent.backColor = ModuleConfig.skin.comboBoxBackColor;
            comboBoxComponent.font = ModuleConfig.skin.comboBoxFont;
            comboBoxComponent.padding = ModuleConfig.skin.comboBoxPadding;
            comboBoxComponent.size = ModuleConfig.skin.comboBoxBoxSize;
            comboBoxComponent.dropDownStyle = ModuleConfig.skin.comboBoxDropDownSyle;
            comboBoxComponent.enable = enable;
            comboBoxComponent.applyStyle();           
        }
    }
}
