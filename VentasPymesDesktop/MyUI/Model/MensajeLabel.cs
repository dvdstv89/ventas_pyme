using FontAwesome.Sharp;
using MyUI.Enum;
using System.Collections.Generic;

namespace MyUI.Model
{
    public class MensajeLabel : MensajeText
    {      
        public IconChar iconChar { get; }       
        public System.Drawing.Color color { get; }  

        public MensajeLabel(MensajeType tipoMensaje, List<I18N> diccionario, System.Drawing.Color color, IconChar iconChar) 
            :base(tipoMensaje, diccionario)
        {           
            this.iconChar = iconChar;
            this.color = color;          
        }

        public MensajeLabel(MensajeType tipoMensaje, string exception, System.Drawing.Color color, IconChar iconChar)
           : base(tipoMensaje, exception)
        {            
            this.iconChar = iconChar;
            this.color = color;          
        }

        public override string ToString()
        {
            return getText(diccionario);
        }
    } 
}
