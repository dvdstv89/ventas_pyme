using System.Windows.Forms;
using GlobalContracts.Color;
using GlobalContracts.Model.Mensaje;

namespace MyUI.Component
{
    public static class TextBoxStyleFactory
    {
        private static TextBoxComponent BasicTextBox(TextBox textBox)
        {
            TextBoxComponent textBoxComponent = new TextBoxComponent(textBox);           
            textBoxComponent.textColor = PalleteColor.COLOR_DARK;
            textBoxComponent.backColor = PalleteColor.COLOR_LINK;
            textBoxComponent.font = FontStyle.LIST_ITEM; 
            textBoxComponent.padding = new Padding(5, 0, 0, 0);
            textBoxComponent.size = new System.Drawing.Size(260, 45);          
            return textBoxComponent;
        }

        public static void TEXT_READONLY(TextBox textBox)
        {
            TextBoxComponent textBoxComponent = BasicTextBox(textBox);
            textBoxComponent.enable = false;
            textBoxComponent.applyStyle();         
        }
        public static void TEXT(TextBox textBox)
        {
            TextBoxComponent textBoxComponent = BasicTextBox(textBox);
            textBoxComponent.enable = true;
            textBoxComponent.applyStyle();
        }
        public static void PASSWORD(TextBox textBox)
        {
            TextBoxComponent textBoxComponent = BasicTextBox(textBox);
            textBoxComponent.enable = true;
            textBoxComponent.password = true;
            textBoxComponent.applyStyle();
        }
        public static void TEXT_MENSAJE(TextBox textBox, Mensaje mensaje)
        {
            textBox.ForeColor = PalleteColor.BLACK;
            textBox.Font = FontStyle.MENSAJE;
            textBox.Padding = new Padding(5, 5, 5, 0);           
            textBox.BackColor = mensaje.getColor();
            textBox.Text = mensaje.getMensaje();
            textBox.Enabled = true;          
            textBox.BorderStyle = BorderStyle.None;
            textBox.Multiline = true;
            textBox.ReadOnly = true;
            textBox.Visible = true;
            textBox.ScrollBars = (textBox.GetLineFromCharIndex(textBox.Text.Length) > textBox.Height / textBox.Font.Height)
                ? ScrollBars.Vertical
                : ScrollBars.None;
        }
    }
}
