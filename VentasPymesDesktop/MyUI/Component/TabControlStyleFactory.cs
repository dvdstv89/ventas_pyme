using System.Windows.Forms;
using GlobalContracts.Color;

namespace MyUI.Component
{
    public static class TabControlStyleFactory
    {
        private static TabControlComponent BasicTabPage(TabControl tabControl)
        {
            TabControlComponent tabControlComponent = new TabControlComponent(tabControl);
            tabControlComponent.textColor = PalleteColor.COLOR_DARK;          
            tabControlComponent.font = FontStyle.LIST_TITLE;  
            return tabControlComponent;
        }  

        public static void TAB_CONTROL(TabControl tabControl)
        {
            TabControlComponent tabControlComponent = BasicTabPage(tabControl);
            tabControlComponent.applyStyle();
        }
    }
}
