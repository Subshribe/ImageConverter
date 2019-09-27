using ImageClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageConverterforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            ImageClassLibrary.ImageConverter imageConverter = new ImageClassLibrary.ImageConverter();
            FileHandler importImg = new FileHandler();
            pictureBox1.Image = imageConverter.ConvertToNegative((Bitmap)pictureBox2.Image);
            pictureBox1.Name = importImg.AddSuffixToFile(openFileDialog1.FileName, "negative");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            ImageClassLibrary.ImageConverter imageConverter = new ImageClassLibrary.ImageConverter();
            FileHandler importImg = new FileHandler();
            pictureBox1.Image = imageConverter.ConvertToBlackAndWhite((Bitmap)pictureBox2.Image);
            pictureBox1.Name = importImg.AddSuffixToFile(openFileDialog1.FileName, "blackAndWhite");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ImageClassLibrary.ImageConverter imageConverter = new ImageClassLibrary.ImageConverter();
            FileHandler importImg = new FileHandler();
            pictureBox1.Image = imageConverter.ConvertToBlurred((Bitmap)pictureBox2.Image);
            pictureBox1.Name = importImg.AddSuffixToFile(openFileDialog1.FileName, "blurred");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = pictureBox1.Name;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }


        }
    }
}

