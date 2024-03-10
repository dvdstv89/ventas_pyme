using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class FormularioComponent
    {
        public string text { get; set; } = "";
        public Color backColor { get; set; }
        public Font font { get; set; }
        public FormStartPosition formStartPosition { get; set; }
        public FormBorderStyle formBorderStyle { get; set; }
        public bool showIcon { get; set; }       
        Form form;

        public FormularioComponent(Form form)
        {
            this.form = form;
        }

        public void applyStyle()
        {           
            form.Font = font;
            form.BackColor = backColor;
            form.Text = text;           
            form.StartPosition = formStartPosition;
            form.FormBorderStyle = formBorderStyle;
            form.ShowIcon = showIcon;  
        }
    }
}
