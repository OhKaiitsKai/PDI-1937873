using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.FFMPEG;

namespace PDI_1937873
{
    public partial class Videos : Form
    {
        public Videos()
        {
            InitializeComponent();
        }

        private void imágenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Imgs imgs = new Imgs();
            imgs.Show();
        }

        private void contarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            RT mainRT = new RT();
            mainRT.Show();
        }

        private void Videos_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Sepia");
            comboBox1.Items.Add("B/N");
            comboBox1.Items.Add("Pixel");
            comboBox1.Items.Add("Negativo");
            comboBox1.Items.Add("Binario");
            comboBox1.SelectedIndex = -1;
        }
        private VideoPlayer videoPlayer;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.wmv|All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string videoPath = openFileDialog.FileName;
                videoPlayer = new VideoPlayer(videoPath, pictureBox1, trackBar4);
                videoPlayer.PlayVideo();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = comboBox1.SelectedItem.ToString();
            switch (selectedAction)
            {
                case "Sepia":
                    ApplyFilter(ApplySepiaFilter);
                    break;
                case "B/N":
                    ApplyFilter(ConvertToBlackAndWhite);
                    break;
                case "Pixel":
                    ApplyFilter(ApplyPixelFilter);
                    break;
                case "Negativo":
                    ApplyFilter(ApplyNegativeFilter);
                    break;
                case "Binario":
                    ApplyFilter(ApplyBinaryFilter);
                    break;
                default: break;
            }
        }
        private void ApplyFilter(Action<Bitmap> filterAction)
        {
            if (videoPlayer != null)
            {
                //videoPlayer.ApplyFilter(filterAction);
            }
        }
        private void ApplySepiaFilter(Bitmap frame)
        {
            // Apply Sepia filter to the frame
            // ...
        }

        private void ConvertToBlackAndWhite(Bitmap frame)
        {
            // Convert the frame to black and white
            // ...
        }

        private void ApplyPixelFilter(Bitmap frame)
        {
            // Apply a pixel filter to the frame
            // ...
        }

        private void ApplyNegativeFilter(Bitmap frame)
        {
            // Apply a negative filter to the frame
            // ...
        }

        private void ApplyBinaryFilter(Bitmap frame)
        {
            // Apply a binary filter to the frame
            // ...
        }
    }
}
