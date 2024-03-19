using MyUI.Enum;

namespace MyUI.Model
{
    public class I18N
    {
        public Idioma idioma { get; set; }
        public string texto { get; set; }

        public I18N(Idioma idioma)
        {
            this.idioma = idioma;
            this.texto = "";
        }

        public I18N(Idioma idioma, string texto)
        {
            this.idioma = idioma;
            this.texto = texto;
        }
    }
}
