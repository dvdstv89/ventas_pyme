namespace NucleoEV.UI
{
    partial class DetallesVentaUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetallesVentaUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTienda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbComplejo = new System.Windows.Forms.TextBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lwParteVenta = new System.Windows.Forms.DataGridView();
            this.tbMonedaDeLaTienda = new System.Windows.Forms.TextBox();
            this.panelContainerDataGrid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lwParteVenta)).BeginInit();
            this.panelContainerDataGrid.SuspendLayout();
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
            this.tbTienda.Size = new System.Drawing.Size(422, 20);
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
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(375, 543);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tbComplejo
            // 
            this.tbComplejo.Location = new System.Drawing.Point(73, 35);
            this.tbComplejo.Margin = new System.Windows.Forms.Padding(2);
            this.tbComplejo.Name = "tbComplejo";
            this.tbComplejo.Size = new System.Drawing.Size(422, 20);
            this.tbComplejo.TabIndex = 35;
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(73, 90);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(422, 20);
            this.dtFecha.TabIndex = 45;
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(8, 96);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(40, 13);
            this.lbFecha.TabIndex = 44;
            this.lbFecha.Text = "Fecha:";
            // 
            // lwParteVenta
            // 
            this.lwParteVenta.AllowUserToAddRows = false;
            this.lwParteVenta.AllowUserToDeleteRows = false;
            this.lwParteVenta.AllowUserToResizeColumns = false;
            this.lwParteVenta.AllowUserToResizeRows = false;
            this.lwParteVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.lwParteVenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lwParteVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lwParteVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lwParteVenta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lwParteVenta.Location = new System.Drawing.Point(0, 0);
            this.lwParteVenta.Margin = new System.Windows.Forms.Padding(2);
            this.lwParteVenta.Name = "lwParteVenta";
            this.lwParteVenta.RowTemplate.Height = 24;
            this.lwParteVenta.Size = new System.Drawing.Size(483, 374);
            this.lwParteVenta.TabIndex = 46;
            // 
            // tbMonedaDeLaTienda
            // 
            this.tbMonedaDeLaTienda.Location = new System.Drawing.Point(73, 63);
            this.tbMonedaDeLaTienda.Margin = new System.Windows.Forms.Padding(2);
            this.tbMonedaDeLaTienda.Name = "tbMonedaDeLaTienda";
            this.tbMonedaDeLaTienda.Size = new System.Drawing.Size(422, 20);
            this.tbMonedaDeLaTienda.TabIndex = 47;
            // 
            // panelContainerDataGrid
            // 
            this.panelContainerDataGrid.Controls.Add(this.lwParteVenta);
            this.panelContainerDataGrid.Location = new System.Drawing.Point(10, 123);
            this.panelContainerDataGrid.Name = "panelContainerDataGrid";
            this.panelContainerDataGrid.Size = new System.Drawing.Size(485, 376);
            this.panelContainerDataGrid.TabIndex = 48;
            // 
            // DetallesVentaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(514, 585);
            this.Controls.Add(this.panelContainerDataGrid);
            this.Controls.Add(this.tbMonedaDeLaTienda);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.tbComplejo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTienda);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "DetallesVentaUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalles de la venta";
            ((System.ComponentModel.ISupportInitialize)(this.lwParteVenta)).EndInit();
            this.panelContainerDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox tbTienda;
        public System.Windows.Forms.TextBox tbComplejo;
        public System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Label lbFecha;
        public System.Windows.Forms.DataGridView lwParteVenta;
        public System.Windows.Forms.TextBox tbMonedaDeLaTienda;
        public System.Windows.Forms.Panel panelContainerDataGrid;
    }
}