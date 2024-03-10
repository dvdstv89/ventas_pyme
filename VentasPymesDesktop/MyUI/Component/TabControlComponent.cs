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
    internal class TabControlComponent
    {       
        public Color textColor { get; set; }      
        public Font font { get; set; } 
        TabControl tabControl;

        public TabControlComponent(TabControl tabControl)
        {
            this.tabControl = tabControl;
        }

        public void applyStyle()
        {
            tabControl.ForeColor = textColor;
            tabControl.Font = font;          
            tabControl.Appearance = TabAppearance.FlatButtons;            
        }
    }
}
