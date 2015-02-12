namespace PanoConverter
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
			this.pb_bottom = new System.Windows.Forms.PictureBox();
			this.pb_top = new System.Windows.Forms.PictureBox();
			this.pb_left = new System.Windows.Forms.PictureBox();
			this.pb_front = new System.Windows.Forms.PictureBox();
			this.pb_right = new System.Windows.Forms.PictureBox();
			this.pb_back = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pb_bottom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_top)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_left)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_front)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_right)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_back)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// pb_bottom
			// 
			this.pb_bottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_bottom.Location = new System.Drawing.Point(112, 231);
			this.pb_bottom.Name = "pb_bottom";
			this.pb_bottom.Size = new System.Drawing.Size(100, 100);
			this.pb_bottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_bottom.TabIndex = 0;
			this.pb_bottom.TabStop = false;
			// 
			// pb_top
			// 
			this.pb_top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_top.Location = new System.Drawing.Point(112, 19);
			this.pb_top.Name = "pb_top";
			this.pb_top.Size = new System.Drawing.Size(100, 100);
			this.pb_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_top.TabIndex = 1;
			this.pb_top.TabStop = false;
			// 
			// pb_left
			// 
			this.pb_left.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_left.Location = new System.Drawing.Point(6, 125);
			this.pb_left.Name = "pb_left";
			this.pb_left.Size = new System.Drawing.Size(100, 100);
			this.pb_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_left.TabIndex = 2;
			this.pb_left.TabStop = false;
			// 
			// pb_front
			// 
			this.pb_front.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_front.Location = new System.Drawing.Point(112, 125);
			this.pb_front.Name = "pb_front";
			this.pb_front.Size = new System.Drawing.Size(100, 100);
			this.pb_front.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_front.TabIndex = 3;
			this.pb_front.TabStop = false;
			// 
			// pb_right
			// 
			this.pb_right.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_right.Location = new System.Drawing.Point(218, 125);
			this.pb_right.Name = "pb_right";
			this.pb_right.Size = new System.Drawing.Size(100, 100);
			this.pb_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_right.TabIndex = 4;
			this.pb_right.TabStop = false;
			// 
			// pb_back
			// 
			this.pb_back.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_back.Location = new System.Drawing.Point(324, 125);
			this.pb_back.Name = "pb_back";
			this.pb_back.Size = new System.Drawing.Size(100, 100);
			this.pb_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_back.TabIndex = 5;
			this.pb_back.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.trackBar1);
			this.groupBox1.Controls.Add(this.pb_back);
			this.groupBox1.Controls.Add(this.pb_bottom);
			this.groupBox1.Controls.Add(this.pb_right);
			this.groupBox1.Controls.Add(this.pb_top);
			this.groupBox1.Controls.Add(this.pb_front);
			this.groupBox1.Controls.Add(this.pb_left);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(433, 345);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cube Faces";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 364);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Step 1:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 380);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 39);
			this.button1.TabIndex = 8;
			this.button1.Text = "Load Images...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ofd
			// 
			this.ofd.DefaultExt = "jpg";
			this.ofd.Filter = "JPEG Files(*.JPEG;*.JPG)|*.JPEG;*.JPG|Other Common Image Types|*.GIF;*.PNG;*.BMP|" +
    "All files (*.*)|*.*";
			this.ofd.SupportMultiDottedExtensions = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(124, 364);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Step 2:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(127, 380);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 39);
			this.button2.TabIndex = 10;
			this.button2.Text = "Save Panorama...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// fbd
			// 
			this.fbd.Description = "Choose or create a blank folder to create the panorama in.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(227, 364);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Step 3:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(227, 380);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 39);
			this.label4.TabIndex = 12;
			this.label4.Text = "Zip the CONTENTS OF the folder (e.g.\r\n\"Send To > Compressed (zipped) folder\")\r\nan" +
    "d change the extension to .pano\r\n";
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 10;
			this.trackBar1.Location = new System.Drawing.Point(218, 74);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(206, 45);
			this.trackBar1.SmallChange = 5;
			this.trackBar1.TabIndex = 6;
			this.trackBar1.TickFrequency = 5;
			this.trackBar1.Value = 80;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(218, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "JPEG quality 80";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 441);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "PanoConverter";
			((System.ComponentModel.ISupportInitialize)(this.pb_bottom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_top)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_left)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_front)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_right)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_back)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_bottom;
		private System.Windows.Forms.PictureBox pb_top;
		private System.Windows.Forms.PictureBox pb_left;
		private System.Windows.Forms.PictureBox pb_front;
		private System.Windows.Forms.PictureBox pb_right;
		private System.Windows.Forms.PictureBox pb_back;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar trackBar1;
	}
}

