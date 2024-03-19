using MyUI.Component;
using MyUI.Model;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class FormularioStyleFactory
    {   
        public static void WINDOWS_FORM(Form formulario, MensajeText mensaje)
        {          
            BasicForm(formulario, mensaje, FormBorderStyle.FixedToolWindow, false, false, ModuleConfig.skin.formBackColor);
        }
      
        internal static void NOTIFICATION(Form formulario, Notificacion mensaje)
        {                    
            BasicForm(formulario, mensaje, FormBorderStyle.FixedToolWindow, false, false, mensaje.color);
        }

        public static void MODAL(Form formulario, MensajeText mensaje)
        {
            BasicForm(formulario, mensaje, FormBorderStyle.None, false, true, ModuleConfig.skin.formBackColor);
        }

        internal static void PROGRESS_BAR(Form formulario, MensajeText mensaje)
        {           
            BasicForm(formulario, mensaje, FormBorderStyle.None, false, true, ModuleConfig.skin.formBackColor);
        }

        private static void BasicForm(Form formulario, MensajeText mensaje, FormBorderStyle formBorderStyle, bool showIcon, bool useWaitCursor, System.Drawing.Color backColor)
        {
            FormularioComponent formularioComponent = new FormularioComponent(formulario);
            formularioComponent.showIcon = showIcon;
            formularioComponent.backColor = backColor;
            formularioComponent.text = mensaje.ToString();
            formularioComponent.formBorderStyle = formBorderStyle;           
            formularioComponent.font = ModuleConfig.skin.formFont;
            formularioComponent.formStartPosition = ModuleConfig.skin.formStartPosition;           
            formularioComponent.applyStyle();
            formulario.TopMost = true;
            formulario.UseWaitCursor = useWaitCursor;           
        }
    }
}
