using System;
using System.Globalization;

namespace ColourLibrary
{
    public static partial class Colour
    {
        public static RGB ToRGBFromHex(string hex)
        {
            string hexInput = CleanupHex(hex);

            if (hex == null) throw new ArgumentNullException("Hex value is null.");

            int r, g, b;

            if (hexInput.Length == 3)
            {
                r = int.Parse(hexInput[0].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hexInput[0].ToString(), NumberStyles.HexNumber);
                g = int.Parse(hexInput[1].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hexInput[1].ToString(), NumberStyles.HexNumber);
                b = int.Parse(hexInput[2].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hexInput[2].ToString(), NumberStyles.HexNumber);

                return new RGB(r, g, b);
            }
            else if (hexInput.Length == 6)
            {
                r = int.Parse(hexInput[0].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hexInput[1].ToString(), NumberStyles.HexNumber);
                g = int.Parse(hexInput[2].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hexInput[3].ToString(), NumberStyles.HexNumber);
                b = int.Parse(hexInput[4].ToString(), NumberStyles.HexNumber) * 16 + int.Parse(hexInput[5].ToString(), NumberStyles.HexNumber);

                return new RGB(r, g, b);
            }
            else
            {
                throw new ArgumentException($"Hex value {hex} must have either 3 or 6 characters.");
            }
        }
        public static RGB ToRGBFromHSV(HSV hsv)
        {
            double h = hsv.H / 360;
            double s = hsv.S / 100;
            double v = hsv.V / 100;

            double r = 0, g = 0, b = 0, i, f, p, q, t;

            i = Math.Floor(h * 6);
            f = h * 6 - i;
            p = v * (1 - s);
            q = v * (1 - f * s);
            t = v * (1 - (1 - f) * s);
            switch (i % 6)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                case 5: r = v; g = p; b = q; break;
            }
            r = Math.Round(r * 255);
            g = Math.Round(g * 255);
            b = Math.Round(b * 255);

            return new RGB((Int32)r, (Int32)g, (Int32)b);
        }

    }
}
