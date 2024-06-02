using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace filtry
{
    internal class ConvertColors
    {

        public static void ConvertToHSVandYUV(TextBox textBoxR, TextBox textBoxG, TextBox textBoxB, out float[] hsv, out float[] yuv)
        {
            int r = int.Parse(textBoxR.Text);
            int g = int.Parse(textBoxG.Text);
            int b = int.Parse(textBoxB.Text);

            Color rgbColor = Color.FromArgb(r, g, b);

            hsv = new float[3];
            yuv = new float[3];

            hsv[0] = rgbColor.GetHue();
            hsv[1] = rgbColor.GetSaturation();
            hsv[2] = rgbColor.GetBrightness();

            yuv[0] = (0.299f * r) + (0.587f * g) + (0.114f * b);
            yuv[1] = (-0.14713f * r) + (-0.28886f * g) + (0.436f * b);
            yuv[2] = (0.615f * r) + (-0.51499f * g) + (-0.10001f * b);
        }

    }
}
