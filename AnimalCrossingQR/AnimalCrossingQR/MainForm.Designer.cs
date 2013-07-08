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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromImageURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromQRCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromQRCodeURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editColorsButton = new System.Windows.Forms.Button();
            this.titleText = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.authorNameText = new System.Windows.Forms.TextBox();
            this.authorTownLabel = new System.Windows.Forms.Label();
            this.authorTownText = new System.Windows.Forms.TextBox();
            this.authorUniqueIDLabel = new System.Windows.Forms.Label();
            this.authorUniqueIDText = new System.Windows.Forms.MaskedTextBox();
            this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.setDefaultButton = new System.Windows.Forms.Button();
            this.loadDefaultButton = new System.Windows.Forms.Button();
            this.createQRButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.authorGroup = new System.Windows.Forms.GroupBox();
            this.helpBox = new System.Windows.Forms.PictureBox();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.patternEditor = new AnimalCrossingQR.PatternEditor();
            this.paletteControl = new AnimalCrossingQR.PaletteControl();
            this.menuStrip.SuspendLayout();
            this.authorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(620, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPatternToolStripMenuItem,
            this.openPatternToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newPatternToolStripMenuItem
            // 
            this.newPatternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankToolStripMenuItem,
            this.fromImageToolStripMenuItem,
            this.fromImageURLToolStripMenuItem});
            this.newPatternToolStripMenuItem.Name = "newPatternToolStripMenuItem";
            this.newPatternToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.newPatternToolStripMenuItem.Text = "New Pattern";
            // 
            // blankToolStripMenuItem
            // 
            this.blankToolStripMenuItem.Name = "blankToolStripMenuItem";
            this.blankToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.blankToolStripMenuItem.Text = "Blank";
            this.blankToolStripMenuItem.Visible = false;
            this.blankToolStripMenuItem.Click += new System.EventHandler(this.blankToolStripMenuItem_Click);
            // 
            // fromImageToolStripMenuItem
            // 
            this.fromImageToolStripMenuItem.Name = "fromImageToolStripMenuItem";
            this.fromImageToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fromImageToolStripMenuItem.Text = "From Image...";
            this.fromImageToolStripMenuItem.Click += new System.EventHandler(this.fromImageToolStripMenuItem_Click);
            // 
            // fromImageURLToolStripMenuItem
            // 
            this.fromImageURLToolStripMenuItem.Name = "fromImageURLToolStripMenuItem";
            this.fromImageURLToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fromImageURLToolStripMenuItem.Text = "From Image URL...";
            this.fromImageURLToolStripMenuItem.Click += new System.EventHandler(this.fromImageURLToolStripMenuItem_Click);
            // 
            // openPatternToolStripMenuItem
            // 
            this.openPatternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromQRCodeToolStripMenuItem,
            this.fromQRCodeURLToolStripMenuItem});
            this.openPatternToolStripMenuItem.Name = "openPatternToolStripMenuItem";
            this.openPatternToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openPatternToolStripMenuItem.Text = "Open Pattern";
            // 
            // fromQRCodeToolStripMenuItem
            // 
            this.fromQRCodeToolStripMenuItem.Name = "fromQRCodeToolStripMenuItem";
            this.fromQRCodeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.fromQRCodeToolStripMenuItem.Text = "From QR Code...";
            this.fromQRCodeToolStripMenuItem.Click += new System.EventHandler(this.fromQRCodeToolStripMenuItem_Click);
            // 
            // fromQRCodeURLToolStripMenuItem
            // 
            this.fromQRCodeURLToolStripMenuItem.Name = "fromQRCodeURLToolStripMenuItem";
            this.fromQRCodeURLToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.fromQRCodeURLToolStripMenuItem.Text = "From QR Code URL...";
            this.fromQRCodeURLToolStripMenuItem.Click += new System.EventHandler(this.fromQRCodeURLToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editColorsButton
            // 
            this.editColorsButton.Location = new System.Drawing.Point(17, 341);
            this.editColorsButton.Name = "editColorsButton";
            this.editColorsButton.Size = new System.Drawing.Size(60, 29);
            this.editColorsButton.TabIndex = 3;
            this.editColorsButton.Text = "Edit";
            this.editColorsButton.UseVisualStyleBackColor = true;
            this.editColorsButton.Click += new System.EventHandler(this.editColorsButton_Click);
            // 
            // titleText
            // 
            this.titleText.Location = new System.Drawing.Point(404, 51);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(197, 20);
            this.titleText.TabIndex = 4;
            this.titleText.Text = "Untitled";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(401, 35);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Title";
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Location = new System.Drawing.Point(6, 16);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(35, 13);
            this.authorNameLabel.TabIndex = 7;
            this.authorNameLabel.Text = "Name";
            // 
            // authorNameText
            // 
            this.authorNameText.Location = new System.Drawing.Point(9, 32);
            this.authorNameText.Name = "authorNameText";
            this.authorNameText.Size = new System.Drawing.Size(197, 20);
            this.authorNameText.TabIndex = 6;
            // 
            // authorTownLabel
            // 
            this.authorTownLabel.AutoSize = true;
            this.authorTownLabel.Location = new System.Drawing.Point(6, 55);
            this.authorTownLabel.Name = "authorTownLabel";
            this.authorTownLabel.Size = new System.Drawing.Size(34, 13);
            this.authorTownLabel.TabIndex = 9;
            this.authorTownLabel.Text = "Town";
            // 
            // authorTownText
            // 
            this.authorTownText.Location = new System.Drawing.Point(9, 71);
            this.authorTownText.Name = "authorTownText";
            this.authorTownText.Size = new System.Drawing.Size(197, 20);
            this.authorTownText.TabIndex = 8;
            // 
            // authorUniqueIDLabel
            // 
            this.authorUniqueIDLabel.AutoSize = true;
            this.authorUniqueIDLabel.Location = new System.Drawing.Point(6, 94);
            this.authorUniqueIDLabel.Name = "authorUniqueIDLabel";
            this.authorUniqueIDLabel.Size = new System.Drawing.Size(55, 13);
            this.authorUniqueIDLabel.TabIndex = 11;
            this.authorUniqueIDLabel.Text = "Unique ID";
            // 
            // authorUniqueIDText
            // 
            this.authorUniqueIDText.Location = new System.Drawing.Point(9, 110);
            this.authorUniqueIDText.Mask = ">AA:AA:AA:AA:AA:AA:AA:AA:AA:AA:AA:AA:AA:AA";
            this.authorUniqueIDText.Name = "authorUniqueIDText";
            this.authorUniqueIDText.PromptChar = ' ';
            this.authorUniqueIDText.Size = new System.Drawing.Size(171, 20);
            this.authorUniqueIDText.TabIndex = 12;
            this.authorUniqueIDText.TextChanged += new System.EventHandler(this.authorUniqueIDText_TextChanged);
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*" +
    ".*";
            // 
            // setDefaultButton
            // 
            this.setDefaultButton.Location = new System.Drawing.Point(16, 136);
            this.setDefaultButton.Name = "setDefaultButton";
            this.setDefaultButton.Size = new System.Drawing.Size(89, 29);
            this.setDefaultButton.TabIndex = 13;
            this.setDefaultButton.Text = "Set as default";
            this.setDefaultButton.UseVisualStyleBackColor = true;
            this.setDefaultButton.Click += new System.EventHandler(this.setDefaultButton_Click);
            // 
            // loadDefaultButton
            // 
            this.loadDefaultButton.Location = new System.Drawing.Point(111, 136);
            this.loadDefaultButton.Name = "loadDefaultButton";
            this.loadDefaultButton.Size = new System.Drawing.Size(87, 29);
            this.loadDefaultButton.TabIndex = 14;
            this.loadDefaultButton.Text = "Load default";
            this.loadDefaultButton.UseVisualStyleBackColor = true;
            this.loadDefaultButton.Click += new System.EventHandler(this.loadDefaultButton_Click);
            // 
            // createQRButton
            // 
            this.createQRButton.Location = new System.Drawing.Point(447, 297);
            this.createQRButton.Name = "createQRButton";
            this.createQRButton.Size = new System.Drawing.Size(116, 29);
            this.createQRButton.TabIndex = 16;
            this.createQRButton.Text = "Create QR Code";
            this.createQRButton.UseVisualStyleBackColor = true;
            this.createQRButton.Click += new System.EventHandler(this.createQRButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 40);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // authorGroup
            // 
            this.authorGroup.Controls.Add(this.authorNameLabel);
            this.authorGroup.Controls.Add(this.authorNameText);
            this.authorGroup.Controls.Add(this.authorTownText);
            this.authorGroup.Controls.Add(this.helpBox);
            this.authorGroup.Controls.Add(this.authorTownLabel);
            this.authorGroup.Controls.Add(this.loadDefaultButton);
            this.authorGroup.Controls.Add(this.authorUniqueIDLabel);
            this.authorGroup.Controls.Add(this.setDefaultButton);
            this.authorGroup.Controls.Add(this.authorUniqueIDText);
            this.authorGroup.Location = new System.Drawing.Point(395, 88);
            this.authorGroup.Name = "authorGroup";
            this.authorGroup.Size = new System.Drawing.Size(217, 182);
            this.authorGroup.TabIndex = 18;
            this.authorGroup.TabStop = false;
            this.authorGroup.Text = "Author";
            this.authorGroup.UseCompatibleTextRendering = true;
            // 
            // helpBox
            // 
            this.helpBox.Image = ((System.Drawing.Image)(resources.GetObject("helpBox.Image")));
            this.helpBox.Location = new System.Drawing.Point(186, 110);
            this.helpBox.Name = "helpBox";
            this.helpBox.Size = new System.Drawing.Size(20, 20);
            this.helpBox.TabIndex = 15;
            this.helpBox.TabStop = false;
            this.helpBox.Click += new System.EventHandler(this.helpBox_Click);
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.AutoSize = true;
            this.gridCheckBox.Location = new System.Drawing.Point(115, 348);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(75, 17);
            this.gridCheckBox.TabIndex = 20;
            this.gridCheckBox.Text = "Show Grid";
            this.gridCheckBox.UseVisualStyleBackColor = true;
            this.gridCheckBox.CheckedChanged += new System.EventHandler(this.gridCheckBox_CheckedChanged);
            // 
            // patternEditor
            // 
            this.patternEditor.DrawingEnabled = true;
            this.patternEditor.LeftColor = ((byte)(0));
            this.patternEditor.Location = new System.Drawing.Point(95, 35);
            this.patternEditor.Name = "patternEditor";
            this.patternEditor.RightColor = ((byte)(0));
            this.patternEditor.ShowGrid = false;
            this.patternEditor.Size = new System.Drawing.Size(294, 300);
            this.patternEditor.TabIndex = 19;
            // 
            // paletteControl
            // 
            this.paletteControl.Location = new System.Drawing.Point(12, 27);
            this.paletteControl.Name = "paletteControl";
            this.paletteControl.SecondarySelectedIndex = 0;
            this.paletteControl.SelectedIndex = 0;
            this.paletteControl.SelectedItem = 31;
            this.paletteControl.Selection = AnimalCrossingQR.PaletteControl.SelectionType.DoubleSelect;
            this.paletteControl.Size = new System.Drawing.Size(77, 308);
            this.paletteControl.TabIndex = 2;
            this.paletteControl.SelectedIndexChanged += new System.EventHandler(this.paletteControl_SelectedIndexChanged);
            this.paletteControl.SecondarySelectedIndexChanged += new System.EventHandler(this.paletteControl_SecondarySelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 383);
            this.Controls.Add(this.gridCheckBox);
            this.Controls.Add(this.patternEditor);
            this.Controls.Add(this.authorGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createQRButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.editColorsButton);
            this.Controls.Add(this.paletteControl);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Uber Animal Crossing QR Tool v0.3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.authorGroup.ResumeLayout(false);
            this.authorGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPatternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPatternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromQRCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private PaletteControl paletteControl;
        private System.Windows.Forms.Button editColorsButton;
        private System.Windows.Forms.TextBox titleText;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorNameLabel;
        private System.Windows.Forms.TextBox authorNameText;
        private System.Windows.Forms.Label authorTownLabel;
        private System.Windows.Forms.TextBox authorTownText;
        private System.Windows.Forms.Label authorUniqueIDLabel;
        private System.Windows.Forms.MaskedTextBox authorUniqueIDText;
        private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
        private System.Windows.Forms.Button setDefaultButton;
        private System.Windows.Forms.Button loadDefaultButton;
        private System.Windows.Forms.PictureBox helpBox;
        private System.Windows.Forms.Button createQRButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox authorGroup;
        private System.Windows.Forms.ToolStripMenuItem fromQRCodeURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromImageURLToolStripMenuItem;
        private PatternEditor patternEditor;
        private System.Windows.Forms.CheckBox gridCheckBox;

    }
}

