using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace filtry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Legends.Clear();
        }
        private void loadPictures()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micha\\Pictures\\test_images";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png| All files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Bitmap oryginalImage = new Bitmap(filePath);

                    pictureBox1.Image = oryginalImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            loadPictures();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (pictureBox1.Image != null)
            {
                Bitmap oryginalImage = new Bitmap(pictureBox1.Image);
                
                Bitmap originalImage = (Bitmap)pictureBox1.Image;
                TextBox[] textBoxes = {
                textBox7, textBox8, textBox9,
                textBox4, textBox5, textBox6,
                textBox1, textBox2, textBox3,
                textBox30, textBox31, textBox32, textBox33, textBox34,
                textBox25, textBox26, textBox27, textBox28, textBox29,
                textBox20, textBox21, textBox22, textBox23, textBox24,
                textBox15, textBox16, textBox17, textBox18, textBox19,
                textBox10, textBox11, textBox12, textBox13, textBox14,
                textBox83, textBox82, textBox81, textBox80, textBox79, textBox78, textBox77,
                textBox76, textBox75, textBox74, textBox73, textBox72, textBox71, textBox70,
                textBox69, textBox68, textBox67, textBox66, textBox65, textBox64, textBox63,
                textBox62, textBox61, textBox60, textBox59, textBox58, textBox57, textBox56,
                textBox55, textBox54, textBox53, textBox52, textBox51, textBox50, textBox49,
                textBox48, textBox47, textBox46, textBox45, textBox44, textBox43, textBox42,
                textBox35, textBox36, textBox37, textBox38, textBox39, textBox40, textBox41
                };

                RadioButton[] radioButtons = { radioButton1, radioButton2, radioButton3, radioButton4, radioButton5, radioButton6, radioButton7, radioButton8, radioButton9, radioButton10, radioButton11, radioButton12};

                pictureBox2.Image = maski.Maska(originalImage, textBoxes, radioButtons);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Wybierz obrazek przed filtracją!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micha\\Pictures\\test_images";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png| All files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Bitmap image = new Bitmap(filePath);

                    pictureBox3.Image = image;
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micha\\Pictures\\test_images";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png| All files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Bitmap image = new Bitmap(filePath);

                    pictureBox4.Image = image;
                    pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null && pictureBox4.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox3.Image);
                Bitmap subtractedImage = new Bitmap(pictureBox4.Image);
                int width = Math.Min(originalImage.Width, subtractedImage.Width);
                int height = Math.Min(originalImage.Height, subtractedImage.Height);

                Bitmap resultImage = new Bitmap(width, height);

                int shiftX = 0;
                int shiftY = 0;

                if (radioButton18.Checked)
                {
                    shiftX = 1; 
                }
                else if (radioButton19.Checked)
                {
                    shiftY = 1; 
                }
                else if (radioButton20.Checked)
                {
                    shiftX = 1; 
                    shiftY = 1;
                }

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color originalColor = originalImage.GetPixel(x, y);

                        int shiftedX = x + shiftX;
                        int shiftedY = y + shiftY;

                        if (shiftedX >= width) shiftedX = width - 1;
                        if (shiftedY >= height) shiftedY = height - 1;

                        Color subtractedColor = subtractedImage.GetPixel(shiftedX, shiftedY);

                        int grayOriginal = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                        int graySubtracted = (int)((subtractedColor.R * 0.3) + (subtractedColor.G * 0.59) + (subtractedColor.B * 0.11));

                        int difference = grayOriginal - graySubtracted;
                        difference = Math.Max(0, difference); // Clamp negative values to 0

                        Color resultColor = Color.FromArgb(difference, difference, difference);
                        resultImage.SetPixel(x, y, resultColor);
                    }
                }

                pictureBox5.Image = resultImage;
                pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Wczytaj oba obrazy przed odejmowaniem!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micha\\Pictures\\test_images";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png| All files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Bitmap image = new Bitmap(filePath);

                    pictureBox6.Image = image;
                    pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Image == null)
            {
                MessageBox.Show("Wczytaj obraz przed zastosowaniem progowania!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap image = new Bitmap(pictureBox6.Image);

            int thresholdMin = 0;
            int thresholdMax = 255;

            if (radioButton13.Checked) // Prog automatyczny
            {
                thresholdMin = 128;
                thresholdMax = 128;
            }
            else if (radioButton15.Checked) // Prog z textboxa84
            {
                if (!int.TryParse(textBox84.Text, out thresholdMin))
                {
                    MessageBox.Show("Nieprawidłowa wartość progu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thresholdMax = thresholdMin;
            }
            else if (radioButton14.Checked) // Progi z textboxa85 i textboxa86
            {
                if (!int.TryParse(textBox85.Text, out thresholdMin) || !int.TryParse(textBox86.Text, out thresholdMax))
                {
                    MessageBox.Show("Nieprawidłowa wartość progu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ApplyThresholding(image, thresholdMin, thresholdMax);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.Image = image;
            
        }
        private void ApplyThresholding(Bitmap image, int minThreshold, int maxThreshold)
        {
            Color white = Color.White;
            Color black = Color.Black;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayValue = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));

                    if (grayValue >= minThreshold && grayValue <= maxThreshold)
                    {
                        image.SetPixel(x, y, white);
                    }
                    else
                    {
                        image.SetPixel(x, y, black);
                    }
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micha\\Pictures\\test_images";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png| All files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Bitmap image = new Bitmap(filePath);

                    pictureBox8.Image = image;
                    pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (pictureBox8.Image != null)
            {
                Bitmap image = new Bitmap(pictureBox8.Image);
                if (radioButton16.Checked)
                {
                    Gray1(image);
                }
                else if (radioButton17.Checked)
                {
                    Gray2(image);
                }

                int[] histogram = new int[256];

                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color pixel = image.GetPixel(x, y);
                        int grayValue = (int)((pixel.R * 0.299) + (pixel.G * 0.587) + (pixel.B * 0.114));
                        histogram[grayValue]++;
                    }
                }

                chart1.Series[0].Points.Clear();

                for (int i = 0; i < 256; i++)
                {
                    chart1.Series[0].Points.AddXY(i, histogram[i]);
                }

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = 255;
                chart1.ChartAreas[0].AxisY.Minimum = 0;

                chart1.Invalidate();

                pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox9.Image = image;
            }
            else
            {
                MessageBox.Show("Wczytaj obrazek przed przeliczaniem szarości!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void Gray1(Bitmap image)
        {
            for (int x = 0; x< image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayValue = (int)((pixel.R * 0.299) + (pixel.G * 0.587) + (pixel.B * 0.114));
                    image.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }
        }
        private void Gray2(Bitmap image)
        {
            for(int x = 0; x < image.Width; x++)
            {
                for(int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayValue = (int)((pixel.R + pixel.G + pixel.B) / 3);
                    image.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }
        }
        
        
        
        //w pliku ConvertColors.cs
        private void button10_Click(object sender, EventArgs e)
        {
            float[] hsvValues;
            float[] yuvValues;

            ConvertColors.ConvertToHSVandYUV(textBox87, textBox88, textBox89, out hsvValues, out yuvValues);

            textBox90.Text = string.Format("{0:0.######}", hsvValues[0]);
            textBox91.Text = string.Format("{0:0.######}", hsvValues[1]);
            textBox92.Text = string.Format("{0:0.######}", hsvValues[2]);

            textBox93.Text = string.Format("{0:0.######}", yuvValues[0]);
            textBox94.Text = string.Format("{0:0.######}", yuvValues[1]);
            textBox95.Text = string.Format("{0:0.######}", yuvValues[2]);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\micha\\Pictures\\test_images";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png| All files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Bitmap image = new Bitmap(filePath);

                    pictureBox10.Image = image;
                    pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void ColorChannelsFilter()
        {
            Bitmap originalImage = (Bitmap)pictureBox10.Image;

            if (originalImage != null)
            {
                // Utwórz kopię oryginalnego obrazu
                Bitmap filteredImage = new Bitmap(originalImage);

                // Sprawdź, które kanały koloru mają być wyłączone
                bool disableRed = checkBox1.Checked;
                bool disableGreen = checkBox2.Checked;
                bool disableBlue = checkBox3.Checked;

                for (int y = 0; y < filteredImage.Height; y++)
                {
                    for (int x = 0; x < filteredImage.Width; x++)
                    {
                        Color pixel = filteredImage.GetPixel(x, y);
                        Color newPixel = Color.FromArgb(
                            disableRed ? 0 : pixel.R,
                            disableGreen ? 0 : pixel.G,
                            disableBlue ? 0 : pixel.B
                        );
                        filteredImage.SetPixel(x, y, newPixel);
                    }
                }

                pictureBox11.Image = filteredImage;
                pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox11.Refresh();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ColorChannelsFilter();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ColorChannelsFilter();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ColorChannelsFilter();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.FileName = "filtered_image.jpg";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox11.Image != null)
                    {
                        pictureBox11.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
        }
    }
}
