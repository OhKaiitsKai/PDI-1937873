using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;


namespace PDI_1937873
{
    public partial class RT : Form
    {

        //bool Webcam;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
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
        private void button1_Click(object sender, EventArgs e)
        {
         WebCamClose();
            videoCaptureDevice = new VideoCaptureDevice
                (filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += videoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            RT_ControlRemoved();
        }
        private void videoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void RT_Load_1(object sender, EventArgs e)
        {
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

        }
    }
}
