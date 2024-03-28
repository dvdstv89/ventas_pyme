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
            this.tbHost = new System.Windows.Forms.TextBox();
            this.labelHost = new System.Windows.Forms.Label();
            this.labelToken = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.tbRutaBackend = new System.Windows.Forms.TextBox();
            this.cbCheckApi = new System.Windows.Forms.CheckBox();
            this.labelPuerto = new System.Windows.Forms.Label();
            this.tbPuerto = new System.Windows.Forms.NumericUpDown();
            this.cbProtocolo = new System.Windows.Forms.ComboBox();
            this.labelProtocolo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tbPuerto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGuardar
            // 
            this.btGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardar.IconColor = System.Drawing.Color.Black;
            this.btGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGuardar.Location = new System.Drawing.Point(199, 17);
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
            this.btCancelar.Location = new System.Drawing.Point(308, 17);
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
            this.btProbar.Location = new System.Drawing.Point(90, 17);
            this.btProbar.Name = "btProbar";
            this.btProbar.Size = new System.Drawing.Size(75, 23);
            this.btProbar.TabIndex = 9;
            this.btProbar.Text = "Probar";
            this.btProbar.UseVisualStyleBackColor = true;
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(165, 40);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(170, 20);
            this.tbHost.TabIndex = 62;
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.BackColor = System.Drawing.Color.Transparent;
            this.labelHost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelHost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelHost.Location = new System.Drawing.Point(142, 40);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(17, 13);
            this.labelHost.TabIndex = 64;
            this.labelHost.Text = "//";
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.BackColor = System.Drawing.Color.Transparent;
            this.labelToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelToken.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelToken.Location = new System.Drawing.Point(15, 76);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(38, 13);
            this.labelToken.TabIndex = 65;
            this.labelToken.Text = "Token";
            // 
            // tbToken
            // 
            this.tbToken.Location = new System.Drawing.Point(69, 73);
            this.tbToken.Name = "tbToken";
            this.tbToken.Size = new System.Drawing.Size(353, 20);
            this.tbToken.TabIndex = 63;
            // 
            // tbRutaBackend
            // 
            this.tbRutaBackend.Location = new System.Drawing.Point(95, 110);
            this.tbRutaBackend.Name = "tbRutaBackend";
            this.tbRutaBackend.Size = new System.Drawing.Size(327, 20);
            this.tbRutaBackend.TabIndex = 67;
            // 
            // cbCheckApi
            // 
            this.cbCheckApi.AutoSize = true;
            this.cbCheckApi.Location = new System.Drawing.Point(18, 112);
            this.cbCheckApi.Name = "cbCheckApi";
            this.cbCheckApi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCheckApi.Size = new System.Drawing.Size(75, 17);
            this.cbCheckApi.TabIndex = 71;
            this.cbCheckApi.Text = "Check Api";
            this.cbCheckApi.UseVisualStyleBackColor = true;
            // 
            // labelPuerto
            // 
            this.labelPuerto.AutoSize = true;
            this.labelPuerto.BackColor = System.Drawing.Color.Transparent;
            this.labelPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelPuerto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelPuerto.Location = new System.Drawing.Point(341, 40);
            this.labelPuerto.Name = "labelPuerto";
            this.labelPuerto.Size = new System.Drawing.Size(10, 13);
            this.labelPuerto.TabIndex = 72;
            this.labelPuerto.Text = ":";
            // 
            // tbPuerto
            // 
            this.tbPuerto.Location = new System.Drawing.Point(357, 40);
            this.tbPuerto.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tbPuerto.Name = "tbPuerto";
            this.tbPuerto.Size = new System.Drawing.Size(65, 20);
            this.tbPuerto.TabIndex = 73;
            // 
            // cbProtocolo
            // 
            this.cbProtocolo.FormattingEnabled = true;
            this.cbProtocolo.Location = new System.Drawing.Point(69, 40);
            this.cbProtocolo.Name = "cbProtocolo";
            this.cbProtocolo.Size = new System.Drawing.Size(67, 21);
            this.cbProtocolo.TabIndex = 74;
            // 
            // labelProtocolo
            // 
            this.labelProtocolo.AutoSize = true;
            this.labelProtocolo.BackColor = System.Drawing.Color.Transparent;
            this.labelProtocolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelProtocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelProtocolo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelProtocolo.Location = new System.Drawing.Point(15, 40);
            this.labelProtocolo.Name = "labelProtocolo";
            this.labelProtocolo.Size = new System.Drawing.Size(52, 13);
            this.labelProtocolo.TabIndex = 75;
            this.labelProtocolo.Text = "Protocolo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Controls.Add(this.btGuardar);
            this.panel1.Controls.Add(this.btProbar);
            this.panel1.Location = new System.Drawing.Point(12, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 61);
            this.panel1.TabIndex = 76;
            // 
            // ApiRestUI
            // 
            this.AcceptButton = this.btGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(431, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelProtocolo);
            this.Controls.Add(this.cbProtocolo);
            this.Controls.Add(this.tbPuerto);
            this.Controls.Add(this.labelPuerto);
            this.Controls.Add(this.cbCheckApi);
            this.Controls.Add(this.tbRutaBackend);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.labelHost);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.tbToken);
            this.Name = "ApiRestUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExternalSystemUI";
            ((System.ComponentModel.ISupportInitialize)(this.tbPuerto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public FontAwesome.Sharp.IconButton btGuardar;
        public FontAwesome.Sharp.IconButton btCancelar;
        public FontAwesome.Sharp.IconButton btProbar;
        public System.Windows.Forms.TextBox tbHost;
        public System.Windows.Forms.Label labelHost;
        public System.Windows.Forms.Label labelToken;
        public System.Windows.Forms.TextBox tbToken;
        public System.Windows.Forms.TextBox tbRutaBackend;
        public System.Windows.Forms.CheckBox cbCheckApi;
        public System.Windows.Forms.Label labelPuerto;
        public System.Windows.Forms.NumericUpDown tbPuerto;
        public System.Windows.Forms.ComboBox cbProtocolo;
        public System.Windows.Forms.Label labelProtocolo;
        private System.Windows.Forms.Panel panel1;
    }
}