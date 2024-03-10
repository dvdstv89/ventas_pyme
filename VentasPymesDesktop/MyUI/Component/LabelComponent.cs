using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class LabelComponent
    {
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; } 
        Label label;

        public LabelComponent(Label label)
        {
            this.label = label;
        }

        public void applyStyle()
        {
            label.ForeColor = textColor;
            label.Font = font;  
            label.BackColor = backColor;
            label.Text = text;
           
        }
    }
}
