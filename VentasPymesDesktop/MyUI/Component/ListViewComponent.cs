
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class ListViewComponent
    {
        ListView listView;
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; }
        public bool fullRowSelect { get; set; }
        public bool gridLines { get; set; }        

        public ListViewComponent(ListView listView)
        {
            this.listView = listView;
        }

        public void applyStyle()
        {
            listView.ForeColor = textColor;
            listView.BackColor = backColor;           
            listView.Font = font;
            listView.FullRowSelect = fullRowSelect;
            listView.GridLines = gridLines;
        }
    }
}
