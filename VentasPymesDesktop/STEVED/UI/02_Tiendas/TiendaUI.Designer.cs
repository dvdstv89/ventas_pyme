namespace NucleoEV.UI
{
    partial class TiendaUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrden = new System.Windows.Forms.NumericUpDown();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.cbGrupoTienda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaximoTrabajadores = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCantidadDependientes = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCantdadJefesBrigadas = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cbComplejo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaximoTrabajadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCantidadDependientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCantdadJefesBrigadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre:";
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
            this.label6.Location = new System.Drawing.Point(8, 90);
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
            this.cbMonedas.Location = new System.Drawing.Point(73, 90);
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
            this.btnCancelar.Location = new System.Drawing.Point(513, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(387, 414);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Correo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 268);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Cantidad Máxima de Trabajadores:\r\n";
            // 
            // tbOrden
            // 
            this.tbOrden.Location = new System.Drawing.Point(184, 241);
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
            this.tbOrden.Size = new System.Drawing.Size(121, 20);
            this.tbOrden.TabIndex = 40;
            this.tbOrden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(73, 114);
            this.tbEmail.Multiline = true;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(232, 121);
            this.tbEmail.TabIndex = 42;
            // 
            // cbGrupoTienda
            // 
            this.cbGrupoTienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupoTienda.FormattingEnabled = true;
            this.cbGrupoTienda.Items.AddRange(new object[] {
            "MLC",
            "CUP"});
            this.cbGrupoTienda.Location = new System.Drawing.Point(73, 63);
            this.cbGrupoTienda.Name = "cbGrupoTienda";
            this.cbGrupoTienda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbGrupoTienda.Size = new System.Drawing.Size(232, 21);
            this.cbGrupoTienda.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Grupo:";
            // 
            // tbMaximoTrabajadores
            // 
            this.tbMaximoTrabajadores.Location = new System.Drawing.Point(184, 266);
            this.tbMaximoTrabajadores.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.tbMaximoTrabajadores.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbMaximoTrabajadores.Name = "tbMaximoTrabajadores";
            this.tbMaximoTrabajadores.Size = new System.Drawing.Size(121, 20);
            this.tbMaximoTrabajadores.TabIndex = 46;
            this.tbMaximoTrabajadores.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 243);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Orden Comercial:";
            // 
            // tbCantidadDependientes
            // 
            this.tbCantidadDependientes.Location = new System.Drawing.Point(184, 292);
            this.tbCantidadDependientes.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.tbCantidadDependientes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbCantidadDependientes.Name = "tbCantidadDependientes";
            this.tbCantidadDependientes.Size = new System.Drawing.Size(121, 20);
            this.tbCantidadDependientes.TabIndex = 48;
            this.tbCantidadDependientes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 294);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Cantidad Actual Dependientes:\r\n";
            // 
            // tbCantdadJefesBrigadas
            // 
            this.tbCantdadJefesBrigadas.Location = new System.Drawing.Point(184, 318);
            this.tbCantdadJefesBrigadas.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.tbCantdadJefesBrigadas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbCantdadJefesBrigadas.Name = "tbCantdadJefesBrigadas";
            this.tbCantdadJefesBrigadas.Size = new System.Drawing.Size(121, 20);
            this.tbCantdadJefesBrigadas.TabIndex = 50;
            this.tbCantdadJefesBrigadas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 320);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Cantidad Actual Jefe Brigada:\r\n";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(261, 414);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 30);
            this.btnCerrar.TabIndex = 51;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.Location = new System.Drawing.Point(135, 414);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(120, 30);
            this.btnAbrir.TabIndex = 52;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(9, 414);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 53;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // cbComplejo
            // 
            this.cbComplejo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComplejo.FormattingEnabled = true;
            this.cbComplejo.Items.AddRange(new object[] {
            "MLC",
            "CUP"});
            this.cbComplejo.Location = new System.Drawing.Point(73, 36);
            this.cbComplejo.Name = "cbComplejo";
            this.cbComplejo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbComplejo.Size = new System.Drawing.Size(232, 21);
            this.cbComplejo.TabIndex = 54;
            // 
            // TiendaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(657, 467);
            this.Controls.Add(this.cbComplejo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.tbCantdadJefesBrigadas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCantidadDependientes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMaximoTrabajadores);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbGrupoTienda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbOrden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.tbMaximoTrabajadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCantidadDependientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCantdadJefesBrigadas)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown tbOrden;
        public System.Windows.Forms.TextBox tbEmail;
        public System.Windows.Forms.ComboBox cbGrupoTienda;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown tbMaximoTrabajadores;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown tbCantidadDependientes;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown tbCantdadJefesBrigadas;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnCerrar;
        public System.Windows.Forms.Button btnAbrir;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.ComboBox cbComplejo;
    }
}