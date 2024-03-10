namespace NucleoEV.UI
{
    partial class TiendaDepartamentoComercialUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiendaUI));
            this.label4 = new System.Windows.Forms.Label();
            this.tbTienda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMonedas = new System.Windows.Forms.ComboBox();
            this.lwFormaPago = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbEsTiendaOnline = new System.Windows.Forms.CheckBox();
            this.tbComplejo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrden = new System.Windows.Forms.NumericUpDown();
            this.tbEmail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tienda:";
            // 
            // tbTienda
            // 
            this.tbTienda.Location = new System.Drawing.Point(73, 11);
            this.tbTienda.Margin = new System.Windows.Forms.Padding(2);
            this.tbTienda.Name = "tbTienda";
            this.tbTienda.Size = new System.Drawing.Size(232, 20);
            this.tbTienda.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Complejo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Moneda:";
            // 
            // cbMonedas
            // 
            this.cbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonedas.FormattingEnabled = true;
            this.cbMonedas.Items.AddRange(new object[] {
            "MLC",
            "CUP"});
            this.cbMonedas.Location = new System.Drawing.Point(73, 63);
            this.cbMonedas.Name = "cbMonedas";
            this.cbMonedas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbMonedas.Size = new System.Drawing.Size(232, 21);
            this.cbMonedas.TabIndex = 12;
            // 
            // lwFormaPago
            // 
            this.lwFormaPago.CheckBoxes = true;
            this.lwFormaPago.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lwFormaPago.FullRowSelect = true;
            this.lwFormaPago.GridLines = true;
            this.lwFormaPago.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lwFormaPago.HideSelection = false;
            this.lwFormaPago.Location = new System.Drawing.Point(339, 14);
            this.lwFormaPago.Margin = new System.Windows.Forms.Padding(2);
            this.lwFormaPago.Name = "lwFormaPago";
            this.lwFormaPago.Scrollable = false;
            this.lwFormaPago.ShowGroups = false;
            this.lwFormaPago.Size = new System.Drawing.Size(294, 395);
            this.lwFormaPago.TabIndex = 27;
            this.lwFormaPago.UseCompatibleStateImageBehavior = false;
            this.lwFormaPago.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Id";
            this.columnHeader5.Width = 74;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Forma de pago";
            this.columnHeader6.Width = 213;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(387, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(513, 414);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // cbEsTiendaOnline
            // 
            this.cbEsTiendaOnline.AutoSize = true;
            this.cbEsTiendaOnline.Location = new System.Drawing.Point(12, 97);
            this.cbEsTiendaOnline.Name = "cbEsTiendaOnline";
            this.cbEsTiendaOnline.Size = new System.Drawing.Size(86, 17);
            this.cbEsTiendaOnline.TabIndex = 34;
            this.cbEsTiendaOnline.Text = "tienda online";
            this.cbEsTiendaOnline.UseVisualStyleBackColor = true;
            // 
            // tbComplejo
            // 
            this.tbComplejo.Location = new System.Drawing.Point(73, 35);
            this.tbComplejo.Margin = new System.Windows.Forms.Padding(2);
            this.tbComplejo.Name = "tbComplejo";
            this.tbComplejo.Size = new System.Drawing.Size(232, 20);
            this.tbComplejo.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Correo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Orden:";
            // 
            // tbOrden
            // 
            this.tbOrden.Location = new System.Drawing.Point(175, 96);
            this.tbOrden.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.tbOrden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbOrden.Name = "tbOrden";
            this.tbOrden.Size = new System.Drawing.Size(130, 20);
            this.tbOrden.TabIndex = 40;
            this.tbOrden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(73, 122);
            this.tbEmail.Multiline = true;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(232, 121);
            this.tbEmail.TabIndex = 42;
            // 
            // TiendaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(657, 467);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbOrden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbComplejo);
            this.Controls.Add(this.cbEsTiendaOnline);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lwFormaPago);
            this.Controls.Add(this.cbMonedas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTienda);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TiendaUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tienda";
            this.Load += new System.EventHandler(this.TiendaDetalleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbMonedas;
        public System.Windows.Forms.ListView lwFormaPago;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox tbTienda;
        public System.Windows.Forms.CheckBox cbEsTiendaOnline;
        public System.Windows.Forms.TextBox tbComplejo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown tbOrden;
        public System.Windows.Forms.TextBox tbEmail;
    }
}