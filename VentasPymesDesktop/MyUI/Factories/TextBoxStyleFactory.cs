using System.Windows.Forms;
using MyUI.Component;
using MyUI.Model;

namespace MyUI.Factories
{
    public static class TextBoxStyleFactory
    {      

        public static void TEXT_READONLY(TextBox textBox)
        {
            BasicTextBox(textBox, false, false);                  
        }
        public static void TEXT(TextBox textBox)
        {
            BasicTextBox(textBox, true, false);          
        }
        public static void PASSWORD(TextBox textBox)
        {
            BasicTextBox(textBox, true, true);           
        }
        public static void TEXT_MENSAJE(TextBox textBox, Notificacion mensaje)
        {
            MultilineTextBox(textBox, mensaje);
        }

        private static void BasicTextBox(TextBox textBox, bool enabled, bool password)
        {
            TextBoxComponent textBoxComponent = new TextBoxComponent(textBox);
            textBoxComponent.textColor = ModuleConfig.skin.textBoxTextColor;
            textBoxComponent.backColor = ModuleConfig.skin.textBoxBackColor;
            textBoxComponent.font = ModuleConfig.skin.textBoxFont;
            textBoxComponent.padding = ModuleConfig.skin.textBoxPadding;
            textBoxComponent.size = ModuleConfig.skin.textBoxSize;
            textBoxComponent.enable = enabled;
            textBoxComponent.password = password;
            textBoxComponent.applyStyle();          
        }

        private static void MultilineTextBox(TextBox textBox, Notificacion mensaje)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.Multiline = true;
            textBox.ReadOnly = true;
            textBox.Visible = true;
            textBox.Enabled = true;
            textBox.ScrollBars = (textBox.GetLineFromCharIndex(textBox.Text.Length) > textBox.Height / textBox.Font.Height)
                ? ScrollBars.Vertical
                : ScrollBars.None;
            TextBoxComponent textBoxComponent = new TextBoxComponent(textBox);
            textBoxComponent.textColor = ModuleConfig.skin.textBoxMultilineTextColor;
            textBoxComponent.font = ModuleConfig.skin.textBoxMultilineFont;
            textBoxComponent.padding = ModuleConfig.skin.textBoxMultilinePadding;
            textBoxComponent.backColor = mensaje.color;
            textBoxComponent.text = mensaje.ToString();                 
            textBoxComponent.applyStyle();           
        }
    }
}
