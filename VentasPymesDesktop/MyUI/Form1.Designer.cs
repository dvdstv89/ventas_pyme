namespace MyUI
{
    partial class Form1
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
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.iconButtonProgressBar = new FontAwesome.Sharp.IconButton();
            this.iconButtonMensajeError = new FontAwesome.Sharp.IconButton();
            this.iconButtonSucess = new FontAwesome.Sharp.IconButton();
            this.iconButtonException = new FontAwesome.Sharp.IconButton();
            this.iconButtonConfirmation = new FontAwesome.Sharp.IconButton();
            this.iconButtonProgressBarStop = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Panorama;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 224;
            this.iconPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(365, 224);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.BackColor = System.Drawing.Color.Brown;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.Black;
            this.labelVersion.Location = new System.Drawing.Point(0, 194);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(365, 30);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Ver-1";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.OrangeRed;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(365, 30);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "User Interface Module";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButtonProgressBar
            // 
            this.iconButtonProgressBar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButtonProgressBar.IconColor = System.Drawing.Color.Black;
            this.iconButtonProgressBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonProgressBar.Location = new System.Drawing.Point(278, 42);
            this.iconButtonProgressBar.Name = "iconButtonProgressBar";
            this.iconButtonProgressBar.Size = new System.Drawing.Size(75, 52);
            this.iconButtonProgressBar.TabIndex = 8;
            this.iconButtonProgressBar.Text = "ProgressBar Start";
            this.iconButtonProgressBar.UseVisualStyleBackColor = true;
            this.iconButtonProgressBar.Click += new System.EventHandler(this.iconButtonProgressBar_Click);
            // 
            // iconButtonMensajeError
            // 
            this.iconButtonMensajeError.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButtonMensajeError.IconColor = System.Drawing.Color.Black;
            this.iconButtonMensajeError.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonMensajeError.Location = new System.Drawing.Point(13, 42);
            this.iconButtonMensajeError.Name = "iconButtonMensajeError";
            this.iconButtonMensajeError.Size = new System.Drawing.Size(75, 23);
            this.iconButtonMensajeError.TabIndex = 9;
            this.iconButtonMensajeError.Text = "Error";
            this.iconButtonMensajeError.UseVisualStyleBackColor = true;
            this.iconButtonMensajeError.Click += new System.EventHandler(this.iconButtonMensajeError_Click);
            // 
            // iconButtonSucess
            // 
            this.iconButtonSucess.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButtonSucess.IconColor = System.Drawing.Color.Black;
            this.iconButtonSucess.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonSucess.Location = new System.Drawing.Point(13, 71);
            this.iconButtonSucess.Name = "iconButtonSucess";
            this.iconButtonSucess.Size = new System.Drawing.Size(75, 23);
            this.iconButtonSucess.TabIndex = 10;
            this.iconButtonSucess.Text = "Sucess";
            this.iconButtonSucess.UseVisualStyleBackColor = true;
            this.iconButtonSucess.Click += new System.EventHandler(this.iconButtonSucess_Click);
            // 
            // iconButtonException
            // 
            this.iconButtonException.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButtonException.IconColor = System.Drawing.Color.Black;
            this.iconButtonException.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonException.Location = new System.Drawing.Point(12, 100);
            this.iconButtonException.Name = "iconButtonException";
            this.iconButtonException.Size = new System.Drawing.Size(75, 23);
            this.iconButtonException.TabIndex = 11;
            this.iconButtonException.Text = "Exception";
            this.iconButtonException.UseVisualStyleBackColor = true;
            this.iconButtonException.Click += new System.EventHandler(this.iconButtonException_Click);
            // 
            // iconButtonConfirmation
            // 
            this.iconButtonConfirmation.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButtonConfirmation.IconColor = System.Drawing.Color.Black;
            this.iconButtonConfirmation.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonConfirmation.Location = new System.Drawing.Point(12, 129);
            this.iconButtonConfirmation.Name = "iconButtonConfirmation";
            this.iconButtonConfirmation.Size = new System.Drawing.Size(75, 23);
            this.iconButtonConfirmation.TabIndex = 12;
            this.iconButtonConfirmation.Text = "Confirmation";
            this.iconButtonConfirmation.UseVisualStyleBackColor = true;
            this.iconButtonConfirmation.Click += new System.EventHandler(this.iconButtonConfirmation_Click);
            // 
            // iconButtonProgressBarStop
            // 
            this.iconButtonProgressBarStop.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButtonProgressBarStop.IconColor = System.Drawing.Color.Black;
            this.iconButtonProgressBarStop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonProgressBarStop.Location = new System.Drawing.Point(278, 100);
            this.iconButtonProgressBarStop.Name = "iconButtonProgressBarStop";
            this.iconButtonProgressBarStop.Size = new System.Drawing.Size(75, 52);
            this.iconButtonProgressBarStop.TabIndex = 13;
            this.iconButtonProgressBarStop.Text = "ProgressBar Stop";
            this.iconButtonProgressBarStop.UseVisualStyleBackColor = true;
            this.iconButtonProgressBarStop.Click += new System.EventHandler(this.iconButtonProgressBarStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 224);
            this.Controls.Add(this.iconButtonProgressBarStop);
            this.Controls.Add(this.iconButtonConfirmation);
            this.Controls.Add(this.iconButtonException);
            this.Controls.Add(this.iconButtonSucess);
            this.Controls.Add(this.iconButtonMensajeError);
            this.Controls.Add(this.iconButtonProgressBar);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.iconPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Interface Module";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        public System.Windows.Forms.Label labelVersion;
        public System.Windows.Forms.Label labelTitle;
        private FontAwesome.Sharp.IconButton iconButtonProgressBar;
        private FontAwesome.Sharp.IconButton iconButtonMensajeError;
        private FontAwesome.Sharp.IconButton iconButtonSucess;
        private FontAwesome.Sharp.IconButton iconButtonException;
        private FontAwesome.Sharp.IconButton iconButtonConfirmation;
        private FontAwesome.Sharp.IconButton iconButtonProgressBarStop;
    }
}

