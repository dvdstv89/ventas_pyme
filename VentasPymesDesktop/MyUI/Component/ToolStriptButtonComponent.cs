
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class ToolStriptButtonComponent
    {       
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; }       
        public TextImageRelation textImageRelation { get; set; }
        public Padding padding { get; set; }
        public Size size { get; set; }       
        public ContentAlignment imageAling { get; set; }
        ToolStripButton toolStripButton;

        public ToolStriptButtonComponent(ToolStripButton toolStripButton)
        {
            this.toolStripButton = toolStripButton;
        }

        public void applyStyle()
        {
            toolStripButton.ForeColor = textColor;
            toolStripButton.BackColor = backColor;
            toolStripButton.Text = text;
            toolStripButton.Font = font;
        }
    }
}
