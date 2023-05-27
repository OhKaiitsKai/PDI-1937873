using Accord.Video.FFMPEG;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDI_1937873
{
    public class VideoPlayer
    {
        private VideoFileReader videoFileReader;
        private PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBar;
        private int currentFrame;
        private Func<Bitmap, Bitmap> filterFunction;
        private string videoPath;

        public VideoPlayer(string videoPath, PictureBox pictureBox, System.Windows.Forms.TrackBar trackBar)
        {
            this.videoPath = videoPath;
            this.pictureBox = pictureBox;
            this.trackBar = trackBar;

            videoFileReader = new VideoFileReader();
            videoFileReader.Open(videoPath);

            trackBar.Minimum = 0;
            trackBar.Maximum = (int)videoFileReader.FrameCount - 1;
        }

        public void PlayVideo()
        {
            Timer timer = new Timer();
            timer.Interval = (int)(1000 / videoFileReader.FrameRate);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private bool isVideoOpen = false;

        // Método para abrir el archivo de video
        public void OpenVideo(string videoFilePath)
        {
            // Código para abrir el archivo de video

            // Establecer isVideoOpen en true si el archivo se abrió correctamente
            isVideoOpen = true;
        }

        // Método para cerrar el archivo de video
        public void CloseVideo()
        {
            // Código para cerrar el archivo de video

            // Establecer isVideoOpen en false
            isVideoOpen = false;
        }

        // Método para verificar si el video está abierto
        public bool IsVideoOpen()
        {
            return isVideoOpen;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentFrame < videoFileReader.FrameCount)
            {
                trackBar.Value = currentFrame;

                var frame = videoFileReader.ReadVideoFrame();

                // Apply the selected filter function to the frame based on the selected action in the combo box
                if (filterFunction != null)
                {
                    frame = filterFunction(frame);
                }

                // Scale the frame to fit the PictureBox size
                var resizedFrame = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics graphics = Graphics.FromImage(resizedFrame))
                {
                    graphics.DrawImage(frame, 0, 0, pictureBox.Width, pictureBox.Height);
                }

                pictureBox.Image = resizedFrame;

                frame.Dispose();

                currentFrame++;
            }
            else
            {
                ((Timer)sender).Stop();
                videoFileReader.Close();
            }
        }
        public void SetFilterFunction(Func<Bitmap, Bitmap> filter)
        {
            filterFunction = filter;
        }


        public Bitmap ApplySepiaFilter(Bitmap frame)
        {
            Bitmap filteredFrame = new Bitmap(frame.Width, frame.Height);

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);

                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    // Clamp the values to ensure they are within the valid color range (0-255)
                    tr = Math.Min(255, Math.Max(0, tr));
                    tg = Math.Min(255, Math.Max(0, tg));
                    tb = Math.Min(255, Math.Max(0, tb));

                    Color newPixel = Color.FromArgb(pixel.A, tr, tg, tb);
                    filteredFrame.SetPixel(x, y, newPixel);
                }
            }

            return filteredFrame;
        }

        public Bitmap ConvertToBlackAndWhite(Bitmap frame)
        {
            Bitmap filteredFrame = new Bitmap(frame.Width, frame.Height);

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);

                    int average = (pixel.R + pixel.G + pixel.B) / 3;

                    Color newPixel = Color.FromArgb(pixel.A, average, average, average);
                    filteredFrame.SetPixel(x, y, newPixel);
                }
            }

            return filteredFrame;
        }

        public Bitmap ApplyPixelFilter(Bitmap frame)
        {
            Bitmap filteredFrame = new Bitmap(frame.Width, frame.Height);

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);

                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    int rFiltered = (r / 32) * 32;
                    int gFiltered = (g / 32) * 32;
                    int bFiltered = (b / 32) * 32;

                    Color newPixel = Color.FromArgb(pixel.A, rFiltered, gFiltered, bFiltered);
                    filteredFrame.SetPixel(x, y, newPixel);
                }
            }

            return filteredFrame;
        }

        public Bitmap ApplyNegativeFilter(Bitmap frame)
        {
            Bitmap filteredFrame = new Bitmap(frame.Width, frame.Height);

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);

                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;

                    Color newPixel = Color.FromArgb(pixel.A, r, g, b);
                    filteredFrame.SetPixel(x, y, newPixel);
                }
            }

            return filteredFrame;
        }

        public Bitmap ApplyBinaryFilter(Bitmap frame)
        {
            Bitmap filteredFrame = new Bitmap(frame.Width, frame.Height);

            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);

                    int grayValue = (pixel.R + pixel.G + pixel.B) / 3;

                    int threshold = 128;
                    Color newPixel = (grayValue >= threshold) ? Color.White : Color.Black;

                    filteredFrame.SetPixel(x, y, newPixel);
                }
            }

            return filteredFrame;
        }

        public int CurrentFrame => currentFrame;
        public int FrameCount => (int)videoFileReader.FrameCount;
        public int Width => videoFileReader.Width;
        public int Height => videoFileReader.Height;
        public double Framerate => (double)videoFileReader.FrameRate;
        public Func<Bitmap, Bitmap> FilterFunction { get; set; }

        public void Reset()
        {
            currentFrame = 0;
            videoFileReader.Close();
            videoFileReader.Open(videoPath);
        }

        public Bitmap NextFrame()
        {
            if (currentFrame < videoFileReader.FrameCount)
            {
                trackBar.Value = currentFrame;
                var frame = videoFileReader.ReadVideoFrame();
                currentFrame++;
                return frame;
            }
            return null;
        }

        public Bitmap ReadVideoFrameByFrameNumber(int frameNumber)
        {
            if (frameNumber < videoFileReader.FrameCount)
            {
                videoFileReader.Close();
                videoFileReader.Open(videoPath);
                currentFrame = frameNumber;
                return NextFrame();
            }
            return null;
        }
    }
}


