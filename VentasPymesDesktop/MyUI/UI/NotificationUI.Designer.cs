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
            this.btCancelar = new FontAwesome.Sharp.IconButton();
            this.icon = new FontAwesome.Sharp.IconPictureBox();
            this.textMensaje = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btCancelar.IconColor = System.Drawing.Color.Black;
            this.btCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCancelar.IconSize = 24;
            this.btCancelar.Location = new System.Drawing.Point(22, 0);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(35, 30);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.closeButton_Click);
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
            this.icon.Size = new System.Drawing.Size(57, 96);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icon.TabIndex = 4;
            this.icon.TabStop = false;
            // 
            // textMensaje
            // 
            this.textMensaje.Dock = System.Windows.Forms.DockStyle.Right;
            this.textMensaje.Location = new System.Drawing.Point(56, 0);
            this.textMensaje.Name = "textMensaje";
            this.textMensaje.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textMensaje.Size = new System.Drawing.Size(436, 96);
            this.textMensaje.TabIndex = 5;
            this.textMensaje.Text = "";
            // 
            // NotificationUI
            // 
            this.AcceptButton = this.btCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(492, 96);
            this.Controls.Add(this.textMensaje);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.btCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NotificationUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NotificationUI";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public FontAwesome.Sharp.IconButton btCancelar;
        public FontAwesome.Sharp.IconPictureBox icon;
        public System.Windows.Forms.RichTextBox textMensaje;
    }
}