using FontAwesome.Sharp;
using MyUI.Enum;
using System.Collections.Generic;

namespace MyUI.Model
{
    public class Notificacion: MensajeText
    {      
        public IconChar iconChar { get; }       
        public System.Drawing.Color color { get; }       
        public MensajeText title { get; }

        public Notificacion(MensajeType tipoMensaje, List<I18N> diccionario, System.Drawing.Color color, MensajeText title, IconChar iconChar) 
            :base(tipoMensaje, diccionario)
        {
            this.title = title;
            this.iconChar = iconChar;
            this.color = color;          
        }

        public Notificacion(MensajeType tipoMensaje, string exception, System.Drawing.Color color, MensajeText title, IconChar iconChar)
           : base(tipoMensaje, exception)
        {
            this.title = title;
            this.iconChar = iconChar;
            this.color = color;          
        }

        public override string ToString()
        {
            return getText(title.diccionario);                    
        }

        public string getLabelText()
        {
            return getText(diccionario);
        }       
    } 
}
