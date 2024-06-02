using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filtry
{
    internal class maski
    {
        public static Bitmap Maska(Bitmap originalImage, TextBox[] textBoxes, RadioButton[] radioButtons)
        {
            int[,] mask1 = new int[3, 3];
            int[,] mask2 = new int[5, 5];
            int[,] mask3 = new int[7, 7];
            bool isRadioButton1Checked = radioButtons[0].Checked; //3x3
            bool isRadioButton2Checked = radioButtons[1].Checked; //5x5
            bool isRadioButton3Checked = radioButtons[2].Checked; //7x7
            bool isRadioButton4Checked = radioButtons[3].Checked; //górnoprzepustowy
            bool isRadioButton5Checked = radioButtons[4].Checked; //dolnoprzepustowy
            bool isRadioButton6Checked = radioButtons[5].Checked; //k poziome
            bool isRadioButton7Checked = radioButtons[6].Checked; //k pionowe
            bool isRadioButton8Checked = radioButtons[7].Checked; //k ukośne
            bool isRadioButton9Checked = radioButtons[8].Checked; //k combo
            bool isRadioButton10Checked = radioButtons[9].Checked; //k medianowy
            bool isRadioButton11Checked = radioButtons[10].Checked; //k minimalny
            bool isRadioButton12Checked = radioButtons[11].Checked; //k maksymalny

            Bitmap resultImage = new Bitmap(originalImage.Width, originalImage.Height);
            Color pixel;
            int r, g, b;
            int maskSum = 0;
            if (isRadioButton1Checked)
            {

                int textBoxIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        mask1[i, j] = int.Parse(textBoxes[textBoxIndex++].Text);
                    }
                }

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
            else if (isRadioButton2Checked/*5x5*/)
            {
                int textBoxIndex = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        mask2[i, j] = int.Parse(textBoxes[textBoxIndex++].Text);
                    }
                }

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
                int textBoxIndex = 0;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        mask3[i, j] = int.Parse(textBoxes[textBoxIndex++].Text);
                    }
                }

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

    }
}
