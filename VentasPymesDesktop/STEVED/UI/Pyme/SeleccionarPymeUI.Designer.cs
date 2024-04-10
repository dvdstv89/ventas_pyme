namespace NucleoEV.UI.Pyme
{
    partial class SeleccionarPymeUI
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
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancelar = new FontAwesome.Sharp.IconButton();
            this.btAceptar = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(80, 80);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(266, 21);
            this.cbEmpresa.TabIndex = 0;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Location = new System.Drawing.Point(9, 83);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(35, 13);
            this.labelEmpresa.TabIndex = 1;
            this.labelEmpresa.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Controls.Add(this.btAceptar);
            this.panel1.Location = new System.Drawing.Point(-64, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 61);
            this.panel1.TabIndex = 77;
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
            // btAceptar
            // 
            this.btAceptar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btAceptar.IconColor = System.Drawing.Color.Black;
            this.btAceptar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btAceptar.Location = new System.Drawing.Point(199, 17);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 10;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.BasketShopping;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 49;
            this.iconPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(49, 50);
            this.iconPictureBox1.TabIndex = 79;
            this.iconPictureBox1.TabStop = false;
            // 
            // lbEstado
            // 
            this.lbEstado.BackColor = System.Drawing.Color.Transparent;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.ForeColor = System.Drawing.Color.Black;
            this.lbEstado.Location = new System.Drawing.Point(67, 12);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(279, 50);
            this.lbEstado.TabIndex = 78;
            this.lbEstado.Text = "Procesando...";
            this.lbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SeleccionarPymeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 186);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelEmpresa);
            this.Controls.Add(this.cbEmpresa);
            this.Name = "SeleccionarPymeUI";
            this.Text = "SeleccionarPymeUI";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public FontAwesome.Sharp.IconButton btCancelar;
        public FontAwesome.Sharp.IconButton btAceptar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        public System.Windows.Forms.Label lbEstado;
        public System.Windows.Forms.ComboBox cbEmpresa;
        public System.Windows.Forms.Label labelEmpresa;
    }
}