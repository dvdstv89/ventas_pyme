using MyUI.Component;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class ListViewStyleFactory
    {
        public static void LISTVIEW(ListView listView)
        {
            BasicListView(listView, ModuleConfig.skin.listViewFont);                   
        }
        public static void SUBLISTVIEW(ListView listView)
        {
            BasicListView(listView, ModuleConfig.skin.subListViewFont);
        }

        private static void BasicListView(ListView listView, Font font)
        {
            ListViewComponent listViewComponent = new ListViewComponent(listView);
            listViewComponent.textColor = ModuleConfig.skin.listViewTextColor;
            listViewComponent.backColor = ModuleConfig.skin.listViewBackColor;
            listViewComponent.font = font;
            listViewComponent.fullRowSelect = true;
            listViewComponent.gridLines = false;
            listViewComponent.applyStyle();           
        }      
    }
}
