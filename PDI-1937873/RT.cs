using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PDI_1937873
{
    public partial class RT : Form
    {

        //bool Webcam;
        FilterInfoCollection filterInfoCollection; //
        VideoCaptureDevice videoCaptureDevice; //C
        public RT()
        {
            InitializeComponent();
        }
        //private void RT_Load(object sender, EventArgs e)
        //{
        //CargaDispositivos();
        //}
        // public void CargaDispositivos()
        //{
        //  MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        //if(MisDispositivos.Count > 0 ) 
        //{
        //  Webcam = true;
        // for ( int i = 0; i < MisDispositivos.Count; i++)
        //{
        //  comboBox1.Items.Add(MisDispositivos[i].Name.ToString());
        //}
        // comboBox1.Text = MisDispositivos[0].ToString();
        //}
        //else
        // {
        //   Webcam = false;
        //}
        //}
        static readonly CascadeClassifier cascadeClassifier =
            new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        private void button1_Click(object sender, EventArgs e)
        {
            //Al hacer clic en el botón, el combobox debe tener seleccionado la cámara
            WebCamClose();
            videoCaptureDevice = new VideoCaptureDevice
                (filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += videoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            RT_ControlRemoved();
        }
        private List<Rectangle> detectedFaces = new List<Rectangle>();
        private void videoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayImage = bitmap.ToImage<Bgr, byte>();
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);

            // Clear the list of detected faces
            detectedFaces.Clear();
            // Store all detected faces
            detectedFaces.AddRange(rectangles);

            // Draw rectangles for all detected faces
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    foreach (Rectangle rectangle in detectedFaces)
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }
            //foreach (Rectangle rectangle in rectangles)
            //{
            //  using (Graphics graphics = Graphics.FromImage(bitmap))
            //{
            //  using (Pen pen = new Pen(Color.Red, 1))
            //{
            //  graphics.DrawRectangle(pen, rectangle);
            //}
            //}
            //}
            pictureBox1.Image = bitmap;
            //if (pictureBox1.Image != null)
            //{
            //  pictureBox1.Image.Dispose();
            //}
            //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void RT_Load_1(object sender, EventArgs e)
        {
            //Contenido del Combobox
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);
            comboBox1.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Al hacer clic no pasará nada.
        }

        private void WebCamClose()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice = null;
            }
        }

        private void RT_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if (videoCaptureDevice.IsRunning == true)
            //   videoCaptureDevice.Stop();
            WebCamClose();
        }

        private void FiltrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se desglosa Imágenes y Vídeos
            //return 
        }

        private void ImágenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebCamClose();
            Hide();
            Imgs imgs = new Imgs();
            imgs.Show();
        }

        private void VídeosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebCamClose();
            Hide();
            Videos video = new Videos();
            video.Show();
        }

        private void RT_FormClosed(object sender, FormClosedEventArgs e)
        {
            WebCamClose();
            Application.Exit();
        }

        private void RT_ControlRemoved()
        {
            label2.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;
        }

        private void textBox1_ReadOnlyChanged(object sender, EventArgs e)
        {
            //Contador
        }
    }
}
