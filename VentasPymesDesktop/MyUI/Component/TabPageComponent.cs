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
    internal class TabPageComponent
    {
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; } 
        TabPage tabPage;

        public TabPageComponent(TabPage tabPage)
        {
            this.tabPage = tabPage;
        }

        public void applyStyle()
        {
            tabPage.ForeColor = textColor;
            tabPage.Font = font;
            tabPage.BackColor = backColor;
            tabPage.Text = text;
            tabPage.BorderStyle = BorderStyle.None;              
        }
    }
}
