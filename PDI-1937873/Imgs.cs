using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace PDI_1937873
{
    public partial class Imgs : Form
    {
        public Imgs()
        {
            InitializeComponent();
        }

        private void contarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            RT mainRT = new RT();
            mainRT.Show();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Videos video = new Videos();
            video.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Formatos de imagen
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Select an Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Obtiene la imagen
                string imagePath = openFileDialog1.FileName;

                // Carga la imagen y lo muestra
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Imgs_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Sepia");
            comboBox1.Items.Add("B/N");
            comboBox1.Items.Add("Pixel");
            comboBox1.Items.Add("Negativo");
            comboBox1.Items.Add("Binario");
            comboBox1.SelectedIndex = -1;
            //GetRGBValuesFromImage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = comboBox1.SelectedItem.ToString();
            switch (selectedAction)
            {
                case "Sepia":
                    ApplySepiaFilter();
                    break;
                case "B/N":
                    ConvertToBlackAndWhite();
                    break;
                case "Pixel":
                    ApplyPixelFilter();
                    break;
                case "Negativo":
                    ApplyNegativeFilter();
                    break;
                case "Binario":
                    ApplyBinaryFilter();
                    break;
                default: break;
            }
        }

        private void ApplyBinaryFilter()
        {
            // Verificar si hay una imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Suba una imagen.");
                return;
            }

            // Crea una copia de la imagen original
            Image originalImage = pictureBox1.Image;
            Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Aplica el filtro
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = ((Bitmap)originalImage).GetPixel(x, y);

                    // Aplica el filtro
                    Color filteredColor = ApplyBinaryFilterToColor(originalColor);

                    filteredImage.SetPixel(x, y, filteredColor);
                }
            }

            // Muestra la imagen con el filtro aplicado
            pictureBox2.Image = filteredImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            // RGB
            GetRGBValuesFromImage();
        }
        private Color ApplyBinaryFilterToColor(Color color)
        {
            // Convierte el color en Escala de grises
            int grayScale = (color.R + color.G + color.B) / 3;

            // Aplica el binario thresholding
            int threshold = 128;
            int binaryValue = grayScale < threshold ? 0 : 255;

            return Color.FromArgb(binaryValue, binaryValue, binaryValue);
        }
        private void ApplyNegativeFilter()
        {
            // Verificar si hay una imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Suba una imagen.");
                return;
            }

            // Crea una copia de la imagen original
            Image originalImage = pictureBox1.Image;
            Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Aplica el filtro
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = ((Bitmap)originalImage).GetPixel(x, y);

                    // Aplica el filtro
                    Color filteredColor = ApplyNegativeFilterToColor(originalColor);

                    filteredImage.SetPixel(x, y, filteredColor);
                }
            }

            // Muestra la imagen con el filtro aplicado
            pictureBox2.Image = filteredImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            // RGB
            GetRGBValuesFromImage();
        }
        private Color ApplyNegativeFilterToColor(Color color)
        {
            // Colores inversos
            int r = 255 - color.R;
            int g = 255 - color.G;
            int b = 255 - color.B;

            return Color.FromArgb(r, g, b);
        }
        private void ApplyPixelFilter()
        {
            // Check if an image is loaded in pictureBox1
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Suba una imagen.");
                return;
            }

            // Create una copia de la imagen original
            Image originalImage = pictureBox1.Image;
            Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Aplica el filtro
            using (Graphics graphics = Graphics.FromImage(filteredImage))
            {
                int pixelSize = 10; // Adjust this value to control the pixelation effect

                // Calculate the dimensions of the scaled-down image
                int newWidth = originalImage.Width / pixelSize;
                int newHeight = originalImage.Height / pixelSize;

                // Create a scaled-down version of the original image
                Image scaledImage = new Bitmap(newWidth, newHeight);
                using (Graphics scaledGraphics = Graphics.FromImage(scaledImage))
                {
                    scaledGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    scaledGraphics.DrawImage(originalImage, new Rectangle(0, 0, newWidth, newHeight));
                }

                // Draw the scaled-down image onto the filtered image with pixelation effect
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                graphics.DrawImage(scaledImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height));
            }

            // Muestra la imagen con el filtro aplicado
            pictureBox2.Image = filteredImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            // RGB
            GetRGBValuesFromImage();
        }

        private void ConvertToBlackAndWhite()
        {
            // Verificar si hay una imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Suba una imagen.");
                return;
            }

            // Crea una copia de la imagen original
            Image originalImage = pictureBox1.Image;
            Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Aplica el filtro
            using (Graphics graphics = Graphics.FromImage(filteredImage))
            {
                // Crea una escala de grises color matrix
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
                    }
                );

                // Create un atributo a la imagen con escala de grises color matrix
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                // Dibuja en la imagen original con el atributo de escala de grises
                graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
            }

            // Muestra la imagen con el filtro aplicado
            pictureBox2.Image = filteredImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            // RGB
            GetRGBValuesFromImage();
        }

        private void ApplySepiaFilter()
        {
            // Verificar si hay una imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Suba una imagen.");
                return;
            }

            // Crea una copia de la imagen original
            Image originalImage = pictureBox1.Image;
            Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Aplica el filtro
            using (Graphics graphics = Graphics.FromImage(filteredImage))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                new float[] {0.393f, 0.349f, 0.272f, 0, 0},
                new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                new float[] {0.189f, 0.168f, 0.131f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
                    }
                );

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
            }

            // Muestra la imagen con el filtro aplicado
            pictureBox2.Image = filteredImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            // RGB
            GetRGBValuesFromImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica si hay foto
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No hay imagen disponible.");
                return;
            }

            // Abre para guardar imagen
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
            saveDialog.Title = "Save Filtered Image";
            saveDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveDialog.FileName))
            {
                try
                {
                    // Guarda la imagen con el filtro aplicado
                    pictureBox2.Image.Save(saveDialog.FileName);
                    MessageBox.Show("Imagen guardada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Un error ha ocurrido al guardar " + ex.Message);
                }
            }
        }
        private void GetRGBValuesFromImage()
        {
            // Comprueba si hay una imagen
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No hay imagen disponible.");
                return;
            }

            // Obtiene el color de pixeles
            int pixelX = 0; // X-coordenada del pixel
            int pixelY = 0; // Y-coordenada del pixel
            Color pixelColor = ((Bitmap)pictureBox2.Image).GetPixel(pixelX, pixelY);

            // Actualiza
            int r = pixelColor.R;
            int g = pixelColor.G;
            int b = pixelColor.B;

            // Ensure that the values are within the valid range
            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            trackBar1.Minimum = 0;
            trackBar1.Maximum = 255;
            trackBar1.Value = r;

            trackBar2.Minimum = 0;
            trackBar2.Maximum = 255;
            trackBar2.Value = g;

            trackBar3.Minimum = 0;
            trackBar3.Maximum = 255;
            trackBar3.Value = b;

            textBox1.Text = r.ToString();
            textBox2.Text = g.ToString();
            textBox3.Text = b.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verificar si hay una imagen cargada en pictureBox2
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No hay imagen disponible.");
                return;
            }

            // Crear un objeto Bitmap a partir de la imagen en pictureBox2
            Bitmap image = new Bitmap(pictureBox2.Image);

            // Crear una lista para almacenar los valores de intensidad de cada componente de color (R, G, B)
            List<int>[] colorValues = new List<int>[3];
            for (int i = 0; i < 3; i++)
            {
                colorValues[i] = new List<int>();
            }

            // Recorrer cada píxel de la imagen y almacenar los valores de intensidad en la lista correspondiente
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    colorValues[0].Add(pixelColor.R); // Componente Rojo
                    colorValues[1].Add(pixelColor.G); // Componente Verde
                    colorValues[2].Add(pixelColor.B); // Componente Azul
                }
            }

            // Crear una instancia de ZedGraph
            ZedGraphControl zedGraphControl = new ZedGraphControl();
            zedGraphControl.Width = 800;
            zedGraphControl.Height = 400;

            // Crear un objeto GraphPane para configurar el gráfico
            GraphPane graphPane = zedGraphControl.GraphPane;
            graphPane.Title.Text = "Histograma de Color";
            graphPane.XAxis.Title.Text = "Valor de Intensidad";
            graphPane.YAxis.Title.Text = "Frecuencia";

            // Crear objetos PointPairList para almacenar los puntos del histograma de cada componente de color
            PointPairList[] pointPairLists = new PointPairList[3];
            for (int i = 0; i < 3; i++)
            {
                pointPairLists[i] = new PointPairList();
            }

            // Calcular la frecuencia de cada valor de intensidad y agregarlos a los PointPairList correspondientes
            for (int i = 0; i < 3; i++)
            {
                int[] histogram = new int[256]; // Histograma con 256 bins (valores de intensidad)
                foreach (int value in colorValues[i])
                {
                    histogram[value]++;
                }
                for (int j = 0; j < 256; j++)
                {
                    pointPairLists[i].Add(j, histogram[j]);
                }
            }

            // Agregar curvas al gráfico para cada componente de color
            LineItem[] lineItems = new LineItem[3];
            string[] colorNames = { "Rojo", "Verde", "Azul" };
            for (int i = 0; i < 3; i++)
            {
                lineItems[i] = graphPane.AddCurve(colorNames[i], pointPairLists[i], Color.Red, SymbolType.None);
            }

            // Mostrar el gráfico en un formulario
            Form graphForm = new Form();
            graphForm.Width = zedGraphControl.Width;
            graphForm.Height = zedGraphControl.Height;
            graphForm.Controls.Add(zedGraphControl);
            graphForm.ShowDialog();
        }
    }
}
