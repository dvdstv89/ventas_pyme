using MyUI.Component;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class ListViewItemStyleFactory
    {
        public static void TOTAL(ListViewItem listViewItem)
        {
            BasicListViewItem(listViewItem, ModuleConfig.skin.listViewItemTotalFont, ModuleConfig.skin.listViewItemTotalBackColor);
        }
        public static void SUB_ITEM(ListViewItem listViewItem, int pos)
        {
            Color backColor = (pos % 2 == 0) ? ModuleConfig.skin.listViewItemSubParBackColor : ModuleConfig.skin.listViewItemSubImparBackColor;
            BasicListViewItem(listViewItem, ModuleConfig.skin.listViewItemSublFont, backColor);
        }
        public static void CONDICIONAL(ListViewItem listViewItem, int pos, bool isConditional)
        {
            Color backColor = (pos % 2 == 0) ? ModuleConfig.skin.listViewItemSubParBackColor : ModuleConfig.skin.listViewItemSubImparBackColor;
            backColor = isConditional ? ModuleConfig.skin.listViewItemConditionalBackColor : backColor;
            BasicListViewItem(listViewItem, ModuleConfig.skin.listViewItemTotalFont, backColor);
        }

        private static void BasicListViewItem(ListViewItem listViewItem, Font font, Color backColor)
        {
            ListViewItemComponent listViewItemComponent = new ListViewItemComponent(listViewItem);
            listViewItemComponent.textColor = ModuleConfig.skin.listViewItemTextColor;
            listViewItemComponent.backColor = backColor;
            listViewItemComponent.font = font;
            listViewItemComponent.applyStyle();           
        }      
    }
}
