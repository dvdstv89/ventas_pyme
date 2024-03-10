namespace NucleoEV.UI
{
    partial class GestionarSecurityTokenUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarSecurityTokenUI));
            this.panelDetails = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbxGrupoConsiliacion = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbxComplejos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxPermisos = new System.Windows.Forms.TextBox();
            this.tbDenominacion = new System.Windows.Forms.TextBox();
            this.panelBanner = new System.Windows.Forms.Panel();
            this.lbDetailsHeaderTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuBar = new System.Windows.Forms.ToolStrip();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.lwToken = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDetails.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelBanner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelDetails.Controls.Add(this.groupBox3);
            this.panelDetails.Controls.Add(this.groupBox2);
            this.panelDetails.Controls.Add(this.groupBox1);
            this.panelDetails.Controls.Add(this.tbDenominacion);
            this.panelDetails.Controls.Add(this.panelBanner);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.tbToken);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetails.Location = new System.Drawing.Point(824, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(395, 756);
            this.panelDetails.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbxGrupoConsiliacion);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(14, 574);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 182);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grupos de conciliación";
            // 
            // lbxGrupoConsiliacion
            // 
            this.lbxGrupoConsiliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxGrupoConsiliacion.Location = new System.Drawing.Point(6, 19);
            this.lbxGrupoConsiliacion.Multiline = true;
            this.lbxGrupoConsiliacion.Name = "lbxGrupoConsiliacion";
            this.lbxGrupoConsiliacion.ReadOnly = true;
            this.lbxGrupoConsiliacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lbxGrupoConsiliacion.Size = new System.Drawing.Size(355, 157);
            this.lbxGrupoConsiliacion.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbxComplejos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(14, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 182);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Complejos";
            // 
            // lbxComplejos
            // 
            this.lbxComplejos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxComplejos.Location = new System.Drawing.Point(6, 19);
            this.lbxComplejos.Multiline = true;
            this.lbxComplejos.Name = "lbxComplejos";
            this.lbxComplejos.ReadOnly = true;
            this.lbxComplejos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lbxComplejos.Size = new System.Drawing.Size(355, 157);
            this.lbxComplejos.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxPermisos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(14, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 241);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos";
            // 
            // lbxPermisos
            // 
            this.lbxPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxPermisos.Location = new System.Drawing.Point(6, 19);
            this.lbxPermisos.Multiline = true;
            this.lbxPermisos.Name = "lbxPermisos";
            this.lbxPermisos.ReadOnly = true;
            this.lbxPermisos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lbxPermisos.Size = new System.Drawing.Size(355, 216);
            this.lbxPermisos.TabIndex = 27;
            // 
            // tbDenominacion
            // 
            this.tbDenominacion.Location = new System.Drawing.Point(90, 89);
            this.tbDenominacion.Name = "tbDenominacion";
            this.tbDenominacion.ReadOnly = true;
            this.tbDenominacion.Size = new System.Drawing.Size(291, 20);
            this.tbDenominacion.TabIndex = 34;
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelBanner.Controls.Add(this.lbDetailsHeaderTitle);
            this.panelBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBanner.Location = new System.Drawing.Point(0, 0);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(395, 38);
            this.panelBanner.TabIndex = 30;
            // 
            // lbDetailsHeaderTitle
            // 
            this.lbDetailsHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDetailsHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.lbDetailsHeaderTitle.Name = "lbDetailsHeaderTitle";
            this.lbDetailsHeaderTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbDetailsHeaderTitle.Size = new System.Drawing.Size(395, 38);
            this.lbDetailsHeaderTitle.TabIndex = 3;
            this.lbDetailsHeaderTitle.Text = "Detalles";
            this.lbDetailsHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(11, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(11, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Token";
            // 
            // tbToken
            // 
            this.tbToken.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbToken.Location = new System.Drawing.Point(90, 58);
            this.tbToken.Margin = new System.Windows.Forms.Padding(2);
            this.tbToken.Name = "tbToken";
            this.tbToken.ReadOnly = true;
            this.tbToken.Size = new System.Drawing.Size(291, 20);
            this.tbToken.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuBar);
            this.panel1.Controls.Add(this.lwToken);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 756);
            this.panel1.TabIndex = 26;
            // 
            // menuBar
            // 
            this.menuBar.AutoSize = false;
            this.menuBar.BackColor = System.Drawing.Color.White;
            this.menuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEliminar,
            this.toolStripSeparator1,
            this.btnModificar,
            this.toolStripSeparator2,
            this.btnAdicionar});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuBar.Size = new System.Drawing.Size(818, 29);
            this.menuBar.TabIndex = 26;
            this.menuBar.Text = "toolStrip2";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Brown;
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEliminar.Size = new System.Drawing.Size(55, 26);
            this.btnEliminar.Text = "Eliminar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Blue;
            this.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModificar.Size = new System.Drawing.Size(64, 26);
            this.btnModificar.Text = "Modificar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdicionar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdicionar.Size = new System.Drawing.Size(63, 26);
            this.btnAdicionar.Text = "Adicionar";
            // 
            // lwToken
            // 
            this.lwToken.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader4});
            this.lwToken.FullRowSelect = true;
            this.lwToken.GridLines = true;
            this.lwToken.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lwToken.HideSelection = false;
            this.lwToken.Location = new System.Drawing.Point(11, 31);
            this.lwToken.Margin = new System.Windows.Forms.Padding(2);
            this.lwToken.MultiSelect = false;
            this.lwToken.Name = "lwToken";
            this.lwToken.ShowGroups = false;
            this.lwToken.Size = new System.Drawing.Size(805, 573);
            this.lwToken.TabIndex = 24;
            this.lwToken.UseCompatibleStateImageBehavior = false;
            this.lwToken.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Token";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Descripción";
            this.columnHeader8.Width = 250;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Complejos";
            this.columnHeader7.Width = 190;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Permisos";
            this.columnHeader4.Width = 206;
            // 
            // GestionarSecurityTokenUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 756);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GestionarSecurityTokenUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionar token";
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelBanner.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panelDetails;
        public System.Windows.Forms.Panel panelBanner;
        public System.Windows.Forms.Label lbDetailsHeaderTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbToken;
        public System.Windows.Forms.TextBox tbDenominacion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox lbxPermisos;
        public System.Windows.Forms.TextBox lbxComplejos;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton btnModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton btnAdicionar;
        public System.Windows.Forms.ListView lwToken;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ToolStrip menuBar;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox lbxGrupoConsiliacion;
    }
}