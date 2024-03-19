using MyUI.Component;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class TabControlStyleFactory
    {  
        public static void TAB_CONTROL(TabControl tabControl)
        {
           BasicTabPage(tabControl);            
        }
        private static void BasicTabPage(TabControl tabControl)
        {
            TabControlComponent tabControlComponent = new TabControlComponent(tabControl);
            tabControlComponent.textColor = ModuleConfig.skin.tabControlTextColor;
            tabControlComponent.font = ModuleConfig.skin.tabControlFont;
            tabControlComponent.applyStyle();            
        }
    }
}
