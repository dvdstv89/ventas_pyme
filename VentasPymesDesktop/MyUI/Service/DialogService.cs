using MyUI.Model;
using MyUI.UI;
using MyUI.UIControler;
using System;
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
            controller.showDialog();
        }

        public static void ERROR(MensajeText mensaje)
        {
            try
            {
                var errorMessage = new MensajeError(mensaje);
                var notificacionUI = new NotificationUI();
                var controller = new NotificacionUIController(notificacionUI, errorMessage);
                controller.showDialog();
            }
            catch (Exception ex)
            {
                EXCEPTION(ex.Message);
            }
        }

        public static void SUCCESS(MensajeText mensaje)
        {
            try
            {
                var successMessage = new MensajeSuccess(mensaje);
                var notificacionUI = new NotificationUI();
                var controller = new NotificacionUIController(notificacionUI, successMessage);
                controller.showDialog();
            }
            catch (Exception ex)
            {
                EXCEPTION(ex.Message);
            }
        }

        public static bool CONFIRMATION(MensajeText mensaje)
        {
            try
            {
                var confirmationMessage = new MensajeConfirmation(mensaje);
                var notificacionUI = new NotificationUI();
                var controller = new NotificacionUIController(notificacionUI, confirmationMessage);
                DialogResult dialogResult = controller.showDialog();
                return dialogResult == DialogResult.OK ? true : false;
            }
            catch (Exception ex)
            {
                EXCEPTION(ex.Message);
                return false;
            }
        }
    }
}
