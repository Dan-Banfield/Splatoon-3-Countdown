
namespace Splatoon_3_Countdown
{
    partial class CountdownForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountdownForm));
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.countdownLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPictureBox.Image = global::Splatoon_3_Countdown.Properties.Resources.LoadingBackground;
            this.backgroundPictureBox.Location = new System.Drawing.Point(0, 0);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(707, 366);
            this.backgroundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backgroundPictureBox.TabIndex = 0;
            this.backgroundPictureBox.TabStop = false;
            // 
            // countdownLabel
            // 
            this.countdownLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countdownLabel.BackColor = System.Drawing.Color.Transparent;
            this.countdownLabel.Font = new System.Drawing.Font("Splatfont 2", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdownLabel.ForeColor = System.Drawing.Color.White;
            this.countdownLabel.Location = new System.Drawing.Point(0, 369);
            this.countdownLabel.Name = "countdownLabel";
            this.countdownLabel.Size = new System.Drawing.Size(707, 61);
            this.countdownLabel.TabIndex = 2;
            this.countdownLabel.Text = "0 Days 0 Hours 0 Minutes 0 Seconds";
            this.countdownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CountdownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(707, 429);
            this.Controls.Add(this.countdownLabel);
            this.Controls.Add(this.backgroundPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountdownForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splatoon 3 - Countdown";
            this.Load += new System.EventHandler(this.CountdownForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.Label countdownLabel;
    }
}

