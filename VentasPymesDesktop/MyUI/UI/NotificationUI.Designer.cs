namespace MyUI.UI
{
    partial class NotificationUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.icon = new FontAwesome.Sharp.IconPictureBox();
            this.textMensaje = new System.Windows.Forms.RichTextBox();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnAceptar = new FontAwesome.Sharp.IconButton();
            this.btnCancelarOculto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.SystemColors.Control;
            this.icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.icon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.icon.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
            this.icon.IconColor = System.Drawing.SystemColors.ControlText;
            this.icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icon.IconSize = 57;
            this.icon.Location = new System.Drawing.Point(0, 0);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(57, 101);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icon.TabIndex = 4;
            this.icon.TabStop = false;
            // 
            // textMensaje
            // 
            this.textMensaje.Dock = System.Windows.Forms.DockStyle.Right;
            this.textMensaje.Location = new System.Drawing.Point(55, 0);
            this.textMensaje.Name = "textMensaje";
            this.textMensaje.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textMensaje.Size = new System.Drawing.Size(436, 101);
            this.textMensaje.TabIndex = 5;
            this.textMensaje.Text = "";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.Location = new System.Drawing.Point(281, 66);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAceptar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAceptar.IconColor = System.Drawing.Color.Black;
            this.btnAceptar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAceptar.Location = new System.Drawing.Point(387, 66);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelarOculto
            // 
            this.btnCancelarOculto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarOculto.Location = new System.Drawing.Point(8, 0);
            this.btnCancelarOculto.Name = "btnCancelarOculto";
            this.btnCancelarOculto.Size = new System.Drawing.Size(49, 23);
            this.btnCancelarOculto.TabIndex = 8;
            this.btnCancelarOculto.Text = "button1";
            this.btnCancelarOculto.UseVisualStyleBackColor = true;
            // 
            // NotificationUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelarOculto;
            this.ClientSize = new System.Drawing.Size(491, 101);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.textMensaje);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.btnCancelarOculto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NotificationUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NotificationUI";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public FontAwesome.Sharp.IconPictureBox icon;
        public System.Windows.Forms.RichTextBox textMensaje;
        public FontAwesome.Sharp.IconButton btnCancelar;
        public FontAwesome.Sharp.IconButton btnAceptar;
        public System.Windows.Forms.Button btnCancelarOculto;
    }
}