using System.Windows.Forms;
using GlobalContracts.Color;
using GlobalContracts.Model.Mensaje;

namespace MyUI.Component
{
    public static class FormularioStyleFactory
    {   
        public static void MODAL(Form formulario, string text = "")
        {
            FormularioComponent formularioComponent = new FormularioComponent(formulario);
            formularioComponent.text = text;
            formularioComponent.backColor = PalleteColor.COLOR_CARACOL_FORM;
            formularioComponent.font = FontStyle.NORMAL;
            formularioComponent.formStartPosition = FormStartPosition.CenterParent;
            formularioComponent.formBorderStyle = FormBorderStyle.FixedToolWindow;
            formularioComponent.showIcon = false;
            formularioComponent.applyStyle();
        }

        public static void WINDOWS_MODAL(Form formulario, string text = "")
        {
            FormularioComponent formularioComponent = new FormularioComponent(formulario);
            formularioComponent.text = text;
            formularioComponent.backColor = PalleteColor.COLOR_CARACOL_FORM;
            formularioComponent.font = FontStyle.NORMAL;
            formularioComponent.formStartPosition = FormStartPosition.CenterScreen;
            formularioComponent.formBorderStyle = FormBorderStyle.FixedToolWindow;
            formularioComponent.showIcon = false;
            formularioComponent.applyStyle();
        }
        public static void NOTIFICATION(Form formulario, Mensaje mensaje)
        {
            FormularioComponent formularioComponent = new FormularioComponent(formulario);            
            formularioComponent.formStartPosition = FormStartPosition.CenterScreen;
            formularioComponent.formBorderStyle = FormBorderStyle.FixedToolWindow;
            formularioComponent.backColor = mensaje.getColor();
            formularioComponent.text = mensaje.getTitle();
            formularioComponent.showIcon = false;
            formularioComponent.applyStyle();
            //formulario.UseWaitCursor = true;
        }
        public static void MODAL_INITAL(Form formulario)
        {
            FormularioComponent formularioComponent = new FormularioComponent(formulario);           
            formularioComponent.backColor = PalleteColor.COLOR_CARACOL_FORM;
            formularioComponent.font = FontStyle.NORMAL;
            formularioComponent.formStartPosition = FormStartPosition.CenterScreen;
            formularioComponent.formBorderStyle = FormBorderStyle.None;
            formularioComponent.showIcon = false;            
            formularioComponent.applyStyle();
            formulario.UseWaitCursor = true;
        }
    }
}
