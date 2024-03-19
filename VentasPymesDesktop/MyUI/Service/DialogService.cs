using MyUI.Model;
using MyUI.UI;
using MyUI.UIControler;
using System.Windows.Forms;

namespace MyUI.Service
{
    public static class DialogService
    {   
        public static void EXCEPTION(string exception)
        {
            var exceptionMessage = new MensajeException(exception);
            var notificacionUI = new NotificationUI();
            var controller = new NotificacionUIController(notificacionUI, exceptionMessage);
            controller.ejecutar().ShowDialog();
        }

        public static void ERROR(MensajeText mensaje)
        {
            var errorMessage = new MensajeError(mensaje);
            var notificacionUI = new NotificationUI();
            var controller = new NotificacionUIController(notificacionUI, errorMessage);
            controller.ejecutar().ShowDialog();
        }

        public static void SUCCESS(MensajeText mensaje)
        {
            var successMessage = new MensajeSuccess(mensaje);
            var notificacionUI = new NotificationUI();
            var controller = new NotificacionUIController(notificacionUI, successMessage);
            controller.ejecutar().ShowDialog();
        }

        public static bool CONFIRMATION(MensajeText mensaje)
        {
            var confirmationMessage = new MensajeConfirmation(mensaje);
            var notificacionUI = new NotificationUI();
            var controller = new NotificacionUIController(notificacionUI, confirmationMessage);
            DialogResult dialogResult = controller.ejecutar().ShowDialog();
            return dialogResult == DialogResult.OK ? true : false;
        }
    }
}
