using MyUI.Component;
using MyUI.Model;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class TabPageStyleFactory
    {   
        public static void TAB_PAGE(TabPage tabPage, Notificacion mensaje)
        {
            BasicTabPage(tabPage, mensaje);            
        }

        private static void BasicTabPage(TabPage tabPage, Notificacion mensaje)
        {
            TabPageComponent tabPageComponent = new TabPageComponent(tabPage);
            tabPageComponent.textColor = ModuleConfig.skin.tabPageTextColor;
            tabPageComponent.backColor = ModuleConfig.skin.tabPageBackColor;
            tabPageComponent.font = ModuleConfig.skin.tabPageFont;
            tabPageComponent.text = mensaje.ToString();
            tabPageComponent.applyStyle();            
        }
    }
}
