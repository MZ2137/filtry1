using System;
using System.Drawing;
using System.Windows.Forms;

namespace filtry
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private Bitmap maska(Bitmap originalImage)
        {
            int[,] mask1 = new int[3, 3];
            int[,] mask2 = new int[5, 5];
            int[,] mask3 = new int[7, 7];
            bool isRadioButton1Checked = radioButton1.Checked; //3x3
            bool isRadioButton2Checked = radioButton2.Checked; //5x5
            bool isRadioButton3Checked = radioButton3.Checked; //7x7
            bool isRadioButton4Checked = radioButton4.Checked; //górnoprzepustowy
            bool isRadioButton5Checked = radioButton5.Checked; //dolnoprzepustowy
            bool isRadioButton6Checked = radioButton6.Checked; //k poziome
            bool isRadioButton7Checked = radioButton7.Checked; //k pionowe
            bool isRadioButton8Checked = radioButton8.Checked; //k ukośne
            bool isRadioButton9Checked = radioButton9.Checked; //k combo
            bool isRadioButton10Checked = radioButton10.Checked; //k medianowy
            bool isRadioButton11Checked = radioButton11.Checked; //k minimalny
            bool isRadioButton12Checked = radioButton12.Checked; //k maksymalny

            Bitmap resultImage = new Bitmap(originalImage.Width, originalImage.Height);
            Color pixel;
            int r, g, b;
            int maskSum = 0;

            if (isRadioButton1Checked)
            {
                
                mask1[0, 0] = int.Parse(textBox7.Text);
                mask1[0, 1] = int.Parse(textBox8.Text);
                mask1[0, 2] = int.Parse(textBox9.Text);
                mask1[1, 0] = int.Parse(textBox4.Text);
                mask1[1, 1] = int.Parse(textBox5.Text);
                mask1[1, 2] = int.Parse(textBox6.Text);
                mask1[2, 0] = int.Parse(textBox1.Text);
                mask1[2, 1] = int.Parse(textBox2.Text);
                mask1[2, 2] = int.Parse(textBox3.Text);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            maskSum = 0;
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                //dla pixela 0x0, 0 - (1 + 0) teoretycznie wychodzi poza zakres
                                //ale Math.Min i Math.Max o wartościach od 0 do originalImage.Width/Height powiela piksele graniczne
                                r += pixel.R * mask1[i, j];
                                g += pixel.G * mask1[i, j];
                                b += pixel.B * mask1[i, j];
                                maskSum += mask1[i, j];
                            }
                        }
                        //normalizacja dla nietypowych filtrów
                        if(maskSum != 0)
                        {
                            r /= maskSum;
                            g /= maskSum;
                            b /= maskSum;
                        }
                        

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton2Checked/*5x5*/)
            {
                mask2[0, 0] = int.Parse(textBox30.Text);
                mask2[0, 1] = int.Parse(textBox31.Text);
                mask2[0, 2] = int.Parse(textBox32.Text);
                mask2[0, 3] = int.Parse(textBox33.Text);
                mask2[0, 4] = int.Parse(textBox34.Text);
                mask2[1, 0] = int.Parse(textBox25.Text);
                mask2[1, 1] = int.Parse(textBox26.Text);
                mask2[1, 2] = int.Parse(textBox27.Text);
                mask2[1, 3] = int.Parse(textBox28.Text);
                mask2[1, 4] = int.Parse(textBox29.Text);
                mask2[2, 0] = int.Parse(textBox20.Text);
                mask2[2, 1] = int.Parse(textBox21.Text);
                mask2[2, 2] = int.Parse(textBox22.Text);
                mask2[2, 3] = int.Parse(textBox23.Text);
                mask2[2, 4] = int.Parse(textBox24.Text);
                mask2[3, 0] = int.Parse(textBox15.Text);
                mask2[3, 1] = int.Parse(textBox16.Text);
                mask2[3, 2] = int.Parse(textBox17.Text);
                mask2[3, 3] = int.Parse(textBox18.Text);
                mask2[3, 4] = int.Parse(textBox19.Text);
                mask2[4, 0] = int.Parse(textBox10.Text);
                mask2[4, 1] = int.Parse(textBox11.Text);
                mask2[4, 2] = int.Parse(textBox12.Text);
                mask2[4, 3] = int.Parse(textBox13.Text);
                mask2[4, 4] = int.Parse(textBox14.Text);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {

                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 4; i++)
                        {
                            maskSum = 0;
                            for (int j = 0; j <= 4; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask2[i, j];
                                g += pixel.G * mask2[i, j];
                                b += pixel.B * mask2[i, j];
                                maskSum += mask2[i, j];
                            }
                        }

                        if (maskSum != 0)
                        {
                            r /= maskSum;
                            g /= maskSum;
                            b /= maskSum;
                        }

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton3Checked/*7x7*/)
            {
                mask3[0, 0] = int.Parse(textBox83.Text);
                mask3[0, 1] = int.Parse(textBox82.Text);
                mask3[0, 2] = int.Parse(textBox81.Text);
                mask3[0, 3] = int.Parse(textBox80.Text);
                mask3[0, 4] = int.Parse(textBox79.Text);
                mask3[0, 5] = int.Parse(textBox78.Text);
                mask3[0, 6] = int.Parse(textBox77.Text);

                mask3[1, 0] = int.Parse(textBox76.Text);
                mask3[1, 1] = int.Parse(textBox75.Text);
                mask3[1, 2] = int.Parse(textBox74.Text);
                mask3[1, 3] = int.Parse(textBox73.Text);
                mask3[1, 4] = int.Parse(textBox72.Text);
                mask3[1, 5] = int.Parse(textBox71.Text);
                mask3[1, 6] = int.Parse(textBox70.Text);

                mask3[2, 0] = int.Parse(textBox69.Text);
                mask3[2, 1] = int.Parse(textBox68.Text);
                mask3[2, 2] = int.Parse(textBox67.Text);
                mask3[2, 3] = int.Parse(textBox66.Text);
                mask3[2, 4] = int.Parse(textBox65.Text);
                mask3[2, 5] = int.Parse(textBox64.Text);
                mask3[2, 6] = int.Parse(textBox63.Text);

                mask3[3, 0] = int.Parse(textBox62.Text);
                mask3[3, 1] = int.Parse(textBox61.Text);
                mask3[3, 2] = int.Parse(textBox60.Text);
                mask3[3, 3] = int.Parse(textBox59.Text);
                mask3[3, 4] = int.Parse(textBox58.Text);
                mask3[3, 5] = int.Parse(textBox57.Text);
                mask3[3, 6] = int.Parse(textBox56.Text);

                mask3[4, 0] = int.Parse(textBox55.Text);
                mask3[4, 1] = int.Parse(textBox54.Text);
                mask3[4, 2] = int.Parse(textBox53.Text);
                mask3[4, 3] = int.Parse(textBox52.Text);
                mask3[4, 4] = int.Parse(textBox51.Text);
                mask3[4, 5] = int.Parse(textBox50.Text);
                mask3[4, 6] = int.Parse(textBox49.Text);

                mask3[5, 0] = int.Parse(textBox48.Text);
                mask3[5, 1] = int.Parse(textBox47.Text);
                mask3[5, 2] = int.Parse(textBox46.Text);
                mask3[5, 3] = int.Parse(textBox45.Text);
                mask3[5, 4] = int.Parse(textBox44.Text);
                mask3[5, 5] = int.Parse(textBox43.Text);
                mask3[5, 6] = int.Parse(textBox42.Text);

                mask3[6, 0] = int.Parse(textBox35.Text);
                mask3[6, 1] = int.Parse(textBox36.Text);
                mask3[6, 2] = int.Parse(textBox37.Text);
                mask3[6, 3] = int.Parse(textBox38.Text);
                mask3[6, 4] = int.Parse(textBox39.Text);
                mask3[6, 5] = int.Parse(textBox40.Text);
                mask3[6, 6] = int.Parse(textBox41.Text);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {

                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 6; i++)
                        {
                            maskSum = 0;
                            for (int j = 0; j <= 6; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask3[i, j];
                                g += pixel.G * mask3[i, j];
                                b += pixel.B * mask3[i, j];
                                maskSum += mask3[i, j];
                            }
                        }

                        if (maskSum != 0)
                        {
                            r /= maskSum;
                            g /= maskSum;
                            b /= maskSum;
                        }

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton4Checked/*górno*/)
            {
                int[,] mask =
                {
                    {-1, -1, -1},
                    {-1, 9, -1},
                    {-1, -1, 1},
                };

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton5Checked/*dolno*/)
            {
                int[,] mask =
                {
                    {1, 1, 1},
                    {1, 1, 1},
                    {1, 1, 1},
                };

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        r /= 9;
                        g /= 9;
                        b /= 9;

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton6Checked/*poziomy*/)
            {
                int[,] mask =
                {
                    {0, 0, 0},
                    {-1, 1, 0},
                    {0, 0, 0},
                };

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton7Checked/*pionowy*/)
            {
                int[,] mask =
                {
                    {0, -1, 0},
                    {0, 1, 0},
                    {0, 0, 0},
                };

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton8Checked/*ukośny*/)
            {
                int[,] mask =
                {
                    {-1, 0, 0},
                    {0, 1, 0},
                    {0, 0, 0},
                };

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            else if (isRadioButton9Checked/*combo*/)
            {
                int[,] maskX =
                {
                    {0, 0, 0},
                    {-1, 1, 0},
                    {0, 0, 0},
                };
                int[,] maskY =
                {
                    {0, -1, 0},
                    {0, 1, 0},
                    {0, 0, 0},
                };
                int[,] maskXY =
                {
                    {-1, 0, 0},
                    {0, 1, 0},
                    {0, 0, 0},
                };

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        r = 0; g = 0; b = 0;

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), originalImage.Width), Math.Min(Math.Max(y - (1 + j), 0), originalImage.Height));
                                r += pixel.R * maskX[i, j];
                                g += pixel.G * maskX[i, j];
                                b += pixel.B * maskX[i, j];
                                r += pixel.R * maskY[i, j];
                                g += pixel.G * maskY[i, j];
                                b += pixel.B * maskY[i, j];
                                r += pixel.R * maskXY[i, j];
                                g += pixel.G * maskXY[i, j];
                                b += pixel.B * maskXY[i, j];
                            }
                        }


                        r = Math.Min(Math.Max(r, 0), 255);
                        g = Math.Min(Math.Max(g, 0), 255);
                        b = Math.Min(Math.Max(b, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
            }
            //trochę inne podejście do granicy obrazu w przykładzie 10, 11 i 12, ale rónież powiela piksele z kranca zakresu
            else if (isRadioButton10Checked/*mediana*/)
            {
                int[] redValues = new int[9];
                int[] greenValues = new int[9];
                int[] blueValues = new int[9];

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        int index = 0;
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int newX = Math.Min(Math.Max(x + i, 0), originalImage.Width - 1);
                                int newY = Math.Min(Math.Max(y + j, 0), originalImage.Height - 1);
                                pixel = originalImage.GetPixel(newX, newY);
                                redValues[index] = pixel.R;
                                greenValues[index] = pixel.G;
                                blueValues[index] = pixel.B;
                                index++;
                            }
                        }

                        Array.Sort(redValues);
                        Array.Sort(greenValues);
                        Array.Sort(blueValues);

                        int medianR = redValues[4];
                        int medianG = greenValues[4];
                        int medianB = blueValues[4];

                        resultImage.SetPixel(x, y, Color.FromArgb(medianR, medianG, medianB));
                    }
                }
            }
            else if (isRadioButton11Checked/*minimum*/)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        int minR = 255, minG = 255, minB = 255;

                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int newX = Math.Min(Math.Max(x + i, 0), originalImage.Width - 1);
                                int newY = Math.Min(Math.Max(y + j, 0), originalImage.Height - 1);
                                pixel = originalImage.GetPixel(newX, newY);
                                minR = Math.Min(minR, pixel.R);
                                minG = Math.Min(minG, pixel.G);
                                minB = Math.Min(minB, pixel.B);
                            }
                        }

                        resultImage.SetPixel(x, y, Color.FromArgb(minR, minG, minB));
                    }
                }
            }
            else if (isRadioButton12Checked/*maksimum*/)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        int maxR = 0, maxG = 0, maxB = 0;

                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int newX = Math.Min(Math.Max(x + i, 0), originalImage.Width - 1);
                                int newY = Math.Min(Math.Max(y + j, 0), originalImage.Height - 1);
                                pixel = originalImage.GetPixel(newX, newY);
                                maxR = Math.Max(maxR, pixel.R);
                                maxG = Math.Max(maxG, pixel.G);
                                maxB = Math.Max(maxB, pixel.B);
                            }
                        }

                        resultImage.SetPixel(x, y, Color.FromArgb(maxR, maxG, maxB));
                    }
                }
            }


            return resultImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadPictures();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (pictureBox1.Image != null)
            {
                Bitmap oryginalImage = new Bitmap(pictureBox1.Image);
                pictureBox2.Image = maska(oryginalImage);
            }
            else
            {
                MessageBox.Show("Nie wybrano obrazka!");
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

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

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color originalColor = originalImage.GetPixel(x, y);
                        Color subtractedColor = subtractedImage.GetPixel(x, y);

                        int grayOriginal = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                        int graySubtracted = (int)((subtractedColor.R * 0.3) + (subtractedColor.G * 0.59) + (subtractedColor.B * 0.11));

                        int difference = grayOriginal - graySubtracted;
                        difference = Math.Max(0, difference); //łapanie wartości ujemnych

                        Color resultColor = Color.FromArgb(difference, difference, difference);
                        resultImage.SetPixel(x, y, resultColor);
                    }
                }

                pictureBox5.Image = resultImage;
                pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Nie wybrano obrazków");
            }
        }

    }
}