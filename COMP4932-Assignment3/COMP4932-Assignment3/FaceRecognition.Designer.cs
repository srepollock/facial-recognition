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
            this.videoInfo = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1540, 44);
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
            this.toolStripMenuItem1});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.Enabled = false;
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.motionToolStripMenuItem.Text = "Motion";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem,
            this.gIFToolStripMenuItem1});
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
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
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
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
            this.toolStripMenuItem1.Size = new System.Drawing.Size(223, 6);
            // 
            // findFaceToolStripMenuItem
            // 
            this.findFaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bruteForceToolStripMenuItem,
            this.optimizedToolStripMenuItem,
            this.motionToolStripMenuItem1});
            this.findFaceToolStripMenuItem.Enabled = false;
            this.findFaceToolStripMenuItem.Name = "findFaceToolStripMenuItem";
            this.findFaceToolStripMenuItem.Size = new System.Drawing.Size(127, 36);
            this.findFaceToolStripMenuItem.Text = "Find Face";
            // 
            // bruteForceToolStripMenuItem
            // 
            this.bruteForceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem2,
            this.gIFToolStripMenuItem});
            this.bruteForceToolStripMenuItem.Name = "bruteForceToolStripMenuItem";
            this.bruteForceToolStripMenuItem.Size = new System.Drawing.Size(237, 38);
            this.bruteForceToolStripMenuItem.Text = "Brute Force";
            // 
            // jPEGToolStripMenuItem2
            // 
            this.jPEGToolStripMenuItem2.Name = "jPEGToolStripMenuItem2";
            this.jPEGToolStripMenuItem2.Size = new System.Drawing.Size(165, 38);
            this.jPEGToolStripMenuItem2.Text = "JPEG";
            // 
            // gIFToolStripMenuItem
            // 
            this.gIFToolStripMenuItem.Name = "gIFToolStripMenuItem";
            this.gIFToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.gIFToolStripMenuItem.Text = "GIF";
            // 
            // optimizedToolStripMenuItem
            // 
            this.optimizedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem3,
            this.gIFToolStripMenuItem3});
            this.optimizedToolStripMenuItem.Name = "optimizedToolStripMenuItem";
            this.optimizedToolStripMenuItem.Size = new System.Drawing.Size(237, 38);
            this.optimizedToolStripMenuItem.Text = "Optimized";
            // 
            // jPEGToolStripMenuItem3
            // 
            this.jPEGToolStripMenuItem3.Name = "jPEGToolStripMenuItem3";
            this.jPEGToolStripMenuItem3.Size = new System.Drawing.Size(165, 38);
            this.jPEGToolStripMenuItem3.Text = "JPEG";
            // 
            // gIFToolStripMenuItem3
            // 
            this.gIFToolStripMenuItem3.Name = "gIFToolStripMenuItem3";
            this.gIFToolStripMenuItem3.Size = new System.Drawing.Size(165, 38);
            this.gIFToolStripMenuItem3.Text = "GIF";
            // 
            // motionToolStripMenuItem1
            // 
            this.motionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem4,
            this.gIFToolStripMenuItem4});
            this.motionToolStripMenuItem1.Name = "motionToolStripMenuItem1";
            this.motionToolStripMenuItem1.Size = new System.Drawing.Size(237, 38);
            this.motionToolStripMenuItem1.Text = "Motion";
            // 
            // jPEGToolStripMenuItem4
            // 
            this.jPEGToolStripMenuItem4.Name = "jPEGToolStripMenuItem4";
            this.jPEGToolStripMenuItem4.Size = new System.Drawing.Size(165, 38);
            this.jPEGToolStripMenuItem4.Text = "JPEG";
            // 
            // gIFToolStripMenuItem4
            // 
            this.gIFToolStripMenuItem4.Name = "gIFToolStripMenuItem4";
            this.gIFToolStripMenuItem4.Size = new System.Drawing.Size(165, 38);
            this.gIFToolStripMenuItem4.Text = "GIF";
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
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(190, 38);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.90141F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.09859F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1540, 944);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.videoInfo);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.refCamera);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 932);
            this.panel1.TabIndex = 0;
            // 
            // videoInfo
            // 
            this.videoInfo.Location = new System.Drawing.Point(0, 901);
            this.videoInfo.Name = "videoInfo";
            this.videoInfo.Size = new System.Drawing.Size(251, 31);
            this.videoInfo.TabIndex = 3;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(27, 136);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(197, 49);
            this.start.TabIndex = 2;
            this.start.Text = "&Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.ldCamera_Click);
            // 
            // refCamera
            // 
            this.refCamera.Location = new System.Drawing.Point(27, 79);
            this.refCamera.Name = "refCamera";
            this.refCamera.Size = new System.Drawing.Size(197, 51);
            this.refCamera.TabIndex = 1;
            this.refCamera.Text = "Refresh Camera";
            this.refCamera.UseVisualStyleBackColor = true;
            this.refCamera.Click += new System.EventHandler(this.refCamera_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(27, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(266, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1268, 932);
            this.tabControl1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.pictureBox1);
            this.tab1.Location = new System.Drawing.Point(8, 39);
            this.tab1.Margin = new System.Windows.Forms.Padding(6);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(6);
            this.tab1.Size = new System.Drawing.Size(1252, 885);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Image 1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1240, 873);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.pictureBox2);
            this.tab2.Location = new System.Drawing.Point(8, 39);
            this.tab2.Margin = new System.Windows.Forms.Padding(6);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(6);
            this.tab2.Size = new System.Drawing.Size(1252, 885);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Image 2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1240, 873);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.pictureBox3);
            this.tab3.Location = new System.Drawing.Point(8, 39);
            this.tab3.Margin = new System.Windows.Forms.Padding(6);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(1252, 885);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Image Differences";
            this.tab3.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1252, 885);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // FaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 988);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private System.Windows.Forms.TextBox videoInfo;
        private System.Windows.Forms.Timer timer1;
    }
}

