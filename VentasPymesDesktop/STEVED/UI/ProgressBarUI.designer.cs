namespace NucleoEV.UI
{
    partial class ProgressBarUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBarUI));
            this._progressBarCommand = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbEstado = new System.Windows.Forms.Label();
            this.panelReloj1 = new System.Windows.Forms.Panel();
            this.panelCajeroSuperior = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _progressBarCommand
            // 
            this._progressBarCommand.BackColor = System.Drawing.Color.Brown;
            this._progressBarCommand.Location = new System.Drawing.Point(3, 54);
            this._progressBarCommand.Name = "_progressBarCommand";
            this._progressBarCommand.Size = new System.Drawing.Size(269, 17);
            this._progressBarCommand.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._progressBarCommand.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this._progressBarCommand);
            this.panel1.Location = new System.Drawing.Point(11, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 95);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Brown;
            this.panel2.Controls.Add(this.lbEstado);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 31);
            this.panel2.TabIndex = 29;
            // 
            // lbEstado
            // 
            this.lbEstado.BackColor = System.Drawing.Color.Transparent;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbEstado.Location = new System.Drawing.Point(48, 0);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(229, 31);
            this.lbEstado.TabIndex = 0;
            this.lbEstado.Text = "Procesando...";
            // 
            // panelReloj1
            // 
            this.panelReloj1.BackColor = System.Drawing.Color.Brown;
            this.panelReloj1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelReloj1.BackgroundImage")));
            this.panelReloj1.Location = new System.Drawing.Point(11, 13);
            this.panelReloj1.Name = "panelReloj1";
            this.panelReloj1.Size = new System.Drawing.Size(50, 50);
            this.panelReloj1.TabIndex = 31;
            // 
            // panelCajeroSuperior
            // 
            this.panelCajeroSuperior.Location = new System.Drawing.Point(55, 13);
            this.panelCajeroSuperior.Name = "panelCajeroSuperior";
            this.panelCajeroSuperior.Size = new System.Drawing.Size(233, 18);
            this.panelCajeroSuperior.TabIndex = 82;
            // 
            // ProgressBarUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(295, 135);
            this.ControlBox = false;
            this.Controls.Add(this.panelReloj1);
            this.Controls.Add(this.panelCajeroSuperior);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesando...";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar _progressBarCommand;
        public System.Windows.Forms.Label lbEstado;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panelReloj1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panelCajeroSuperior;
    }
}