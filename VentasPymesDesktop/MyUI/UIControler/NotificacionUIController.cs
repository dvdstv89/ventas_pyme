using System;
using MyUI.Component;
using MyUI.UI;
using GlobalContracts.Model.Mensaje;
using GlobalContracts.Interface;

namespace MyUI.UIControler
{
    public class NotificacionUIController : BaseUIController<NotificationUI>, IController<NotificationUI>
    {
        Mensaje message;
        public bool isValidado { get; set; }
        public NotificacionUIController(Mensaje message) : base(new NotificationUI())
        {
            this.message = message;
        }
        public NotificationUI ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btCancelar.Click += new EventHandler(btnCancelar_Click);
            return forma;
        }
        public override void aplicarTema()
        {
            FormularioStyleFactory.NOTIFICATION(this.forma, message);
            RichTextBoxStyleFactory.TEXT_MENSAJE_NOTIFICACION_EXCLUSIVO(forma.textMensaje, message);
            forma.icon.IconChar = message.getIcon();
        }
    }
}
