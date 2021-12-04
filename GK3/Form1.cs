using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace GK3
{
    public partial class Form1 : Form
    {
        public static Form1 form;
        Octree tree;
        GreyScaleMaker greyscale;
        int reduceColorNum = 8;

        public Form1()
        {
            InitializeComponent();
            mainPicture.Image = Image.FromFile("..//..//..//images//toucan.png");
            reduceButton.Text = "Reduce To " + reduceColorNum.ToString() + " Colors";
            form = this;
            tree = new Octree();
            greyscale = new GreyScaleMaker();
        }

        private void colorsTrackBar_Scroll(object sender, EventArgs e)
        {
            reduceColorNum = ((TrackBar)sender).Value;
            reduceButton.Text = "Reduce To " + reduceColorNum.ToString() + " Colors";
        }

        private void reduceButton_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

            tree = new Octree();
            tree.BuildTree((Bitmap)mainPicture.Image);
            tree.Reduce(reduceColorNum - 1, false);
            Bitmap after = tree.RecreateImageFromOctree((Bitmap)mainPicture.Image);
            afterPicture.Image = after;

            Refresh();

            tree = new Octree();
            tree.BuildTreeWithReducing((Bitmap)mainPicture.Image, reduceColorNum);
            Bitmap along = tree.RecreateImageFromOctree((Bitmap)mainPicture.Image);
            alongPicture.Image = along;

            Thread.Sleep(100);
            afterProgress.Value = 100;
            alongProgress.Value = 100;
            Refresh();

        }
        public delegate void RefreshSlider();
        public static void UpdateProgressAfter()
        {
            form.afterProgress.Value = (int)(form.tree.Progress * 100);
        }
        public static void UpdateProgressAlong()
        {
            form.alongProgress.Value = (int)(form.tree.Progress * 100); 
        }

        private void grayscaleButton_Click(object sender, EventArgs e)
        {
            Bitmap grey = greyscale.CreateGreyscaleImage((Bitmap)mainPicture.Image);
            mainPicture.Image = (Image)grey;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var image = Image.FromFile(openFileDialog.FileName);
                    mainPicture.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = ".jpeg";
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                afterPicture.Image.Save(saveFileDialog1.FileName);
            }
        }
    }
}
