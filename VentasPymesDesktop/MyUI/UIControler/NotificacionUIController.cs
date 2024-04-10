using System;
using MyUI.UI;
using MyUI.Model;
using MyUI.Factories;
using MyUI.Service;
using System.Windows.Forms;

namespace MyUI.UIControler
{
    internal class NotificacionUIController : BaseUIController<NotificationUI>
    {
        Notificacion notificacion;
        public bool isValidado { get; set; }
        public NotificacionUIController(NotificationUI notificationUI, Notificacion notificacion) : base(notificationUI)
        {
            this.notificacion = notificacion;
        }
        protected override NotificationUI ejecutar()
        {           
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            forma.btnCancelarOculto.Click += new EventHandler(btnCancelar_Click);
            forma.btnAceptar.Click += new EventHandler(btnAceptar_Click);

            if (Form.ActiveForm != null)
            {
                forma.Owner = Form.ActiveForm;
                forma.Owner.Enabled = false;
            }          
            return base.ejecutar();
        }
        protected override void aplicarTema()
        {
            if(notificacion.tipoMensaje != Enum.MensajeType.Confirmation)
            {                
                forma.btnCancelar.Visible = false;
            }

            ButtonIconStyleFactory.ACEPTAR(forma.btnAceptar);
            ButtonIconStyleFactory.CANCELAR(forma.btnCancelar);

            FormularioStyleFactory.NOTIFICATION(this.forma, notificacion);
            RichTextBoxStyleFactory.TEXT_MENSAJE_NOTIFICACION_EXCLUSIVO(forma.textMensaje, notificacion);
            forma.icon.IconChar = notificacion.iconChar;
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.DialogResult = DialogResult.OK;
                if (forma.Owner != null)
                {
                    forma.Owner.Enabled = true;
                }
                return;
            }
            catch (Exception ex)
            {
                DialogService.EXCEPTION(ex.Message);
            }
        }
    }
}
