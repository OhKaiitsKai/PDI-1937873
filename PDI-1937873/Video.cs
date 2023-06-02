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
        private Func<Bitmap, Bitmap> filterFunction; // Almacena la función de filtro seleccionada
        private VideoPlayer videoPlayer;
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.wmv|All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string videoPath = openFileDialog.FileName;
                videoPlayer = new VideoPlayer(videoPath, pictureBox1, trackBar4);
                videoPlayer.OpenVideo(videoPath); // Abre el archivo de video
                videoPlayer.PlayVideo(); // Inicia la reproducción del video
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedAction = comboBox1.SelectedItem.ToString();
                switch (selectedAction)
                {
                    case "Sepia":
                        filterFunction = videoPlayer.ApplySepiaFilter; // Almacena la función de filtro
                        break;
                    case "B/N":
                        filterFunction = videoPlayer.ConvertToBlackAndWhite;
                        break;
                    case "Pixel":
                        filterFunction = videoPlayer.ApplyPixelFilter;
                        break;
                    case "Negativo":
                        filterFunction = videoPlayer.ApplyNegativeFilter;
                        break;
                    case "Binario":
                        filterFunction = videoPlayer.ApplyBinaryFilter;
                        break;
                    default:
                        filterFunction = null;
                        break;
                }

                // Asignar la función de filtro al campo FilterFunction del videoPlayer
                if (videoPlayer != null)
                {
                    videoPlayer.FilterFunction = filterFunction;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoPlayer != null && videoPlayer.FilterFunction != null)
            {
                if (videoPlayer.IsVideoOpen()) // Verificar si el archivo de video está abierto
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "AVI Video|*.avi";
                    saveFileDialog.Title = "Guardar Video";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        videoPlayer.SaveVideoWithFilter(saveFileDialog.FileName);
                        MessageBox.Show("Video guardado exitosamente.");
                    }
                }
                else
                {
                    MessageBox.Show("No se ha abierto ningún archivo de video.");
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún filtro.");
            }
        }

        private void Videos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
                videoPlayer.PlayFilteredVideo();
        }
    }
    }

