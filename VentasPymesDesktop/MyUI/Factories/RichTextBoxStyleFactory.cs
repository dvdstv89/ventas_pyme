using System;
using MyUI.Enum;
using MyUI.Model;


namespace MyUI.Factories
{
    public static class RichTextBoxStyleFactory
    {
        public static void TEXT_MENSAJE_NOTIFICACION_EXCLUSIVO(System.Windows.Forms.RichTextBox richTextBox, Notificacion mensaje)
        {
            richTextBox.ForeColor = System.Drawing.Color.Black;
            richTextBox.Font = ModuleConfig.skin.richtTextBoxFont;
            richTextBox.Padding = ModuleConfig.skin.richtTextBoxPadding;
            richTextBox.BackColor = mensaje.color;
            richTextBox.Text = mensaje.getLabelText();
            richTextBox.Enabled = true;          
            richTextBox.BorderStyle = ModuleConfig.skin.richtTextBoxBorder;
            richTextBox.Multiline = true;
            richTextBox.ReadOnly = true;
            richTextBox.Visible = true;

            int lineasVisibles = richTextBox.Height / richTextBox.Font.Height;
            int lineasEnTexto = richTextBox.GetLineFromCharIndex(richTextBox.TextLength) + 1;
            if (lineasEnTexto >= lineasVisibles - 1) return;


            int lineasAAgregar = Math.Max(0, lineasVisibles - lineasEnTexto);
            lineasAAgregar = (lineasAAgregar + 1) / 2;

            for (int i = 0; i < lineasAAgregar; i++)
            {
                richTextBox.Text = richTextBox.Text.Insert(0, Environment.NewLine);
            }
        }        
    }
}
