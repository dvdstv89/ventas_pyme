using System.Windows.Forms;

namespace MyUI.UIControler
{
    public interface IForm
    {
        void cerrarFormulario();
        void configurarFormularioComoPanel();
        Form getForm();
    }
}
