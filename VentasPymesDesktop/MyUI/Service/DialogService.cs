using GlobalContracts;
using GlobalContracts.Enum;
using GlobalContracts.Model.Mensaje;
using MyUI.UIControler;

namespace MyUI.Service
{
    public static class DialogService
    {
        public static void ShowDialog(Mensaje message)
        {
            new NotificacionUIController(message).ejecutar().ShowDialog();     
        }       
    }
}
