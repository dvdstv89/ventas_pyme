using GlobalContracts.Color;
using System.Windows.Forms;

namespace MyUI.Component
{
    public static class TabPageStyleFactory
    {
        private static TabPageComponent BasicTabPage(TabPage tabPage)
        {
            TabPageComponent tabPageComponent = new TabPageComponent(tabPage);
            tabPageComponent.textColor = PalleteColor.COLOR_DARK;
            tabPageComponent.backColor = PalleteColor.COLOR_CARACOL_FORM;
            tabPageComponent.font = FontStyle.LIST_TITLE;  
            return tabPageComponent;
        }  

        public static void TAB_PAGE(TabPage tabPage, string text)
        {
            TabPageComponent tabPageComponent = BasicTabPage(tabPage);
            tabPageComponent.text = text;
            tabPageComponent.applyStyle();
        }
    }
}
