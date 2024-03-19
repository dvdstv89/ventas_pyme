using FontAwesome.Sharp;
using MyUI.Enum;
using System.Collections.Generic;

namespace MyUI.Model
{
    public class MensajeText
    {
        public MensajeType tipoMensaje { get; }       
        public List<I18N> diccionario { get; }
        public bool showTwoPoints { get; set; }

        public MensajeText(string spanish, string english) 
        {
            this.tipoMensaje = MensajeType.Text;
            diccionario = new List<I18N>();
            setDiccionario(spanish, english);
            this.showTwoPoints = false;
        }

        protected MensajeText(MensajeType tipoMensaje, List<I18N> diccionario)
        {
            this.tipoMensaje = tipoMensaje;
            this.diccionario = diccionario;
            this.showTwoPoints = false;
        }

        protected MensajeText(MensajeType tipoMensaje, string exception)
        {
            this.tipoMensaje = tipoMensaje;
            diccionario = new List<I18N>();
            setDiccionario(exception, exception);
            this.showTwoPoints = false;
        }

        public override string ToString()
        {   
            string result = getText(diccionario);
            return (showTwoPoints && result != "") ? result + ":" : result;
        }

        protected void setDiccionario(string spanish, string english)
        {            
            diccionario.Add(new I18N(Idioma.SPANISH, spanish));
            diccionario.Add(new I18N(Idioma.ENGLISH, english));
        }

        protected string getText(List<I18N> dictionary)
        {
            I18N i18N = dictionary.Find(f => f.idioma == ModuleConfig.idioma);
            return (i18N != null) ? i18N.texto : "";
        }
    } 
}
