using System;
using System.Linq;

namespace ColourLibrary
{
    public static partial class Colour
    {
        public static HSV ToHSVFromRGB(RGB rgb)
        {
            // dividing rgb values by 255 so they are in a range of 0-1
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            // calculate max and min values of rgb
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double difference = max - min;

            double h = -1, s = -1, v = -1;

            // Calculate Hue
            if (max == min) // min and max values are equal
            {
                h = 0;
            }
            else if (max == r) // red is the max value
            {
                h = (60 * ((g - b) / difference) + 360) % 360;
            }
            else if (max == g) // green is max value
            {
                h = (60 * ((b - r) / difference) + 120) % 360;
            }
            else if (max == b) // blue is max value
            {
                h = (60 * ((r - g) / difference) + 240) % 360;
            }

            // Calculate Saturation
            if (max == 0)
            {
                s = 0;
            }
            else
            {
                s = ((difference / max) * 100);
            }

            // Calculate Value
            v = (max * 100);

            h = Math.Truncate(h);
            s = Math.Truncate(s);
            v = Math.Truncate(v);

            return new HSV(h, s, v);

        }

        public static HSV ToHSVFromHex(string hex)
        {

            RGB rgb = ToRGBFromHex(hex);
            HSV hsv = ToHSVFromRGB(rgb);

            //hex = CleanupHex(hex);

            //var h = 0.00;
            //var s = 0.00;
            //var v = 0.00;

            //if (!String.IsNullOrEmpty(hex))
            //{
            //    if (hex.Length == 3)
            //    {

            //        h = int.Parse(hex[0].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hex[1].ToString(), NumberStyles.HexNumber);
            //        s = int.Parse(hex[2].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hex[3].ToString(), NumberStyles.HexNumber);
            //        v = int.Parse(hex[4].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hex[5].ToString(), NumberStyles.HexNumber);

            //    }
            //    else if (hex.Length == 6)
            //    {
            //        h = int.Parse(hex[0].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hex[0].ToString(), NumberStyles.HexNumber);
            //        s = int.Parse(hex[1].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hex[1].ToString(), NumberStyles.HexNumber);
            //        v = int.Parse(hex[2].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hex[2].ToString(), NumberStyles.HexNumber);

            //    }

            //}       

            return new HSV
            {
                H = hsv.H,
                S = hsv.S,
                V = hsv.V
            };
        }

        public static HSL ToHSLFromHSV(HSV hsv)
        {
            double h = hsv.H;
            double s = hsv.S / 100;
            double v = hsv.V / 100;

            var _h = h;
            var _l = v - v * s / 2;
            var _s = new double[] { 0, 1 }.Contains(_l) ? 0 : (v - _l) / Math.Min(_l, 1 - _l);

            return new HSL
            {
                H = _h,
                S = _s * 100,
                L = _l * 100
            };
        }
    }
}