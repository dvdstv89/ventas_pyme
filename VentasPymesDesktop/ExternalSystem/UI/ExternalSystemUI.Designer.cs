namespace ExternalSystem.UI 
{ 
    partial class ExternalSystemUI
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
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbBD = new System.Windows.Forms.TextBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelServidor = new System.Windows.Forms.Label();
            this.comboBoxTipoExternalSystem = new System.Windows.Forms.ComboBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelDominio = new System.Windows.Forms.Label();
            this.comboBoxDominio = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageDataSourse = new System.Windows.Forms.TabPage();
            this.labelTipoDatasourse = new System.Windows.Forms.Label();
            this.comboBoxTipoDatasourse = new System.Windows.Forms.ComboBox();
            this.btGuardar = new FontAwesome.Sharp.IconButton();
            this.btCancelar = new FontAwesome.Sharp.IconButton();
            this.btProbar = new FontAwesome.Sharp.IconButton();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageDataSourse.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(100, 85);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(169, 20);
            this.tbPass.TabIndex = 7;
            // 
            // tbBD
            // 
            this.tbBD.Location = new System.Drawing.Point(100, 111);
            this.tbBD.Name = "tbBD";
            this.tbBD.Size = new System.Drawing.Size(169, 20);
            this.tbBD.TabIndex = 8;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(100, 59);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(169, 20);
            this.tbUsuario.TabIndex = 6;
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(100, 33);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(169, 20);
            this.tbServidor.TabIndex = 5;
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.BackColor = System.Drawing.Color.Transparent;
            this.labelDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelDatabase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelDatabase.Location = new System.Drawing.Point(6, 114);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(75, 13);
            this.labelDatabase.TabIndex = 48;
            this.labelDatabase.Text = "Base de datos";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.BackColor = System.Drawing.Color.Transparent;
            this.labelPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelPass.Location = new System.Drawing.Point(6, 88);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(61, 13);
            this.labelPass.TabIndex = 47;
            this.labelPass.Text = "Contraseña";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.labelUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelUsuario.Location = new System.Drawing.Point(6, 62);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 46;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.BackColor = System.Drawing.Color.Transparent;
            this.labelServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelServidor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelServidor.Location = new System.Drawing.Point(6, 33);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(46, 13);
            this.labelServidor.TabIndex = 45;
            this.labelServidor.Text = "Servidor";
            // 
            // comboBoxTipoExternalSystem
            // 
            this.comboBoxTipoExternalSystem.FormattingEnabled = true;
            this.comboBoxTipoExternalSystem.Location = new System.Drawing.Point(100, 6);
            this.comboBoxTipoExternalSystem.Name = "comboBoxTipoExternalSystem";
            this.comboBoxTipoExternalSystem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoExternalSystem.TabIndex = 1;
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(6, 9);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(28, 13);
            this.labelTipo.TabIndex = 54;
            this.labelTipo.Text = "Tipo";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(6, 36);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(100, 33);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(121, 20);
            this.textBoxNombre.TabIndex = 2;
            // 
            // labelDominio
            // 
            this.labelDominio.AutoSize = true;
            this.labelDominio.Location = new System.Drawing.Point(6, 62);
            this.labelDominio.Name = "labelDominio";
            this.labelDominio.Size = new System.Drawing.Size(45, 13);
            this.labelDominio.TabIndex = 57;
            this.labelDominio.Text = "Dominio";
            // 
            // comboBoxDominio
            // 
            this.comboBoxDominio.FormattingEnabled = true;
            this.comboBoxDominio.Location = new System.Drawing.Point(100, 59);
            this.comboBoxDominio.Name = "comboBoxDominio";
            this.comboBoxDominio.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDominio.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageDataSourse);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(312, 190);
            this.tabControl.TabIndex = 59;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.labelTipo);
            this.tabPageGeneral.Controls.Add(this.comboBoxTipoExternalSystem);
            this.tabPageGeneral.Controls.Add(this.labelDominio);
            this.tabPageGeneral.Controls.Add(this.textBoxNombre);
            this.tabPageGeneral.Controls.Add(this.comboBoxDominio);
            this.tabPageGeneral.Controls.Add(this.labelNombre);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(304, 161);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPageDataSourse
            // 
            this.tabPageDataSourse.Controls.Add(this.labelTipoDatasourse);
            this.tabPageDataSourse.Controls.Add(this.comboBoxTipoDatasourse);
            this.tabPageDataSourse.Controls.Add(this.tbServidor);
            this.tabPageDataSourse.Controls.Add(this.tbPass);
            this.tabPageDataSourse.Controls.Add(this.labelServidor);
            this.tabPageDataSourse.Controls.Add(this.tbBD);
            this.tabPageDataSourse.Controls.Add(this.labelUsuario);
            this.tabPageDataSourse.Controls.Add(this.tbUsuario);
            this.tabPageDataSourse.Controls.Add(this.labelPass);
            this.tabPageDataSourse.Controls.Add(this.labelDatabase);
            this.tabPageDataSourse.Location = new System.Drawing.Point(4, 25);
            this.tabPageDataSourse.Name = "tabPageDataSourse";
            this.tabPageDataSourse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataSourse.Size = new System.Drawing.Size(304, 161);
            this.tabPageDataSourse.TabIndex = 1;
            this.tabPageDataSourse.Text = "Datasourse";
            this.tabPageDataSourse.UseVisualStyleBackColor = true;
            // 
            // labelTipoDatasourse
            // 
            this.labelTipoDatasourse.AutoSize = true;
            this.labelTipoDatasourse.Location = new System.Drawing.Point(6, 9);
            this.labelTipoDatasourse.Name = "labelTipoDatasourse";
            this.labelTipoDatasourse.Size = new System.Drawing.Size(28, 13);
            this.labelTipoDatasourse.TabIndex = 56;
            this.labelTipoDatasourse.Text = "Tipo";
            // 
            // comboBoxTipoDatasourse
            // 
            this.comboBoxTipoDatasourse.FormattingEnabled = true;
            this.comboBoxTipoDatasourse.Location = new System.Drawing.Point(100, 6);
            this.comboBoxTipoDatasourse.Name = "comboBoxTipoDatasourse";
            this.comboBoxTipoDatasourse.Size = new System.Drawing.Size(169, 21);
            this.comboBoxTipoDatasourse.TabIndex = 4;
            // 
            // btGuardar
            // 
            this.btGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btGuardar.IconColor = System.Drawing.Color.Black;
            this.btGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btGuardar.Location = new System.Drawing.Point(162, 208);
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
            this.btCancelar.Location = new System.Drawing.Point(249, 208);
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
            this.btProbar.Location = new System.Drawing.Point(12, 208);
            this.btProbar.Name = "btProbar";
            this.btProbar.Size = new System.Drawing.Size(75, 23);
            this.btProbar.TabIndex = 9;
            this.btProbar.Text = "Probar";
            this.btProbar.UseVisualStyleBackColor = true;
            // 
            // ExternalSystemUI
            // 
            this.AcceptButton = this.btGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(332, 247);
            this.Controls.Add(this.btProbar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.tabControl);
            this.Name = "ExternalSystemUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExternalSystemUI";
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageDataSourse.ResumeLayout(false);
            this.tabPageDataSourse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox tbPass;
        public System.Windows.Forms.TextBox tbBD;
        public System.Windows.Forms.TextBox tbUsuario;
        public System.Windows.Forms.TextBox tbServidor;
        public System.Windows.Forms.TabPage tabPageGeneral;
        public System.Windows.Forms.TabPage tabPageDataSourse;
        public FontAwesome.Sharp.IconButton btGuardar;
        public FontAwesome.Sharp.IconButton btCancelar;
        public System.Windows.Forms.Label labelTipo;
        public System.Windows.Forms.Label labelNombre;
        public System.Windows.Forms.Label labelDominio;
        public FontAwesome.Sharp.IconButton btProbar;
        public System.Windows.Forms.Label labelDatabase;
        public System.Windows.Forms.Label labelPass;
        public System.Windows.Forms.Label labelUsuario;
        public System.Windows.Forms.Label labelServidor;
        public System.Windows.Forms.Label labelTipoDatasourse;
        public System.Windows.Forms.ComboBox comboBoxTipoExternalSystem;
        public System.Windows.Forms.TextBox textBoxNombre;
        public System.Windows.Forms.ComboBox comboBoxDominio;
        public System.Windows.Forms.ComboBox comboBoxTipoDatasourse;
        public System.Windows.Forms.TabControl tabControl;
    }
}