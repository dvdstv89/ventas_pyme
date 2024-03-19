using MyUI.Enum;
using MyUI.Factories;
using MyUI.Model;

namespace MyUI
{
    internal static class ModuleConfig
    {
        public static Idioma idioma = Enum.Idioma.SPANISH;
        public static Skin skin = SkinFactory.CARACOL_SKIN();
    }
}
