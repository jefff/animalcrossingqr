namespace AnimalCrossingQR
{
    partial class MainForm
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
            this.testBox = new System.Windows.Forms.PictureBox();
            this.qrButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.testBox)).BeginInit();
            this.SuspendLayout();
            // 
            // testBox
            // 
            this.testBox.Location = new System.Drawing.Point(12, 12);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(365, 344);
            this.testBox.TabIndex = 0;
            this.testBox.TabStop = false;
            // 
            // qrButton
            // 
            this.qrButton.Location = new System.Drawing.Point(12, 362);
            this.qrButton.Name = "qrButton";
            this.qrButton.Size = new System.Drawing.Size(103, 26);
            this.qrButton.TabIndex = 1;
            this.qrButton.Text = "Load QR";
            this.qrButton.UseVisualStyleBackColor = true;
            this.qrButton.Click += new System.EventHandler(this.qrButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 413);
            this.Controls.Add(this.qrButton);
            this.Controls.Add(this.testBox);
            this.Name = "MainForm";
            this.Text = "Animal Crossing QR";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox testBox;
        private System.Windows.Forms.Button qrButton;
    }
}

