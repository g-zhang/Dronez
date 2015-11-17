namespace DroneUI2._0
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.picList = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.futurePointsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DroneTerminal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ManWayX = new System.Windows.Forms.TextBox();
            this.ManWayY = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.liveVideoFeedBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveVideoFeedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(356, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 25;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(294, 201);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 15D;
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Return to operator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Computer Vision Mode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "GPS Waypoint navigation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 349);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Manual Flight";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 432);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Current Flight Mode:";
            // 
            // picList
            // 
            this.picList.FormattingEnabled = true;
            this.picList.Items.AddRange(new object[] {
            "1) Square detected at GPS position(40.124556, 43.122455)",
            "2) Circle detected at GPS position(40.134532, 43.113344)"});
            this.picList.Location = new System.Drawing.Point(688, 266);
            this.picList.Name = "picList";
            this.picList.Size = new System.Drawing.Size(340, 186);
            this.picList.TabIndex = 8;
            this.picList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "rect.png");
            this.imageList1.Images.SetKeyName(1, "circle.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(688, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // futurePointsList
            // 
            this.futurePointsList.FormattingEnabled = true;
            this.futurePointsList.Location = new System.Drawing.Point(346, 271);
            this.futurePointsList.Name = "futurePointsList";
            this.futurePointsList.Size = new System.Drawing.Size(304, 82);
            this.futurePointsList.TabIndex = 10;
            this.futurePointsList.SelectedIndexChanged += new System.EventHandler(this.futurePointsList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "GPS Waypoints:";
            // 
            // DroneTerminal
            // 
            this.DroneTerminal.Location = new System.Drawing.Point(346, 380);
            this.DroneTerminal.Multiline = true;
            this.DroneTerminal.Name = "DroneTerminal";
            this.DroneTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DroneTerminal.Size = new System.Drawing.Size(304, 88);
            this.DroneTerminal.TabIndex = 12;
            this.DroneTerminal.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Drone Terminal";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(688, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Detected Objects:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 378);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Save this flight plan";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ManWayX
            // 
            this.ManWayX.Location = new System.Drawing.Point(346, 244);
            this.ManWayX.Name = "ManWayX";
            this.ManWayX.Size = new System.Drawing.Size(100, 20);
            this.ManWayX.TabIndex = 16;
            // 
            // ManWayY
            // 
            this.ManWayY.Location = new System.Drawing.Point(452, 244);
            this.ManWayY.Name = "ManWayY";
            this.ManWayY.Size = new System.Drawing.Size(100, 20);
            this.ManWayY.TabIndex = 17;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(558, 242);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(115, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "Add Waypoint";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // liveVideoFeedBox
            // 
            this.liveVideoFeedBox.Location = new System.Drawing.Point(14, 12);
            this.liveVideoFeedBox.Name = "liveVideoFeedBox";
            this.liveVideoFeedBox.Size = new System.Drawing.Size(300, 201);
            this.liveVideoFeedBox.TabIndex = 19;
            this.liveVideoFeedBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 477);
            this.Controls.Add(this.liveVideoFeedBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.ManWayY);
            this.Controls.Add(this.ManWayX);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DroneTerminal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.futurePointsList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gmap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveVideoFeedBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox picList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox futurePointsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DroneTerminal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox ManWayX;
        private System.Windows.Forms.TextBox ManWayY;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox liveVideoFeedBox;
    }
}

