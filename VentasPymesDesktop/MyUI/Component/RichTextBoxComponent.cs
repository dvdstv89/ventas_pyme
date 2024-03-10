
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class RichTextBoxComponent
    {       
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; }    
        public Padding padding { get; set; }
        public Size size { get; set; }
        public bool enable { get; set; }        

        RichTextBox richTextBox;

        public RichTextBoxComponent(RichTextBox textBox)
        {
            this.richTextBox = textBox;
        }

        public void applyStyle()
        {
            richTextBox.ForeColor = textColor;
            richTextBox.Font = font;         
            richTextBox.Padding = padding;
            richTextBox.Size = size;           
            richTextBox.BackColor= backColor;
            richTextBox.Text = text;           
            richTextBox.Enabled= enable;           
            richTextBox.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
