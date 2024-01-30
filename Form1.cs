/* UI Texture Squasher, a tool for converting UI textures from two 
   ATI2 encoded YCoCg images to and from a single bitmap for The Sims 4,
   Copyright (C) 2016  C. Marinetti

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>. 
   The author may be contacted at modthesims.info, username cmarNYC.
   
   With thanks to SimGuruModSquad at EA forums for info and example.
   With thanks to mpen at stackoverflow for the resizing code. */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using s4pi.Interfaces;
using s4pi.ImageResource;


namespace UITextureSquasher
{
    public partial class Form1 : Form
    {
       string DDSfilter = "DDS image files (*.dds)|*.dds|All files (*.*)|*.*";
       string PNGfilter = "PNG image files (*.png)|*.png|All files (*.*)|*.*";

       public Form1()
        {
            InitializeComponent();
            this.Text = "UI Texture Squasher - PNG version";
        }

        internal string GetFilename(string title, string filter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = title;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                return "";
            }

        }

        private void ATIfile1_button_Click(object sender, EventArgs e)
        {
            ATIfile1.Text = GetFilename("Select UI compressed file 1:", DDSfilter);
        }

        private void ATIfile2_button_Click(object sender, EventArgs e)
        {
            ATIfile2.Text = GetFilename("Select UI compressed file 2:", DDSfilter);
        }

        private void PNGfile_button_Click(object sender, EventArgs e)
        {
            PNGfile.Text = GetFilename("Select PNG image file:", PNGfilter);
        }

        private void ATItoPNGgo_button_Click(object sender, EventArgs e)
        {
            if (string.Compare(ATIfile1.Text, " ") <= 0 | string.Compare(ATIfile2.Text, " ") <= 0) 
            {
                MessageBox.Show("You must select two UI encoded images!");
                return;
            }
            DdsFile dds = new DdsFile();
            using (FileStream myStream = new FileStream(ATIfile1.Text, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    dds.Load(myStream, false);
                }
                catch
                {
                    if (!dds.UseATI)
                    {
                        MessageBox.Show("DDS file 1 must be an ATI-encoded DDS file!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Can't read DDS file 1!");
                        return;
                    }
                }
            }
            DdsFile dds2 = new DdsFile();
            using (FileStream myStream = new FileStream(ATIfile2.Text, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    dds2.Load(myStream, false);
                }
                catch
                {
                    if (!dds2.UseATI)
                    {
                        MessageBox.Show("DDS file 2 must be an ATI-encoded DDS file!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Can't read DDS file 2!");
                        return;
                    }
                }
            }
            Bitmap bit1 = dds.Image;
            Bitmap bit2 = ResizeImage(dds2.Image, dds.Size.Width, dds.Size.Height);
            Bitmap bmp = new Bitmap(dds.Size.Width, dds.Size.Height);

            BitmapData bit1Data;
            IntPtr bit1Point;
            byte[] bit1Array;
            MarshalBitsOn(bit1, out bit1Data, out bit1Point, out bit1Array);

            BitmapData bit2Data;
            IntPtr bit2Point;
            byte[] bit2Array;
            MarshalBitsOn(bit2, out bit2Data, out bit2Point, out bit2Array);

            BitmapData bmpData;
            IntPtr bmpPoint;
            byte[] bmpArray;
            MarshalBitsOn(bmp, out bmpData, out bmpPoint, out bmpArray);


            for (int i = 0; i < bit1Array.Length; i += 4)
            {
                int Co = bit2Array[i + 1];
                int Cg = bit2Array[i + 2];
                int L = bit1Array[i + 2];
                int r = L + Co - Cg;
                int g = L + Cg - 128;
                int b = L - Cg - Co + 256;
                if (r < 0) r = 0;
                if (r > 255) r = 255;
                if (g < 0) g = 0;
                if (g > 255) g = 255;
                if (b < 0) b = 0;
                if (b > 255) b = 255;
                  
                bmpArray[i + 3] = bit1Array[i + 1];     //alpha
                bmpArray[i + 2] = (byte)r;              //red
                bmpArray[i + 1] = (byte)g;              //green
                bmpArray[i] = (byte)b;                  //blue
            }

            MarshalBitsOff(bmp, bmpData, bmpPoint, bmpArray);
            MarshalBitsOff(bit1, bit1Data, bit1Point, bit1Array);
            MarshalBitsOff(bit2, bit2Data, bit2Point, bit2Array);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = PNGfilter;
            saveFileDialog1.Title = "Save PNG File";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream myStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    bmp.Save(myStream, System.Drawing.Imaging.ImageFormat.Png);
                    myStream.Close();
                }
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void PNGtoATIgo_button_Click(object sender, EventArgs e)
        {
            if (string.Compare(PNGfile.Text, " ") <= 0)
            {
                MessageBox.Show("You must select a PNG image!");
                return;
            }
            Bitmap bmp;
            using (FileStream myStream = new FileStream(PNGfile.Text, FileMode.Open, FileAccess.Read))
            {
                bmp = new Bitmap(myStream);
            }

            if ((bmp.Width % 4 > 0) | (bmp.Height % 4 > 0))
            {
                MessageBox.Show("The bitmap dimensions must be a multiple of four!");
                return;
            }

            Bitmap tmp1 = new Bitmap(bmp.Width, bmp.Height);
            Bitmap tmp2 = new Bitmap(bmp.Width, bmp.Height);

            BitmapData bmpData;
            IntPtr bmpPoint;
            byte[] bmpArray = new byte[bmp.Width * bmp.Height];
            MarshalBitsOn(bmp, out bmpData, out bmpPoint, out bmpArray);

            BitmapData tmp1Data;
            IntPtr tmp1Point;
            byte[] tmp1Array = new byte[tmp1.Width * tmp1.Height];
            MarshalBitsOn(tmp1, out tmp1Data, out tmp1Point, out tmp1Array);

            BitmapData tmp2Data;
            IntPtr tmp2Point;
            byte[] tmp2Array = new byte[tmp2.Width * tmp2.Height];
            MarshalBitsOn(tmp2, out tmp2Data, out tmp2Point, out tmp2Array);

            for (int i = 0; i < bmpArray.Length; i += 4)
            {
                int a = bmpArray[i + 3];
                int r = bmpArray[i + 2];
                int g = bmpArray[i + 1];
                int b = bmpArray[i];
                int Co = (r + (b ^ 0xff) + 1) >> 1;
                int Cg = ((((r + b + 1) >> 1) ^ 0xff) + g + 1) >> 1;
                int Y = (((r + b) >> 1) + g + 1) >> 1;

                if (Co < 0) Co = 0;
                if (Co > 255) Co = 255;
                if (Cg < 0) Cg = 0;
                if (Cg > 255) Cg = 255;
                if (Y < 0) Y = 0;
                if (Y > 255) Y = 255;

                tmp1Array[i + 3] = 255;     //alpha
                tmp1Array[i + 2] = (byte)Y; //red
                tmp1Array[i + 1] = (byte)a; //green
                tmp1Array[i] = 0;           //blue
                tmp2Array[i + 3] = 255;
                tmp2Array[i + 2] = (byte)Cg;
                tmp2Array[i + 1] = (byte)Co;
                tmp2Array[i] = 0;
            }

            MarshalBitsOff(bmp, bmpData, bmpPoint, bmpArray);
            MarshalBitsOff(tmp1, tmp1Data, tmp1Point, tmp1Array);
            MarshalBitsOff(tmp2, tmp2Data, tmp2Point, tmp2Array);

            DdsFile ati1 = new DdsFile();
            ati1.CreateImage(tmp1, false);
            ati1.UseATI = true;
            ati1.AtiMode = 2;

            DdsFile ati2 = new DdsFile();
            ati2.CreateImage(ResizeImage(tmp2, tmp2.Width / 2, tmp2.Height / 2), false);
            ati2.UseATI = true;
            ati2.AtiMode = 2;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Converted_0x00064dca";
            saveFileDialog1.Filter = DDSfilter;
            saveFileDialog1.Title = "Save DDS Files";
            saveFileDialog1.DefaultExt = "dds";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream myStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    ati1.Save(myStream);
                    myStream.Close();
                }
            }
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Converted_0x00064dc9";
            saveFileDialog1.Filter = DDSfilter;
            saveFileDialog1.Title = "Save DDS Files";
            saveFileDialog1.DefaultExt = "dds";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream myStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    ati2.Save(myStream);
                    myStream.Close();
                }
            }

        }


        public void MarshalBitsOn(Bitmap bmp, out System.Drawing.Imaging.BitmapData bitmapData, out IntPtr pointer, out byte[] argbArray)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            IntPtr ptr;
            if (bmpData.Stride > 0)
            {
                ptr = bmpData.Scan0;
            }
            else
            {
                ptr = bmpData.Scan0 + bmpData.Stride * (bmp.Height - 1);
            }

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] argbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, argbValues, 0, bytes);
            bitmapData = bmpData;
            pointer = ptr;
            argbArray = argbValues;
        }
            
        public void MarshalBitsOff(Bitmap bmp, System.Drawing.Imaging.BitmapData bitmapData, IntPtr pointer, byte[] argbValues)
        {
            System.Runtime.InteropServices.Marshal.Copy(argbValues, 0, pointer, argbValues.Length);
            bmp.UnlockBits(bitmapData);
        }
    }
}
