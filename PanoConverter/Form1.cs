using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PanoConverter
{
	public partial class Form1 : Form
	{

		double SHRINKPCT = 0.995;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ofd.Title = "Front Face";
			DialogResult result = ofd.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				pb_front.Load(ofd.FileName);
			}
			ofd.Title = "Right Face";
			result = ofd.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				pb_right.Load(ofd.FileName);
			}
			ofd.Title = "Back Face";
			result = ofd.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				pb_back.Load(ofd.FileName);
			}
			ofd.Title = "Left Face";
			result = ofd.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				pb_left.Load(ofd.FileName);
			}
			ofd.Title = "Bottom Face";
			result = ofd.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				pb_bottom.Load(ofd.FileName);
			}
			ofd.Title = "Top Face";
			result = ofd.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				pb_top.Load(ofd.FileName);
			}

			if (pb_front.ImageLocation == null)
				pb_front.BackColor = Color.Black;
			if (pb_right.ImageLocation == null)
				pb_right.BackColor = Color.Black;
			if (pb_back.ImageLocation == null)
				pb_back.BackColor = Color.Black;
			if (pb_left.ImageLocation == null)
				pb_left.BackColor = Color.Black;
			if (pb_bottom.ImageLocation == null)
				pb_bottom.BackColor = Color.Black;
			if (pb_top.ImageLocation == null)
				pb_top.BackColor = Color.Black;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			button2.Enabled = false;

			string[] faces = new string[6];
			faces[0] = pb_front.ImageLocation;
			if (pb_front.Image != null)
				pb_front.Image.Dispose();
			pb_front.Image = null;
			faces[1] = pb_right.ImageLocation;
			if (pb_right.Image != null)
				pb_right.Image.Dispose();
			pb_right.Image = null;
			faces[2] = pb_back.ImageLocation;
			if (pb_back.Image != null)
				pb_back.Image.Dispose();
			pb_back.Image = null;
			faces[3] = pb_left.ImageLocation;
			if (pb_left.Image != null)
				pb_left.Image.Dispose();
			pb_left.Image = null;
			faces[4] = pb_bottom.ImageLocation;
			if (pb_bottom.Image != null)
				pb_bottom.Image.Dispose();
			pb_bottom.Image = null;
			faces[5] = pb_top.ImageLocation;
			if (pb_top.Image != null)
				pb_top.Image.Dispose();
			pb_top.Image = null;
			
			int origsize;

			int jquality = trackBar1.Value;

			Image cubeface = Image.FromFile(faces[0]);
			
			// Get user to choose the main folder
			DialogResult result = fbd.ShowDialog();
			string baseFolder = fbd.SelectedPath;

			// Create required folders inside here
			makeFolders(baseFolder);
			writeBoilerPlate(baseFolder, cubeface.Width);

			//for each face, make the 512x512 sections and save as images
				// level 9: resize proportionally to a single image. never cropped! (2^9 = 512, so output one image)
					//resizing: new dimension = original dimension/(2^(maxpower-9)) where maxpower is the largest required level
					//maxlevel is the minimum x where 2^x > original dimension
					//equivalent to rounding up (log2(original dimension) to the next integer)
				// levels 10+: crop sections at the right/bottom edges if there's less than 512 pixels left

			int maxlevel = (int)Math.Ceiling(Math.Log(cubeface.Width, 2));
			if (maxlevel < 9)
				maxlevel = 9;
			string[] facenames = { "front", "right", "back", "left", "bottom","top"};

			for (int i = 0; i < 6; i++)
			{
				if (faces[i] == null)
					break;
				cubeface.Dispose();
				cubeface = Image.FromFile(faces[i]);
				origsize = cubeface.Width;
				//level 9: no cropping, only resize
				Directory.CreateDirectory(Path.Combine(baseFolder,"formats","cubemap",facenames[i],"9"));
				Bitmap outfile = resizeImage(cubeface, new Size(origsize / (int)Math.Pow(2, maxlevel - 9), origsize / (int)Math.Pow(2, maxlevel - 9)));
				saveJpeg(Path.Combine(baseFolder, "formats", "cubemap", facenames[i], "9", "0_0.jpg"), outfile, jquality);
				outfile.Dispose();
				for (int j = 10; j < maxlevel + 1; j++)
				{
					Directory.CreateDirectory(Path.Combine(baseFolder, "formats", "cubemap", facenames[i], j.ToString()));
					
					//resize original face once. save various cropped sections of it
					outfile = resizeImage(cubeface, new Size(origsize / (int)Math.Pow(2, maxlevel - j), origsize / (int)Math.Pow(2, maxlevel - j)));
					for (int x = 0; x < Math.Pow(2, j - 9); x++)
					{
						for (int y = 0; y < Math.Pow(2, j - 9); y++)
						{
							Bitmap b = cropImage(outfile, new Rectangle(512 * x, 512 * y, (512 * (x + 1) > outfile.Width ? (outfile.Width - 512 * x) : 512), (512 * (y + 1) > outfile.Height ? (outfile.Height - 512 * y) : 512)));
							saveJpeg(Path.Combine(baseFolder, "formats", "cubemap", facenames[i], j.ToString(), x + "_" + y + ".jpg"), b, jquality);
							b.Dispose();
							if (512 * (y + 1) > outfile.Height)
								break;
						}

						if (512 * (x + 1) > outfile.Width)
							break;
					}
					outfile.Dispose();
				}
			}
			cubeface.Dispose();

			//create atlas.jpg
			//somewhat arbitrarily 768x128 - 128x128 for each cube in order back-left-front-right-bottom-top
			System.Drawing.Bitmap atl = new System.Drawing.Bitmap(768,128);
			Graphics g = Graphics.FromImage(atl);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.Clear(Color.Black);
			for (int i = 0; i < 6; i++)
			{
				if (faces[i] == null)
					break;
				Image img = Image.FromFile(faces[i]);
				g.DrawImage(img, i * 128, 0, 128, 128);
				img.Dispose();
			}
			g.Dispose();
			saveJpeg(Path.Combine(baseFolder, "formats", "cubemap","atlas.jpg"), atl, 75);
			atl.Dispose();
			MessageBox.Show("Finished!");
		}

		private static Bitmap cropImage(Bitmap img, Rectangle cropArea)
		{
			//Bitmap bmpImage = new Bitmap(img);
			Bitmap bmpCrop = img.Clone(cropArea, img.PixelFormat);
			return bmpCrop;
		}

		private static Bitmap resizeImage(Image imgToResize, Size size)
		{
			int sourceWidth = imgToResize.Width;
			int sourceHeight = imgToResize.Height;

			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;

			nPercentW = ((float)size.Width / (float)sourceWidth);
			nPercentH = ((float)size.Height / (float)sourceHeight);

			if (nPercentH < nPercentW)
				nPercent = nPercentH;
			else
				nPercent = nPercentW;

			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);

			if (sourceHeight == destHeight && sourceWidth == destWidth)
				return new Bitmap(imgToResize);

			Bitmap b = new Bitmap(destWidth, destHeight);
			using (Graphics g = System.Drawing.Graphics.FromImage(b))
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
				g.Dispose();
			}

			return b;
		}

		private void saveJpeg(string path, Bitmap img, long quality)
		{
			// Encoder parameter for image quality
			EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

			// Jpeg image codec
			ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

			if (jpegCodec == null)
				return;

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;

			img.Save(path, jpegCodec, encoderParams);
			img.Dispose();
		}

		private ImageCodecInfo getEncoderInfo(string mimeType)
		{
			// Get image codecs for all image formats
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

			// Find the correct image codec
			for (int i = 0; i < codecs.Length; i++)
				if (codecs[i].MimeType == mimeType)
					return codecs[i];
			return null;
		}
		
		private void makeFolders(string f)
		{
			string[] faces = { "front", "back", "left", "right", "top", "bottom" };
			// _rels, formats/cubemap/faces, properties
			//Directory.CreateDirectory(f + "\\_rels");
			foreach (string face in faces)
			{
				Directory.CreateDirectory(Path.Combine(f,"formats","cubemap",face));
			}
			//Directory.CreateDirectory(f + "\\properties");
		}

		private void writeBoilerPlate(string f, int size)
		{
			// _rels\.rels
			//File.WriteAllText(Path.Combine(f, "_rels", ".rels"), "<?xml version=\"1.0\" encoding=\"utf-8\"?><Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\"><Relationship Type=\"http://schemas.openxmlformats.org/package/2006/relationships/metadata/thumbnail\" Target=\"/properties/thumbnail.jpg\" Id=\"R0\" /><Relationship Type=\"http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties\" Target=\"/properties/properties.coreprop\" Id=\"R1\" /></Relationships>\"");
			
			// formats\cubemap\cubemap.json
			File.WriteAllText(Path.Combine(f, "formats", "cubemap", "cubemap.json"), "{\"cubemap_json_version\":1,\"tile_size\":510,\"face_size\":" + size*SHRINKPCT + ",\"front\":{},\"right\":{},\"back\":{},\"left\":{},\"top\":{},\"bottom\":{},\"field_of_view_bounds\":[0,360,-90,90],\"initial_look_direction\":[0,0]}"); //might have to tune the initial look dir
			
			// properties\properties.coreprop
			//File.WriteAllText(Path.Combine(f, "properties","properties.coreprop"), "<cp:coreProperties xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:dcterms=\"http://purl.org/dc/terms/\" xmlns:cp=\"http://schemas.openxmlformats.org/package/2006/metadata/core-properties\" xmlns:p=\"http://schemas.microsoft.com/panoramaDocument/2013/panorama-properties\"><p:horizontalFieldOfView>360.0</p:horizontalFieldOfView><p:verticalFieldOfView>180.0</p:verticalFieldOfView></cp:coreProperties>"); //removed a number of metadata items here

			// [Content_Types].xml
			File.WriteAllText(Path.Combine(f, "[Content_Types].xml"), "<?xml version=\"1.0\" encoding=\"utf-8\"?><Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\"><Default Extension=\"jpg\" ContentType=\"image/jpeg\" /><Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\" /><Default Extension=\"json\" ContentType=\"application/json\" /><Default Extension=\"coreprop\" ContentType=\"application/vnd.openxmlformats-package.core-properties+xml\" /></Types>");
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			label5.Text = "JPEG quality " + trackBar1.Value;
		}
	}
}
