namespace NucleoEV.UI
{
    partial class ParteVentaResumidoUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParteVentaResumidoUI));
            this.lwParteVenta = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lbMonedaDeLaTienda = new System.Windows.Forms.Label();
            this.lbComplejo = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbNotaInformativa = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.cbPonerFechaManual = new System.Windows.Forms.CheckBox();
            this.cbIntroducirDatosEnMonedaByDefault = new System.Windows.Forms.CheckBox();
            this.panelContainerDataGrid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lwParteVenta)).BeginInit();
            this.panelContainerDataGrid.SuspendLayout();
            this.SuspendLayout();
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
            this.lwParteVenta.Location = new System.Drawing.Point(2, 2);
            this.lwParteVenta.Margin = new System.Windows.Forms.Padding(2);
            this.lwParteVenta.Name = "lwParteVenta";
            this.lwParteVenta.RowTemplate.Height = 24;
            this.lwParteVenta.Size = new System.Drawing.Size(755, 577);
            this.lwParteVenta.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(519, 705);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(645, 705);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 34;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lbMonedaDeLaTienda
            // 
            this.lbMonedaDeLaTienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonedaDeLaTienda.Location = new System.Drawing.Point(587, 0);
            this.lbMonedaDeLaTienda.Name = "lbMonedaDeLaTienda";
            this.lbMonedaDeLaTienda.Size = new System.Drawing.Size(178, 111);
            this.lbMonedaDeLaTienda.TabIndex = 39;
            this.lbMonedaDeLaTienda.Text = "123";
            this.lbMonedaDeLaTienda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbComplejo
            // 
            this.lbComplejo.AutoSize = true;
            this.lbComplejo.Location = new System.Drawing.Point(7, 9);
            this.lbComplejo.Name = "lbComplejo";
            this.lbComplejo.Size = new System.Drawing.Size(45, 13);
            this.lbComplejo.TabIndex = 40;
            this.lbComplejo.Text = "Habana";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(7, 37);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(37, 13);
            this.lbFecha.TabIndex = 41;
            this.lbFecha.Text = "Fecha";
            // 
            // lbNotaInformativa
            // 
            this.lbNotaInformativa.Location = new System.Drawing.Point(181, 70);
            this.lbNotaInformativa.Name = "lbNotaInformativa";
            this.lbNotaInformativa.Size = new System.Drawing.Size(400, 32);
            this.lbNotaInformativa.TabIndex = 42;
            this.lbNotaInformativa.Text = "ValorPrueba";
            this.lbNotaInformativa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(64, 32);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(200, 20);
            this.dtFecha.TabIndex = 43;
            // 
            // cbPonerFechaManual
            // 
            this.cbPonerFechaManual.AutoSize = true;
            this.cbPonerFechaManual.Location = new System.Drawing.Point(270, 33);
            this.cbPonerFechaManual.Name = "cbPonerFechaManual";
            this.cbPonerFechaManual.Size = new System.Drawing.Size(121, 17);
            this.cbPonerFechaManual.TabIndex = 44;
            this.cbPonerFechaManual.Text = "Poner fecha manual";
            this.cbPonerFechaManual.UseVisualStyleBackColor = true;
            // 
            // cbIntroducirDatosEnMonedaByDefault
            // 
            this.cbIntroducirDatosEnMonedaByDefault.AutoSize = true;
            this.cbIntroducirDatosEnMonedaByDefault.Location = new System.Drawing.Point(12, 79);
            this.cbIntroducirDatosEnMonedaByDefault.Name = "cbIntroducirDatosEnMonedaByDefault";
            this.cbIntroducirDatosEnMonedaByDefault.Size = new System.Drawing.Size(163, 17);
            this.cbIntroducirDatosEnMonedaByDefault.TabIndex = 45;
            this.cbIntroducirDatosEnMonedaByDefault.Text = "Introducir los valores en MLC";
            this.cbIntroducirDatosEnMonedaByDefault.UseVisualStyleBackColor = true;
            // 
            // panelContainerDataGrid
            // 
            this.panelContainerDataGrid.Controls.Add(this.lwParteVenta);
            this.panelContainerDataGrid.Location = new System.Drawing.Point(12, 114);
            this.panelContainerDataGrid.Name = "panelContainerDataGrid";
            this.panelContainerDataGrid.Size = new System.Drawing.Size(753, 585);
            this.panelContainerDataGrid.TabIndex = 46;
            // 
            // ParteVentaResumidoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 747);
            this.Controls.Add(this.panelContainerDataGrid);
            this.Controls.Add(this.cbIntroducirDatosEnMonedaByDefault);
            this.Controls.Add(this.cbPonerFechaManual);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.lbNotaInformativa);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbComplejo);
            this.Controls.Add(this.lbMonedaDeLaTienda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ParteVentaResumidoUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parte de venta";
            ((System.ComponentModel.ISupportInitialize)(this.lwParteVenta)).EndInit();
            this.panelContainerDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView lwParteVenta;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Label lbMonedaDeLaTienda;
        public System.Windows.Forms.Label lbComplejo;
        public System.Windows.Forms.Label lbFecha;
        public System.Windows.Forms.Label lbNotaInformativa;
        public System.Windows.Forms.CheckBox cbPonerFechaManual;
        public System.Windows.Forms.CheckBox cbIntroducirDatosEnMonedaByDefault;
        public System.Windows.Forms.DateTimePicker dtFecha;
        public System.Windows.Forms.Panel panelContainerDataGrid;
    }
}