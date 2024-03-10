using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class ComboBoxComponent
    {       
        public string text { get; set; }
        public Color textColor { get; set; }
        public Color backColor { get; set; }
        public Font font { get; set; }    
        public Padding padding { get; set; }
        public Size size { get; set; }
        public bool enable { get; set; }    
        
        public List<string> datos { get; set; }
        public ComboBoxStyle dropDownStyle { get; set; }
        ComboBox comboBox;

        public ComboBoxComponent(ComboBox comboBox, List<string> datos)
        {
            this.comboBox = comboBox;
            this.datos = datos;
        }

        public void applyStyle()
        {
            comboBox.ForeColor = textColor;
            comboBox.Font = font;
            comboBox.Padding = padding;
            comboBox.Size = size;
            comboBox.BackColor = backColor;
            comboBox.Text = text;
            comboBox.DropDownStyle = dropDownStyle;
            comboBox.Enabled = enable;
            comboBox.Items.AddRange(datos.ToArray());
            comboBox.FlatStyle = FlatStyle.Standard;           
        }
    }
}
