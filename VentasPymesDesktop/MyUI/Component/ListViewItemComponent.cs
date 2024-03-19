using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class ListViewItemComponent
    {
        ListViewItem listViewItem;
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; }
     

        public ListViewItemComponent(ListViewItem listViewItem)
        {
            this.listViewItem = listViewItem;
        }

        public void applyStyle()
        {
            listViewItem.ForeColor = textColor;
            listViewItem.BackColor = backColor;
            listViewItem.Font = font;
        }
    }
}
