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
        private TrackBar trackBar;
        private int currentFrame;

        public VideoPlayer(string videoPath, PictureBox pictureBox, TrackBar trackBar)
        {
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentFrame < videoFileReader.FrameCount)
            {
                trackBar.Value = currentFrame;

                var frame = videoFileReader.ReadVideoFrame();

                // Apply the filter to the frame
                ApplySepiaFilter(frame); // Replace with the desired filter method

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
        // Apply the filter to the frame
        public void ApplyFilter(Bitmap frame)
        {
            // Implement the desired filter logic here
            // ...
        }
        // Filter methods
        private void ApplySepiaFilter(Bitmap frame)
        {
            // Apply Sepia filter to the frame
            // ...
        }
    }
}

