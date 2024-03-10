using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using GlobalContracts.Color;
using GlobalContracts.Model.Mensaje;

namespace MyUI.Component
{
    public static class RichTextBoxStyleFactory
    {
        private static RichTextBoxComponent BasicTextBox(System.Windows.Forms.RichTextBox richTextBox)
        {
            RichTextBoxComponent textBoxComponent = new RichTextBoxComponent(richTextBox);           
            textBoxComponent.textColor = PalleteColor.COLOR_DARK;
            textBoxComponent.backColor = PalleteColor.COLOR_LINK;
            textBoxComponent.font = FontStyle.LIST_ITEM; 
            textBoxComponent.padding = new Padding(5, 0, 0, 0);
            textBoxComponent.size = new System.Drawing.Size(260, 45);          
            return textBoxComponent;
        }
        
        public static void TEXT_MENSAJE_NOTIFICACION_EXCLUSIVO(System.Windows.Forms.RichTextBox richTextBox, Mensaje mensaje)
        {
            richTextBox.ForeColor = PalleteColor.BLACK;
            richTextBox.Font = FontStyle.MENSAJE;
            richTextBox.Padding = new Padding(10, 5, 5, 0);           
            richTextBox.BackColor = mensaje.getColor();
            richTextBox.Text = mensaje.getMensaje();
            richTextBox.Enabled = true;          
            richTextBox.BorderStyle = BorderStyle.None;
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
