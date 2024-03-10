namespace NucleoEV.UI
{
    partial class GestionarDepartamentoComercialUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarTiendaUI));
            System.Windows.Forms.ListViewItem listViewItem40 = new System.Windows.Forms.ListViewItem("ENERO");
            System.Windows.Forms.ListViewItem listViewItem41 = new System.Windows.Forms.ListViewItem("FEBRERO");
            System.Windows.Forms.ListViewItem listViewItem42 = new System.Windows.Forms.ListViewItem("MARZO");
            System.Windows.Forms.ListViewItem listViewItem43 = new System.Windows.Forms.ListViewItem("ABRIL");
            System.Windows.Forms.ListViewItem listViewItem44 = new System.Windows.Forms.ListViewItem("MAYO");
            System.Windows.Forms.ListViewItem listViewItem45 = new System.Windows.Forms.ListViewItem("JUNIO");
            System.Windows.Forms.ListViewItem listViewItem46 = new System.Windows.Forms.ListViewItem("JULIO");
            System.Windows.Forms.ListViewItem listViewItem47 = new System.Windows.Forms.ListViewItem("AGOSTO");
            System.Windows.Forms.ListViewItem listViewItem48 = new System.Windows.Forms.ListViewItem("SEPTIEMBRE");
            System.Windows.Forms.ListViewItem listViewItem49 = new System.Windows.Forms.ListViewItem("OCTUBRE");
            System.Windows.Forms.ListViewItem listViewItem50 = new System.Windows.Forms.ListViewItem("NOVIEMBRE");
            System.Windows.Forms.ListViewItem listViewItem51 = new System.Windows.Forms.ListViewItem("DICIEMBRE");
            System.Windows.Forms.ListViewItem listViewItem52 = new System.Windows.Forms.ListViewItem(new string[] {
            "TOTAL",
            "AÑO 2023"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Chocolate, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.separadorModificarTienda = new System.Windows.Forms.ToolStripSeparator();
            this.btnModificar = new System.Windows.Forms.ToolStripButton();
            this.separadorAdicionarTienda = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.separadorAbrirCerrarTienda = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.separadorPlanVentaTienda = new System.Windows.Forms.ToolStripSeparator();
            this.btnGestionarPlanVenta = new System.Windows.Forms.ToolStripButton();
            this.cbComplejos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lwTiendas = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDetails = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbxFormasPago = new System.Windows.Forms.TextBox();
            this.panelBanner = new System.Windows.Forms.Panel();
            this.lbDetailsHeaderTitle = new System.Windows.Forms.Label();
            this.tbMoneda = new System.Windows.Forms.TextBox();
            this.tbComplejo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNombreTienda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lwPlanVenta = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBanner.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lwTiendas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 764);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cbComplejos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 34);
            this.panel2.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(313, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(505, 34);
            this.panel3.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEliminar,
            this.separadorModificarTienda,
            this.btnModificar,
            this.separadorAdicionarTienda,
            this.btnAdicionar,
            this.separadorAbrirCerrarTienda,
            this.btnAbrir,
            this.btnCerrar,
            this.separadorPlanVentaTienda,
            this.btnGestionarPlanVenta});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(505, 29);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Highlight;
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
            // separadorModificarTienda
            // 
            this.separadorModificarTienda.Name = "separadorModificarTienda";
            this.separadorModificarTienda.Size = new System.Drawing.Size(6, 29);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModificar.Size = new System.Drawing.Size(64, 26);
            this.btnModificar.Text = "Modificar";
            // 
            // separadorAdicionarTienda
            // 
            this.separadorAdicionarTienda.Name = "separadorAdicionarTienda";
            this.separadorAdicionarTienda.Size = new System.Drawing.Size(6, 29);
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
            // separadorAbrirCerrarTienda
            // 
            this.separadorAbrirCerrarTienda.Name = "separadorAbrirCerrarTienda";
            this.separadorAbrirCerrarTienda.Size = new System.Drawing.Size(6, 29);
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAbrir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAbrir.Size = new System.Drawing.Size(39, 26);
            this.btnAbrir.Text = "Abrir";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCerrar.Size = new System.Drawing.Size(46, 26);
            this.btnCerrar.Text = "Cerrar";
            // 
            // separadorPlanVentaTienda
            // 
            this.separadorPlanVentaTienda.Name = "separadorPlanVentaTienda";
            this.separadorPlanVentaTienda.Size = new System.Drawing.Size(6, 29);
            // 
            // btnGestionarPlanVenta
            // 
            this.btnGestionarPlanVenta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGestionarPlanVenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGestionarPlanVenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGestionarPlanVenta.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGestionarPlanVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionarPlanVenta.Image")));
            this.btnGestionarPlanVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGestionarPlanVenta.Name = "btnGestionarPlanVenta";
            this.btnGestionarPlanVenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGestionarPlanVenta.Size = new System.Drawing.Size(86, 26);
            this.btnGestionarPlanVenta.Text = "Plan de venta";
            this.btnGestionarPlanVenta.ToolTipText = "Plan de venta";
            // 
            // cbComplejos
            // 
            this.cbComplejos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComplejos.FormattingEnabled = true;
            this.cbComplejos.Location = new System.Drawing.Point(76, 8);
            this.cbComplejos.Name = "cbComplejos";
            this.cbComplejos.Size = new System.Drawing.Size(231, 21);
            this.cbComplejos.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Complejo:";
            // 
            // lwTiendas
            // 
            this.lwTiendas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader9,
            this.columnHeader1});
            this.lwTiendas.FullRowSelect = true;
            this.lwTiendas.GridLines = true;
            this.lwTiendas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lwTiendas.HideSelection = false;
            this.lwTiendas.Location = new System.Drawing.Point(11, 37);
            this.lwTiendas.Margin = new System.Windows.Forms.Padding(2);
            this.lwTiendas.MultiSelect = false;
            this.lwTiendas.Name = "lwTiendas";
            this.lwTiendas.Scrollable = false;
            this.lwTiendas.ShowGroups = false;
            this.lwTiendas.Size = new System.Drawing.Size(805, 567);
            this.lwTiendas.TabIndex = 9;
            this.lwTiendas.UseCompatibleStateImageBehavior = false;
            this.lwTiendas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tienda";
            this.columnHeader3.Width = 237;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Estado";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Moneda";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Plan del año";
            this.columnHeader1.Width = 150;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetails.Controls.Add(this.groupBox2);
            this.panelDetails.Controls.Add(this.panelBanner);
            this.panelDetails.Controls.Add(this.tbMoneda);
            this.panelDetails.Controls.Add(this.tbComplejo);
            this.panelDetails.Controls.Add(this.label6);
            this.panelDetails.Controls.Add(this.label5);
            this.panelDetails.Controls.Add(this.tbNombreTienda);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.groupBox1);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetails.Location = new System.Drawing.Point(824, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(395, 764);
            this.panelDetails.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbxFormasPago);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(14, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 153);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Formas de pago";
            // 
            // lbxFormasPago
            // 
            this.lbxFormasPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxFormasPago.Location = new System.Drawing.Point(6, 19);
            this.lbxFormasPago.Multiline = true;
            this.lbxFormasPago.Name = "lbxFormasPago";
            this.lbxFormasPago.ReadOnly = true;
            this.lbxFormasPago.Size = new System.Drawing.Size(355, 129);
            this.lbxFormasPago.TabIndex = 28;
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelBanner.Controls.Add(this.lbDetailsHeaderTitle);
            this.panelBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBanner.Location = new System.Drawing.Point(0, 0);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(393, 38);
            this.panelBanner.TabIndex = 29;
            // 
            // lbDetailsHeaderTitle
            // 
            this.lbDetailsHeaderTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDetailsHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.lbDetailsHeaderTitle.Name = "lbDetailsHeaderTitle";
            this.lbDetailsHeaderTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbDetailsHeaderTitle.Size = new System.Drawing.Size(269, 38);
            this.lbDetailsHeaderTitle.TabIndex = 3;
            this.lbDetailsHeaderTitle.Text = "Detalles";
            this.lbDetailsHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMoneda
            // 
            this.tbMoneda.Location = new System.Drawing.Point(104, 84);
            this.tbMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.tbMoneda.Name = "tbMoneda";
            this.tbMoneda.ReadOnly = true;
            this.tbMoneda.Size = new System.Drawing.Size(277, 20);
            this.tbMoneda.TabIndex = 25;
            // 
            // tbComplejo
            // 
            this.tbComplejo.Location = new System.Drawing.Point(104, 58);
            this.tbComplejo.Margin = new System.Windows.Forms.Padding(2);
            this.tbComplejo.Name = "tbComplejo";
            this.tbComplejo.ReadOnly = true;
            this.tbComplejo.Size = new System.Drawing.Size(277, 20);
            this.tbComplejo.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(14, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Moneda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(14, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Complejo:";
            // 
            // tbNombreTienda
            // 
            this.tbNombreTienda.Location = new System.Drawing.Point(104, 108);
            this.tbNombreTienda.Margin = new System.Windows.Forms.Padding(2);
            this.tbNombreTienda.Name = "tbNombreTienda";
            this.tbNombreTienda.ReadOnly = true;
            this.tbNombreTienda.Size = new System.Drawing.Size(277, 20);
            this.tbNombreTienda.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(14, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tienda:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lwPlanVenta);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(13, 302);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(368, 424);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plan de venta";
            // 
            // lwPlanVenta
            // 
            this.lwPlanVenta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader6});
            this.lwPlanVenta.GridLines = true;
            this.lwPlanVenta.HideSelection = false;
            this.lwPlanVenta.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem40,
            listViewItem41,
            listViewItem42,
            listViewItem43,
            listViewItem44,
            listViewItem45,
            listViewItem46,
            listViewItem47,
            listViewItem48,
            listViewItem49,
            listViewItem50,
            listViewItem51,
            listViewItem52});
            this.lwPlanVenta.Location = new System.Drawing.Point(4, 15);
            this.lwPlanVenta.Margin = new System.Windows.Forms.Padding(2);
            this.lwPlanVenta.Name = "lwPlanVenta";
            this.lwPlanVenta.Scrollable = false;
            this.lwPlanVenta.Size = new System.Drawing.Size(360, 405);
            this.lwPlanVenta.TabIndex = 1;
            this.lwPlanVenta.UseCompatibleStateImageBehavior = false;
            this.lwPlanVenta.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MES";
            this.columnHeader2.Width = 105;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PLAN DIARIO";
            this.columnHeader4.Width = 117;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PLAN DEL MES";
            this.columnHeader6.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Plan Mes";
            this.columnHeader5.Width = 128;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "% Mes";
            this.columnHeader9.Width = 80;
            // 
            // GestionarTiendaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 764);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GestionarTiendaUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionar tienda";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelBanner.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panelDetails;
        public System.Windows.Forms.ListView lwTiendas;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ListView lwPlanVenta;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.Panel panelBanner;
        public System.Windows.Forms.Label lbDetailsHeaderTitle;
        public System.Windows.Forms.ComboBox cbComplejos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton btnEliminar;
        public System.Windows.Forms.ToolStripButton btnModificar;
        public System.Windows.Forms.ToolStripButton btnAdicionar;
        public System.Windows.Forms.ToolStripSeparator separadorAbrirCerrarTienda;
        public System.Windows.Forms.ToolStripButton btnAbrir;
        public System.Windows.Forms.ToolStripSeparator separadorPlanVentaTienda;
        public System.Windows.Forms.ToolStripButton btnCerrar;
        public System.Windows.Forms.TextBox tbComplejo;
        public System.Windows.Forms.TextBox tbMoneda;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox lbxFormasPago;
        public System.Windows.Forms.TextBox tbNombreTienda;
        public System.Windows.Forms.ToolStripButton btnGestionarPlanVenta;
        public System.Windows.Forms.ToolStripSeparator separadorModificarTienda;
        public System.Windows.Forms.ToolStripSeparator separadorAdicionarTienda;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}