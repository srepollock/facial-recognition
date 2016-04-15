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
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.videoInfo = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.refCamera = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.libLabel = new System.Windows.Forms.Label();
            this.avgFace = new System.Windows.Forms.PictureBox();
            this.lb_faceSpace = new System.Windows.Forms.Label();
            this.lb_distance = new System.Windows.Forms.Label();
            this.fndFacePic = new System.Windows.Forms.PictureBox();
            this.lb_person = new System.Windows.Forms.Label();
            this.fndFaceLabel = new System.Windows.Forms.Label();
            this.capFacePic = new System.Windows.Forms.PictureBox();
            this.capFaceLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avgFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fndFacePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capFacePic)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureToolStripMenuItem,
            this.findToolStripMenuItem,
            this.addToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Enabled = false;
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.captureToolStripMenuItem.Text = "&Capture";
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.captureToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Enabled = false;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.findToolStripMenuItem.Text = "&Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.23476F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.56825F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.2333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1132, 519);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.videoInfo);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.refCamera);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 513);
            this.panel1.TabIndex = 0;
            // 
            // videoInfo
            // 
            this.videoInfo.AutoSize = true;
            this.videoInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoInfo.Location = new System.Drawing.Point(0, 500);
            this.videoInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.videoInfo.Name = "videoInfo";
            this.videoInfo.Size = new System.Drawing.Size(62, 13);
            this.videoInfo.TabIndex = 3;
            this.videoInfo.Text = "Device Info";
            // 
            // start
            // 
            this.start.Dock = System.Windows.Forms.DockStyle.Top;
            this.start.Location = new System.Drawing.Point(0, 69);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(166, 27);
            this.start.TabIndex = 4;
            this.start.Text = "&Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.ldCamera_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(0, 48);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(166, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // refCamera
            // 
            this.refCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.refCamera.Location = new System.Drawing.Point(0, 21);
            this.refCamera.Margin = new System.Windows.Forms.Padding(2);
            this.refCamera.Name = "refCamera";
            this.refCamera.Size = new System.Drawing.Size(166, 27);
            this.refCamera.TabIndex = 1;
            this.refCamera.Text = "&Refresh Camera";
            this.refCamera.UseVisualStyleBackColor = true;
            this.refCamera.Click += new System.EventHandler(this.refCamera_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.libLabel);
            this.panel2.Controls.Add(this.avgFace);
            this.panel2.Controls.Add(this.lb_faceSpace);
            this.panel2.Controls.Add(this.lb_distance);
            this.panel2.Controls.Add(this.fndFacePic);
            this.panel2.Controls.Add(this.lb_person);
            this.panel2.Controls.Add(this.fndFaceLabel);
            this.panel2.Controls.Add(this.capFacePic);
            this.panel2.Controls.Add(this.capFaceLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(871, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 513);
            this.panel2.TabIndex = 2;
            // 
            // libLabel
            // 
            this.libLabel.AutoSize = true;
            this.libLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.libLabel.Location = new System.Drawing.Point(0, 410);
            this.libLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.libLabel.Name = "libLabel";
            this.libLabel.Size = new System.Drawing.Size(74, 13);
            this.libLabel.TabIndex = 8;
            this.libLabel.Text = "Average Face";
            // 
            // avgFace
            // 
            this.avgFace.Dock = System.Windows.Forms.DockStyle.Top;
            this.avgFace.Location = new System.Drawing.Point(0, 295);
            this.avgFace.Name = "avgFace";
            this.avgFace.Size = new System.Drawing.Size(258, 115);
            this.avgFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avgFace.TabIndex = 7;
            this.avgFace.TabStop = false;
            // 
            // lb_faceSpace
            // 
            this.lb_faceSpace.AutoSize = true;
            this.lb_faceSpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_faceSpace.Location = new System.Drawing.Point(0, 282);
            this.lb_faceSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_faceSpace.Name = "lb_faceSpace";
            this.lb_faceSpace.Size = new System.Drawing.Size(68, 13);
            this.lb_faceSpace.TabIndex = 5;
            this.lb_faceSpace.Text = "Face Space:";
            // 
            // lb_distance
            // 
            this.lb_distance.AutoSize = true;
            this.lb_distance.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_distance.Location = new System.Drawing.Point(0, 269);
            this.lb_distance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_distance.Name = "lb_distance";
            this.lb_distance.Size = new System.Drawing.Size(52, 13);
            this.lb_distance.TabIndex = 4;
            this.lb_distance.Text = "Distance:";
            // 
            // fndFacePic
            // 
            this.fndFacePic.Dock = System.Windows.Forms.DockStyle.Top;
            this.fndFacePic.Location = new System.Drawing.Point(0, 154);
            this.fndFacePic.Name = "fndFacePic";
            this.fndFacePic.Size = new System.Drawing.Size(258, 115);
            this.fndFacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fndFacePic.TabIndex = 3;
            this.fndFacePic.TabStop = false;
            // 
            // lb_person
            // 
            this.lb_person.AutoSize = true;
            this.lb_person.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_person.Location = new System.Drawing.Point(0, 141);
            this.lb_person.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_person.Name = "lb_person";
            this.lb_person.Size = new System.Drawing.Size(40, 13);
            this.lb_person.TabIndex = 6;
            this.lb_person.Text = "Person";
            // 
            // fndFaceLabel
            // 
            this.fndFaceLabel.AutoSize = true;
            this.fndFaceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fndFaceLabel.Location = new System.Drawing.Point(0, 128);
            this.fndFaceLabel.Name = "fndFaceLabel";
            this.fndFaceLabel.Size = new System.Drawing.Size(64, 13);
            this.fndFaceLabel.TabIndex = 2;
            this.fndFaceLabel.Text = "Found Face";
            // 
            // capFacePic
            // 
            this.capFacePic.Dock = System.Windows.Forms.DockStyle.Top;
            this.capFacePic.Location = new System.Drawing.Point(0, 13);
            this.capFacePic.Name = "capFacePic";
            this.capFacePic.Size = new System.Drawing.Size(258, 115);
            this.capFacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.capFacePic.TabIndex = 0;
            this.capFacePic.TabStop = false;
            // 
            // capFaceLabel
            // 
            this.capFaceLabel.AutoSize = true;
            this.capFaceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.capFaceLabel.Location = new System.Drawing.Point(0, 0);
            this.capFaceLabel.Name = "capFaceLabel";
            this.capFaceLabel.Size = new System.Drawing.Size(77, 13);
            this.capFaceLabel.TabIndex = 1;
            this.capFaceLabel.Text = "Captured Face";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainPicture);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(175, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(690, 513);
            this.mainPanel.TabIndex = 3;
            // 
            // mainPicture
            // 
            this.mainPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPicture.Location = new System.Drawing.Point(0, 0);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(690, 513);
            this.mainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // FaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FaceRecognition";
            this.Text = "Facial Recognition - Spencer Pollock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FaceRecognition_Close);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avgFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fndFacePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capFacePic)).EndInit();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button refCamera;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label videoInfo;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label fndFaceLabel;
        private System.Windows.Forms.Label capFaceLabel;
        private System.Windows.Forms.PictureBox capFacePic;
        private System.Windows.Forms.PictureBox fndFacePic;
        private System.Windows.Forms.Label lb_distance;
        private System.Windows.Forms.Label lb_faceSpace;
        private System.Windows.Forms.Label lb_person;
        private System.Windows.Forms.Label libLabel;
        private System.Windows.Forms.PictureBox avgFace;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.Button start;
    }
}

