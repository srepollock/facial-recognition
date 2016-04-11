namespace COMP4932_Assignment3
{
    partial class FaceRecognition
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.findFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bruteForceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.motionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.videoInfo = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.refCamera = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.captureFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.capFacePic = new System.Windows.Forms.PictureBox();
            this.capFaceLabel = new System.Windows.Forms.Label();
            this.fndFaceLabel = new System.Windows.Forms.Label();
            this.fndFacePic = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capFacePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fndFacePic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.findFaceToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1033, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.motionToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.differenceToolStripMenuItem,
            this.toolStripMenuItem1,
            this.captureFaceToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.Enabled = false;
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.motionToolStripMenuItem.Text = "Motion";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem,
            this.gIFToolStripMenuItem1});
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            // 
            // jPEGToolStripMenuItem
            // 
            this.jPEGToolStripMenuItem.Enabled = false;
            this.jPEGToolStripMenuItem.Name = "jPEGToolStripMenuItem";
            this.jPEGToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.jPEGToolStripMenuItem.Text = "JPEG";
            this.jPEGToolStripMenuItem.Click += new System.EventHandler(this.jPEGToolStripMenuItem_Click);
            // 
            // gIFToolStripMenuItem1
            // 
            this.gIFToolStripMenuItem1.Enabled = false;
            this.gIFToolStripMenuItem1.Name = "gIFToolStripMenuItem1";
            this.gIFToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem1.Text = "GIF";
            this.gIFToolStripMenuItem1.Click += new System.EventHandler(this.gIFToolStripMenuItem1_Click);
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem1,
            this.gIFToolStripMenuItem2});
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.differenceToolStripMenuItem_Click);
            // 
            // jPEGToolStripMenuItem1
            // 
            this.jPEGToolStripMenuItem1.Enabled = false;
            this.jPEGToolStripMenuItem1.Name = "jPEGToolStripMenuItem1";
            this.jPEGToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.jPEGToolStripMenuItem1.Text = "JPEG";
            this.jPEGToolStripMenuItem1.Click += new System.EventHandler(this.jPEGToolStripMenuItem1_Click);
            // 
            // gIFToolStripMenuItem2
            // 
            this.gIFToolStripMenuItem2.Enabled = false;
            this.gIFToolStripMenuItem2.Name = "gIFToolStripMenuItem2";
            this.gIFToolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem2.Text = "GIF";
            this.gIFToolStripMenuItem2.Click += new System.EventHandler(this.gIFToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // findFaceToolStripMenuItem
            // 
            this.findFaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bruteForceToolStripMenuItem,
            this.optimizedToolStripMenuItem,
            this.motionToolStripMenuItem1});
            this.findFaceToolStripMenuItem.Enabled = false;
            this.findFaceToolStripMenuItem.Name = "findFaceToolStripMenuItem";
            this.findFaceToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.findFaceToolStripMenuItem.Text = "Find Face";
            // 
            // bruteForceToolStripMenuItem
            // 
            this.bruteForceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem2,
            this.gIFToolStripMenuItem});
            this.bruteForceToolStripMenuItem.Name = "bruteForceToolStripMenuItem";
            this.bruteForceToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.bruteForceToolStripMenuItem.Text = "Brute Force";
            // 
            // jPEGToolStripMenuItem2
            // 
            this.jPEGToolStripMenuItem2.Name = "jPEGToolStripMenuItem2";
            this.jPEGToolStripMenuItem2.Size = new System.Drawing.Size(99, 22);
            this.jPEGToolStripMenuItem2.Text = "JPEG";
            // 
            // gIFToolStripMenuItem
            // 
            this.gIFToolStripMenuItem.Name = "gIFToolStripMenuItem";
            this.gIFToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem.Text = "GIF";
            // 
            // optimizedToolStripMenuItem
            // 
            this.optimizedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem3,
            this.gIFToolStripMenuItem3});
            this.optimizedToolStripMenuItem.Name = "optimizedToolStripMenuItem";
            this.optimizedToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.optimizedToolStripMenuItem.Text = "Optimized";
            // 
            // jPEGToolStripMenuItem3
            // 
            this.jPEGToolStripMenuItem3.Name = "jPEGToolStripMenuItem3";
            this.jPEGToolStripMenuItem3.Size = new System.Drawing.Size(99, 22);
            this.jPEGToolStripMenuItem3.Text = "JPEG";
            // 
            // gIFToolStripMenuItem3
            // 
            this.gIFToolStripMenuItem3.Name = "gIFToolStripMenuItem3";
            this.gIFToolStripMenuItem3.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem3.Text = "GIF";
            // 
            // motionToolStripMenuItem1
            // 
            this.motionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem4,
            this.gIFToolStripMenuItem4});
            this.motionToolStripMenuItem1.Name = "motionToolStripMenuItem1";
            this.motionToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.motionToolStripMenuItem1.Text = "Motion";
            // 
            // jPEGToolStripMenuItem4
            // 
            this.jPEGToolStripMenuItem4.Name = "jPEGToolStripMenuItem4";
            this.jPEGToolStripMenuItem4.Size = new System.Drawing.Size(99, 22);
            this.jPEGToolStripMenuItem4.Text = "JPEG";
            // 
            // gIFToolStripMenuItem4
            // 
            this.gIFToolStripMenuItem4.Name = "gIFToolStripMenuItem4";
            this.gIFToolStripMenuItem4.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem4.Text = "GIF";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gitHubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.23476F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.56825F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.2333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1033, 593);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.videoInfo);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.refCamera);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 587);
            this.panel1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(2, 72);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // videoInfo
            // 
            this.videoInfo.AutoSize = true;
            this.videoInfo.Location = new System.Drawing.Point(2, 124);
            this.videoInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.videoInfo.Name = "videoInfo";
            this.videoInfo.Size = new System.Drawing.Size(62, 13);
            this.videoInfo.TabIndex = 3;
            this.videoInfo.Text = "Device Info";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(2, 97);
            this.start.Margin = new System.Windows.Forms.Padding(2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(142, 25);
            this.start.TabIndex = 2;
            this.start.Text = "&Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.ldCamera_Click);
            // 
            // refCamera
            // 
            this.refCamera.Location = new System.Drawing.Point(2, 41);
            this.refCamera.Margin = new System.Windows.Forms.Padding(2);
            this.refCamera.Name = "refCamera";
            this.refCamera.Size = new System.Drawing.Size(142, 27);
            this.refCamera.TabIndex = 1;
            this.refCamera.Text = "Refresh Camera";
            this.refCamera.UseVisualStyleBackColor = true;
            this.refCamera.Click += new System.EventHandler(this.refCamera_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(2, 16);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(160, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 587);
            this.tabControl1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.pictureBox1);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(621, 561);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Image 1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 555);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.pictureBox2);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(604, 458);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Image 2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(598, 452);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.pictureBox3);
            this.tab3.Location = new System.Drawing.Point(4, 22);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(604, 458);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Image Differences";
            this.tab3.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(604, 458);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // captureFaceToolStripMenuItem
            // 
            this.captureFaceToolStripMenuItem.Enabled = false;
            this.captureFaceToolStripMenuItem.Name = "captureFaceToolStripMenuItem";
            this.captureFaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.captureFaceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.captureFaceToolStripMenuItem.Text = "Capture Face";
            this.captureFaceToolStripMenuItem.Click += new System.EventHandler(this.captureFaceToolStripMenuItem_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fndFacePic);
            this.panel2.Controls.Add(this.fndFaceLabel);
            this.panel2.Controls.Add(this.capFaceLabel);
            this.panel2.Controls.Add(this.capFacePic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(795, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 587);
            this.panel2.TabIndex = 2;
            // 
            // capFacePic
            // 
            this.capFacePic.Location = new System.Drawing.Point(34, 41);
            this.capFacePic.Name = "capFacePic";
            this.capFacePic.Size = new System.Drawing.Size(178, 115);
            this.capFacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.capFacePic.TabIndex = 0;
            this.capFacePic.TabStop = false;
            // 
            // capFaceLabel
            // 
            this.capFaceLabel.AutoSize = true;
            this.capFaceLabel.Location = new System.Drawing.Point(31, 24);
            this.capFaceLabel.Name = "capFaceLabel";
            this.capFaceLabel.Size = new System.Drawing.Size(77, 13);
            this.capFaceLabel.TabIndex = 1;
            this.capFaceLabel.Text = "Captured Face";
            // 
            // fndFaceLabel
            // 
            this.fndFaceLabel.AutoSize = true;
            this.fndFaceLabel.Location = new System.Drawing.Point(34, 163);
            this.fndFaceLabel.Name = "fndFaceLabel";
            this.fndFaceLabel.Size = new System.Drawing.Size(64, 13);
            this.fndFaceLabel.TabIndex = 2;
            this.fndFaceLabel.Text = "Found Face";
            // 
            // fndFacePic
            // 
            this.fndFacePic.Location = new System.Drawing.Point(34, 179);
            this.fndFacePic.Name = "fndFacePic";
            this.fndFacePic.Size = new System.Drawing.Size(178, 115);
            this.fndFacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fndFacePic.TabIndex = 3;
            this.fndFacePic.TabStop = false;
            // 
            // FaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FaceRecognition";
            this.Text = "Facial Recognition - Spencer Pollock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tab2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tab3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capFacePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fndFacePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findFaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bruteForceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optimizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button refCamera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label videoInfo;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStripMenuItem captureFaceToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label fndFaceLabel;
        private System.Windows.Forms.Label capFaceLabel;
        private System.Windows.Forms.PictureBox capFacePic;
        private System.Windows.Forms.PictureBox fndFacePic;
    }
}

