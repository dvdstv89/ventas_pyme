using MyUI.Component;
using MyUI.Enum.Message;
using MyUI.Model;
using MyUI.Service;
using System.Windows.Forms;

namespace MyUI.Factories
{
    public static class ToolStriptButtonStyleFactory
    {
        public static void ACEPTAR(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.ACEPTAR), true);                   
        }
        public static void CANCELAR(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.CANCELAR), true);
        }
        public static void ELIMINAR(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.ELIMINAR), true);
        }
        public static void ACTIVAR(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.ACTIVAR), true);           
        }
        public static void DESACTIVAR(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.DESACTIVAR), true);           
        }
        public static void MODIFICAR(ToolStripButton toolStripButton)
        {
           BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.MODIFICAR), true);           
        }
        public static void ADICIONAR(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.ADICIONAR), true);
        }
        public static void VER_DETALLES(ToolStripButton toolStripButton)
        {
            BasicToolStriptButton(toolStripButton, MensajeTextService.LABEL(TextMensaje.DETALLES), true);
        }

        private static void BasicToolStriptButton(ToolStripButton toolStripButton, MensajeLabel message, bool ubicacionToolMenu)
        {
            ToolStriptButtonComponent toolStripButtonComponent = new ToolStriptButtonComponent(toolStripButton);
            toolStripButtonComponent.textColor = ModuleConfig.skin.toolStripButtonTextColor;
            toolStripButtonComponent.backColor = ubicacionToolMenu ? ModuleConfig.skin.toolStripButtonBackColor :ModuleConfig.skin.toolStripButtonBackColor_PanelLateral;
            toolStripButtonComponent.font = ModuleConfig.skin.toolStripButtonFont;
            toolStripButtonComponent.text = message.ToString();
            toolStripButtonComponent.applyStyle();           
        }
    }
}
