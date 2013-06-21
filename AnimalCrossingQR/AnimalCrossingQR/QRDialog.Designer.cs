namespace AnimalCrossingQR
{
    partial class QRDialog
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
            this.qrBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.linkBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrBox)).BeginInit();
            this.SuspendLayout();
            // 
            // qrBox
            // 
            this.qrBox.Location = new System.Drawing.Point(12, 12);
            this.qrBox.Name = "qrBox";
            this.qrBox.Size = new System.Drawing.Size(400, 400);
            this.qrBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.qrBox.TabIndex = 0;
            this.qrBox.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(436, 48);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(213, 33);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save QR Code";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(436, 350);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(213, 33);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(436, 87);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(213, 33);
            this.uploadButton.TabIndex = 3;
            this.uploadButton.Text = "Upload to Imgur";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // linkBox
            // 
            this.linkBox.Location = new System.Drawing.Point(436, 126);
            this.linkBox.Name = "linkBox";
            this.linkBox.ReadOnly = true;
            this.linkBox.Size = new System.Drawing.Size(168, 20);
            this.linkBox.TabIndex = 4;
            this.linkBox.Visible = false;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(610, 122);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(39, 24);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Visible = false;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // QRDialog
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(661, 426);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.linkBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.qrBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QRDialog";
            this.Text = "QR Code";
            this.Load += new System.EventHandler(this.QRDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qrBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox qrBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox linkBox;
        private System.Windows.Forms.Button goButton;
    }
}