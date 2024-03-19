using MyUI.Enum;
using MyUI.Model;

namespace MyUI.Service
{
    public class ModuleConfigService
    { 
        public void setIdioma(Idioma idioma)
        {
            ModuleConfig.idioma = idioma;
        }

        public void setSkin(Skin skin)
        {
            ModuleConfig.skin = skin;
        }
    }
}
