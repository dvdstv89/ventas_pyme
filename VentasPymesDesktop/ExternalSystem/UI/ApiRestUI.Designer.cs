namespace ExternalSystem.UI 
{ 
    partial class ApiRestUI
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
            this.btGuardar = new FontAwesome.Sharp.IconButton();
            this.btCancelar = new FontAwesome.Sharp.IconButton();
            this.btProbar = new FontAwesome.Sharp.IconButton();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.labelToken = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btGuardar
            // 
            this.btGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardar.IconColor = System.Drawing.Color.Black;
            this.btGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGuardar.Location = new System.Drawing.Point(120, 119);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(75, 23);
            this.btGuardar.TabIndex = 10;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btCancelar.IconColor = System.Drawing.Color.Black;
            this.btCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btCancelar.Location = new System.Drawing.Point(229, 119);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 11;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btProbar
            // 
            this.btProbar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btProbar.IconColor = System.Drawing.Color.Black;
            this.btProbar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btProbar.Location = new System.Drawing.Point(12, 119);
            this.btProbar.Name = "btProbar";
            this.btProbar.Size = new System.Drawing.Size(75, 23);
            this.btProbar.TabIndex = 9;
            this.btProbar.Text = "Probar";
            this.btProbar.UseVisualStyleBackColor = true;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(68, 30);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(256, 20);
            this.tbUrl.TabIndex = 62;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.BackColor = System.Drawing.Color.Transparent;
            this.labelUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelUrl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelUrl.Location = new System.Drawing.Point(15, 33);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(46, 13);
            this.labelUrl.TabIndex = 64;
            this.labelUrl.Text = "Servidor";
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.BackColor = System.Drawing.Color.Transparent;
            this.labelToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelToken.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelToken.Location = new System.Drawing.Point(15, 59);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(38, 13);
            this.labelToken.TabIndex = 65;
            this.labelToken.Text = "Token";
            // 
            // tbToken
            // 
            this.tbToken.Location = new System.Drawing.Point(68, 56);
            this.tbToken.Name = "tbToken";
            this.tbToken.Size = new System.Drawing.Size(256, 20);
            this.tbToken.TabIndex = 63;
            // 
            // ApiRestUI
            // 
            this.AcceptButton = this.btGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(337, 160);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.tbToken);
            this.Controls.Add(this.btProbar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGuardar);
            this.Name = "ApiRestUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExternalSystemUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public FontAwesome.Sharp.IconButton btGuardar;
        public FontAwesome.Sharp.IconButton btCancelar;
        public FontAwesome.Sharp.IconButton btProbar;
        public System.Windows.Forms.TextBox tbUrl;
        public System.Windows.Forms.Label labelUrl;
        public System.Windows.Forms.Label labelToken;
        public System.Windows.Forms.TextBox tbToken;
    }
}