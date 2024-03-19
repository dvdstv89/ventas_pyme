using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class TextBoxComponent
    {       
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }      
        public Font font { get; set; }    
        public Padding padding { get; set; }
        public Size size { get; set; }
        public bool enable { get; set; }
        public bool password { get; set; } = false;
      
        TextBox textBox;

        public TextBoxComponent(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public void applyStyle()
        {
            textBox.ForeColor = textColor;
            textBox.Font = font;         
            textBox.Padding = padding;
            textBox.Size = size;           
            textBox.BackColor= backColor;
            textBox.Text = text;           
            textBox.Enabled= enable;
            if(password) textBox.PasswordChar = '*';
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
