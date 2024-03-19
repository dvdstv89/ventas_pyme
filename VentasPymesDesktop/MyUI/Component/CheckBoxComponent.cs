using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class CheckBoxComponent
    {       
        public string text { get; set; }
        public Color textColor { get; set; }      
        public Font font { get; set; }    
        public Padding padding { get; set; }      
        public bool enable { get; set; }       
        CheckBox checkBox;

        public CheckBoxComponent(CheckBox checkBox)
        {
            this.checkBox = checkBox;    
            this.text=text;
        }
        public void applyStyle()
        {
            checkBox.ForeColor = textColor;
            checkBox.Font = font;
            checkBox.Padding = padding;                
            checkBox.Text = text;          
            checkBox.Enabled = enable;           
            checkBox.FlatStyle = FlatStyle.Standard;           
        }
    }
}
