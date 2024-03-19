using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class ButtonIconComponent
    {       
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; }       
        public IconChar iconChar { get; set; }
        public Color iconColor { get; set; }
        public TextImageRelation textImageRelation { get; set; }
        public Padding padding { get; set; }
        public Size size { get; set; }
        public int iconSize { get; set; }
        public ContentAlignment imageAling { get; set; }
        IconButton button;

        public ButtonIconComponent(IconButton button)
        {
            this.button = button;
        }

        public void applyStyle()
        {           
            button.ForeColor = textColor;
            button.Font = font;
            button.TextImageRelation = textImageRelation;
            button.Padding = padding;
            button.Size = size;
            button.ImageAlign = imageAling;
            button.BackColor= backColor;
            button.Text = text;
            button.IconChar= iconChar;
            button.IconColor= iconColor;
            button.IconSize = iconSize;
            button.FlatStyle = FlatStyle.Flat;
        }
    }
}
