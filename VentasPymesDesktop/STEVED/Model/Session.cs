using MyUI.Enum;
using MyUI.Factories;
using MyUI.Model;
using System.Globalization;

namespace NucleoEV.Model
{
    public class Session
    {  
        public bool tokenEsAutentico { get; set; }
        public CultureInfo cultureInfo { get; set; }
        public Skin skin { get; set; }
        public Idioma idioma { get; set; }

        public Session(CultureInfo cultureInfo)
        {               
            this.cultureInfo = cultureInfo;
            this.tokenEsAutentico = true;          
            this.skin = SkinFactory.CARACOL_SKIN();
            idioma = Idioma.SPANISH;

        } 
       
    }
}
