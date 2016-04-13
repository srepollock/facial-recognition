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
            this.captureFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.fndFacePic = new System.Windows.Forms.PictureBox();
            this.fndFaceLabel = new System.Windows.Forms.Label();
            this.capFaceLabel = new System.Windows.Forms.Label();
            this.capFacePic = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_distance = new System.Windows.Forms.Label();
            this.findFaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_faceSpace = new System.Windows.Forms.Label();
            this.lb_person = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.fndFacePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capFacePic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(2066, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(260, 38);
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
            this.captureFaceToolStripMenuItem,
            this.findFaceToolStripMenuItem1});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.Enabled = false;
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.motionToolStripMenuItem.Text = "Motion";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem,
            this.gIFToolStripMenuItem1});
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            // 
            // jPEGToolStripMenuItem
            // 
            this.jPEGToolStripMenuItem.Enabled = false;
            this.jPEGToolStripMenuItem.Name = "jPEGToolStripMenuItem";
            this.jPEGToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.jPEGToolStripMenuItem.Text = "JPEG";
            this.jPEGToolStripMenuItem.Click += new System.EventHandler(this.jPEGToolStripMenuItem_Click);
            // 
            // gIFToolStripMenuItem1
            // 
            this.gIFToolStripMenuItem1.Enabled = false;
            this.gIFToolStripMenuItem1.Name = "gIFToolStripMenuItem1";
            this.gIFToolStripMenuItem1.Size = new System.Drawing.Size(165, 38);
            this.gIFToolStripMenuItem1.Text = "GIF";
            this.gIFToolStripMenuItem1.Click += new System.EventHandler(this.gIFToolStripMenuItem1_Click);
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem1,
            this.gIFToolStripMenuItem2});
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.differenceToolStripMenuItem_Click);
            // 
            // jPEGToolStripMenuItem1
            // 
            this.jPEGToolStripMenuItem1.Enabled = false;
            this.jPEGToolStripMenuItem1.Name = "jPEGToolStripMenuItem1";
            this.jPEGToolStripMenuItem1.Size = new System.Drawing.Size(165, 38);
            this.jPEGToolStripMenuItem1.Text = "JPEG";
            this.jPEGToolStripMenuItem1.Click += new System.EventHandler(this.jPEGToolStripMenuItem1_Click);
            // 
            // gIFToolStripMenuItem2
            // 
            this.gIFToolStripMenuItem2.Enabled = false;
            this.gIFToolStripMenuItem2.Name = "gIFToolStripMenuItem2";
            this.gIFToolStripMenuItem2.Size = new System.Drawing.Size(165, 38);
            this.gIFToolStripMenuItem2.Text = "GIF";
            this.gIFToolStripMenuItem2.Click += new System.EventHandler(this.gIFToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(398, 6);
            // 
            // captureFaceToolStripMenuItem
            // 
            this.captureFaceToolStripMenuItem.Enabled = false;
            this.captureFaceToolStripMenuItem.Name = "captureFaceToolStripMenuItem";
            this.captureFaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.captureFaceToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.captureFaceToolStripMenuItem.Text = "Capture Face";
            this.captureFaceToolStripMenuItem.Click += new System.EventHandler(this.captureFaceToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gitHubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2066, 1143);
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
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 1131);
            this.panel1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(4, 138);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(280, 33);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // videoInfo
            // 
            this.videoInfo.AutoSize = true;
            this.videoInfo.Location = new System.Drawing.Point(4, 238);
            this.videoInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.videoInfo.Name = "videoInfo";
            this.videoInfo.Size = new System.Drawing.Size(119, 25);
            this.videoInfo.TabIndex = 3;
            this.videoInfo.Text = "Device Info";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(4, 187);
            this.start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(284, 48);
            this.start.TabIndex = 2;
            this.start.Text = "&Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.ldCamera_Click);
            // 
            // refCamera
            // 
            this.refCamera.Location = new System.Drawing.Point(4, 79);
            this.refCamera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.refCamera.Name = "refCamera";
            this.refCamera.Size = new System.Drawing.Size(284, 52);
            this.refCamera.TabIndex = 1;
            this.refCamera.Text = "Refresh Camera";
            this.refCamera.UseVisualStyleBackColor = true;
            this.refCamera.Click += new System.EventHandler(this.refCamera_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(4, 31);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(280, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(320, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1259, 1131);
            this.tabControl1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.pictureBox1);
            this.tab1.Location = new System.Drawing.Point(8, 39);
            this.tab1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tab1.Size = new System.Drawing.Size(1243, 1084);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Image 1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1231, 1072);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.pictureBox2);
            this.tab2.Location = new System.Drawing.Point(8, 39);
            this.tab2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tab2.Size = new System.Drawing.Size(1242, 1082);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Image 2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1230, 1070);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.pictureBox3);
            this.tab3.Location = new System.Drawing.Point(8, 39);
            this.tab3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(1242, 1082);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Image Differences";
            this.tab3.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1242, 1082);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_person);
            this.panel2.Controls.Add(this.lb_faceSpace);
            this.panel2.Controls.Add(this.lb_distance);
            this.panel2.Controls.Add(this.fndFacePic);
            this.panel2.Controls.Add(this.fndFaceLabel);
            this.panel2.Controls.Add(this.capFaceLabel);
            this.panel2.Controls.Add(this.capFacePic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1591, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 1131);
            this.panel2.TabIndex = 2;
            // 
            // fndFacePic
            // 
            this.fndFacePic.Location = new System.Drawing.Point(68, 344);
            this.fndFacePic.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.fndFacePic.Name = "fndFacePic";
            this.fndFacePic.Size = new System.Drawing.Size(356, 221);
            this.fndFacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fndFacePic.TabIndex = 3;
            this.fndFacePic.TabStop = false;
            // 
            // fndFaceLabel
            // 
            this.fndFaceLabel.AutoSize = true;
            this.fndFaceLabel.Location = new System.Drawing.Point(68, 313);
            this.fndFaceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fndFaceLabel.Name = "fndFaceLabel";
            this.fndFaceLabel.Size = new System.Drawing.Size(127, 25);
            this.fndFaceLabel.TabIndex = 2;
            this.fndFaceLabel.Text = "Found Face";
            // 
            // capFaceLabel
            // 
            this.capFaceLabel.AutoSize = true;
            this.capFaceLabel.Location = new System.Drawing.Point(62, 46);
            this.capFaceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.capFaceLabel.Name = "capFaceLabel";
            this.capFaceLabel.Size = new System.Drawing.Size(154, 25);
            this.capFaceLabel.TabIndex = 1;
            this.capFaceLabel.Text = "Captured Face";
            // 
            // capFacePic
            // 
            this.capFacePic.Location = new System.Drawing.Point(68, 79);
            this.capFacePic.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.capFacePic.Name = "capFacePic";
            this.capFacePic.Size = new System.Drawing.Size(356, 221);
            this.capFacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.capFacePic.TabIndex = 0;
            this.capFacePic.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lb_distance
            // 
            this.lb_distance.AutoSize = true;
            this.lb_distance.Location = new System.Drawing.Point(67, 575);
            this.lb_distance.Name = "lb_distance";
            this.lb_distance.Size = new System.Drawing.Size(102, 25);
            this.lb_distance.TabIndex = 4;
            this.lb_distance.Text = "Distance:";
            // 
            // findFaceToolStripMenuItem1
            // 
            this.findFaceToolStripMenuItem1.Enabled = false;
            this.findFaceToolStripMenuItem1.Name = "findFaceToolStripMenuItem1";
            this.findFaceToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.findFaceToolStripMenuItem1.Size = new System.Drawing.Size(401, 38);
            this.findFaceToolStripMenuItem1.Text = "Find Face";
            this.findFaceToolStripMenuItem1.Click += new System.EventHandler(this.findFaceToolStripMenuItem1_Click);
            // 
            // lb_faceSpace
            // 
            this.lb_faceSpace.AutoSize = true;
            this.lb_faceSpace.Location = new System.Drawing.Point(67, 604);
            this.lb_faceSpace.Name = "lb_faceSpace";
            this.lb_faceSpace.Size = new System.Drawing.Size(133, 25);
            this.lb_faceSpace.TabIndex = 5;
            this.lb_faceSpace.Text = "Face Space:";
            // 
            // lb_person
            // 
            this.lb_person.AutoSize = true;
            this.lb_person.Location = new System.Drawing.Point(205, 310);
            this.lb_person.Name = "lb_person";
            this.lb_person.Size = new System.Drawing.Size(80, 25);
            this.lb_person.TabIndex = 6;
            this.lb_person.Text = "Person";
            // 
            // FaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2066, 1187);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            ((System.ComponentModel.ISupportInitialize)(this.fndFacePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capFacePic)).EndInit();
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
        private System.Windows.Forms.Label lb_distance;
        private System.Windows.Forms.ToolStripMenuItem findFaceToolStripMenuItem1;
        private System.Windows.Forms.Label lb_faceSpace;
        private System.Windows.Forms.Label lb_person;
    }
}

