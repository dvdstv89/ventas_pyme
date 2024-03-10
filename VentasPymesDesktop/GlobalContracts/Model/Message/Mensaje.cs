using FontAwesome.Sharp;
using GlobalContracts.Color;
using GlobalContracts.Enum;
using GlobalContracts.Message;
using System.Collections.Generic;

namespace GlobalContracts.Model.Mensaje
{
    public class Mensaje
    {
        private MensajeType tipoMensaje;
        private IconChar iconChar;
        private List<I18N> diccionario;
        private System.Drawing.Color color;
        private string title;

        public Mensaje(MensajeType tipoMensaje, string spanish, string english) 
        {
            this.tipoMensaje = tipoMensaje;
            diccionario = new List<I18N>();
            diccionario.Add(new I18N(Idioma.SPANISH, spanish));
            diccionario.Add(new I18N(Idioma.ENGLISH, english));
            initData();
        }
        public Mensaje(MensajeType tipoMensaje)
        {
            this.tipoMensaje = tipoMensaje;
            diccionario = new List<I18N>();
            diccionario.Add(new I18N(Idioma.SPANISH));
            diccionario.Add(new I18N(Idioma.ENGLISH));
            initData();
        }        
        public string getMensaje()
        {
            I18N i18N = diccionario.Find(f=>f.idioma==VariablesEntorno.idioma);
            if (i18N != null)
                return i18N.texto;
            return "";
        }   
        public string getTitle()
        {           
            return this.title;
        }
        public IconChar getIcon()
        {
            return this.iconChar;
        }
        public System.Drawing.Color getColor()
        {
            return this.color;
        }
        public MensajeType getTipoMensaje()
        {
            return tipoMensaje;
        }

        private void initData()
        {          
            if (tipoMensaje == MensajeType.Error)
            {
                this.title = TitleText.ERROR;
                this.iconChar = IconChar.Radiation;
                this.color = PalleteColor.COLOR_WARNING;
                return;
            }
            if (tipoMensaje == MensajeType.Success)
            {
                this.title = TitleText.SUCCESS;
                this.iconChar = IconChar.Star;
                this.color = PalleteColor.COLOR_SUCCESS;
                return;
            }
            if (tipoMensaje == MensajeType.Exception)
            {
                this.title = TitleText.EXCEPTION;
                this.iconChar = IconChar.Fire;
                this.color = PalleteColor.COLOR_DANGER;
                return;
            }
            this.title = "";
            this.iconChar = IconChar.None;
        }
    } 
}
