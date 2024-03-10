namespace NucleoEV.UI
{
    partial class SecurityTokenUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityTokenUI));
            this.label1 = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.lwComplejo = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lwPermiso = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.tbDenominacion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lwGrupoConciliacion = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Token";
            // 
            // tbToken
            // 
            this.tbToken.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbToken.Location = new System.Drawing.Point(64, 24);
            this.tbToken.Margin = new System.Windows.Forms.Padding(2);
            this.tbToken.Name = "tbToken";
            this.tbToken.ReadOnly = true;
            this.tbToken.Size = new System.Drawing.Size(243, 20);
            this.tbToken.TabIndex = 1;
            // 
            // lwComplejo
            // 
            this.lwComplejo.CheckBoxes = true;
            this.lwComplejo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1});
            this.lwComplejo.FullRowSelect = true;
            this.lwComplejo.GridLines = true;
            this.lwComplejo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lwComplejo.HideSelection = false;
            this.lwComplejo.Location = new System.Drawing.Point(329, 107);
            this.lwComplejo.Margin = new System.Windows.Forms.Padding(2);
            this.lwComplejo.Name = "lwComplejo";
            this.lwComplejo.Scrollable = false;
            this.lwComplejo.ShowGroups = false;
            this.lwComplejo.Size = new System.Drawing.Size(294, 417);
            this.lwComplejo.TabIndex = 25;
            this.lwComplejo.UseCompatibleStateImageBehavior = false;
            this.lwComplejo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Complejo";
            this.columnHeader1.Width = 213;
            // 
            // lwPermiso
            // 
            this.lwPermiso.CheckBoxes = true;
            this.lwPermiso.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lwPermiso.FullRowSelect = true;
            this.lwPermiso.GridLines = true;
            this.lwPermiso.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lwPermiso.HideSelection = false;
            this.lwPermiso.Location = new System.Drawing.Point(13, 107);
            this.lwPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.lwPermiso.Name = "lwPermiso";
            this.lwPermiso.ShowGroups = false;
            this.lwPermiso.Size = new System.Drawing.Size(294, 417);
            this.lwPermiso.TabIndex = 26;
            this.lwPermiso.UseCompatibleStateImageBehavior = false;
            this.lwPermiso.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Id";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Permiso";
            this.columnHeader4.Width = 213;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Descripción";
            // 
            // tbDenominacion
            // 
            this.tbDenominacion.Location = new System.Drawing.Point(90, 63);
            this.tbDenominacion.Name = "tbDenominacion";
            this.tbDenominacion.Size = new System.Drawing.Size(533, 20);
            this.tbDenominacion.TabIndex = 28;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(822, 558);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(696, 558);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lwGrupoConciliacion
            // 
            this.lwGrupoConciliacion.CheckBoxes = true;
            this.lwGrupoConciliacion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lwGrupoConciliacion.FullRowSelect = true;
            this.lwGrupoConciliacion.GridLines = true;
            this.lwGrupoConciliacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lwGrupoConciliacion.HideSelection = false;
            this.lwGrupoConciliacion.Location = new System.Drawing.Point(648, 107);
            this.lwGrupoConciliacion.Margin = new System.Windows.Forms.Padding(2);
            this.lwGrupoConciliacion.Name = "lwGrupoConciliacion";
            this.lwGrupoConciliacion.Scrollable = false;
            this.lwGrupoConciliacion.ShowGroups = false;
            this.lwGrupoConciliacion.Size = new System.Drawing.Size(294, 417);
            this.lwGrupoConciliacion.TabIndex = 32;
            this.lwGrupoConciliacion.UseCompatibleStateImageBehavior = false;
            this.lwGrupoConciliacion.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Id";
            this.columnHeader5.Width = 74;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Grupo de conciliación";
            this.columnHeader6.Width = 213;
            // 
            // SecurityTokenUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(961, 607);
            this.Controls.Add(this.lwGrupoConciliacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbDenominacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lwPermiso);
            this.Controls.Add(this.lwComplejo);
            this.Controls.Add(this.tbToken);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SecurityTokenUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clave de seguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lwComplejo;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ListView lwPermiso;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbToken;
        public System.Windows.Forms.TextBox tbDenominacion;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.ListView lwGrupoConciliacion;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}