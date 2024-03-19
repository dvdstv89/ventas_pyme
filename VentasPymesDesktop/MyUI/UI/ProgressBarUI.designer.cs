namespace MyUI.UI
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
            this._progressBarCommand = new System.Windows.Forms.ProgressBar();
            this.lbEstado = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _progressBarCommand
            // 
            this._progressBarCommand.BackColor = System.Drawing.Color.Brown;
            this._progressBarCommand.Location = new System.Drawing.Point(14, 91);
            this._progressBarCommand.Name = "_progressBarCommand";
            this._progressBarCommand.Size = new System.Drawing.Size(269, 17);
            this._progressBarCommand.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._progressBarCommand.TabIndex = 1;
            // 
            // lbEstado
            // 
            this.lbEstado.BackColor = System.Drawing.Color.Transparent;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbEstado.Location = new System.Drawing.Point(69, 22);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(214, 50);
            this.lbEstado.TabIndex = 0;
            this.lbEstado.Text = "Procesando...";
            this.lbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 49;
            this.iconPictureBox1.Location = new System.Drawing.Point(14, 22);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(49, 50);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // ProgressBarUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(295, 135);
            this.ControlBox = false;
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this._progressBarCommand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesando...";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar _progressBarCommand;
        public System.Windows.Forms.Label lbEstado;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}