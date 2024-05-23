﻿using System;
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

                    pictureBox2.Image = maska(oryginalImage);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
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

            Bitmap resultImage = new Bitmap(originalImage.Width, originalImage.Height);
            Color pixel;
            int r, g, b;
            int avgR, avgG, avgB;

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
                            for (int j = 0; j <= 2; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask1[i, j];
                                g += pixel.G * mask1[i, j];
                                b += pixel.B * mask1[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                            for (int j = 0; j <= 4; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (4 + i), 0), 512), Math.Min(Math.Max(y - (4 + j), 0), 512));
                                r += pixel.R * mask2[i, j];
                                g += pixel.G * mask2[i, j];
                                b += pixel.B * mask2[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                            for (int j = 0; j <= 6; j++)
                            {
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask3[i, j];
                                g += pixel.G * mask3[i, j];
                                b += pixel.B * mask3[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                    }
                }
            }
            else if (isRadioButton4Checked/*górno*/)
            {
                int[,] mask =
                {
                    {-1, -1, -1 },
                    {-1, -9, -1},
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
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
                                r += pixel.R * mask[i, j];
                                g += pixel.G * mask[i, j];
                                b += pixel.B * mask[i, j];
                            }
                        }

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
                                pixel = originalImage.GetPixel(Math.Min(Math.Max(x - (1 + i), 0), 512), Math.Min(Math.Max(y - (1 + j), 0), 512));
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

                        avgR = r / 9;
                        avgG = g / 9;
                        avgB = b / 9;

                        avgR = Math.Min(Math.Max(avgR, 0), 255);
                        avgG = Math.Min(Math.Max(avgG, 0), 255);
                        avgB = Math.Min(Math.Max(avgB, 0), 255);

                        resultImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
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
            Bitmap oryginalImage = new Bitmap(pictureBox1.Image);
            pictureBox2.Image = maska(oryginalImage);
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}