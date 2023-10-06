using System;
using System.Collections.Generic;
using System.Text;

namespace ColourLibrary
{
    public static partial class Colour
    {
        /// <summary>
        /// Formulas: R/16 = x + y/16.
        /// G/16 = x' + y'/16.
        /// B/16 = x'' + y''/16.
        /// returns a hex colour string. Ex: #000000
        /// </summary>
        /// <param name="r">Red value</param>
        /// <param name="g">Green value</param>
        /// <param name="b">Blue value</param>
        public static string ToHexFromRGB(RGB rgb)
        {
            List<int> variables = new List<int> { }; // List of each pair of x and y values
            string hexString = ""; // resulting hex string

            foreach (int value in new int[] { rgb.R, rgb.G, rgb.B }) // determine the x and y values for each colour value
            {
                double v = (Double)value / 16;
                int x = (Int32)Math.Truncate(v); // x is the integer of value/16
                int y = (Int32)(v % 1 * 16); // y is the remainder * 16

                // add x and y to list
                variables.Add(x);
                variables.Add(y);
            }

            foreach (var variable in variables)
            {
                hexString += variable.ToString("X"); // convert each value to hex and add it to the string
            }

            if (hexString.Length != 6)
            {
                hexString = "000000";
            }
            return "#" + hexString;
        }

        private static string CleanupHex(string hexInput)
        {
            hexInput = hexInput.Trim().Replace("#", "").Replace(" ", "");
            StringBuilder sb = new StringBuilder();

            // only allow characters A-f and 0-9.
            for (int i = 0; i < hexInput.Length; i++)
            {
                if ((hexInput[i] >= '0' && hexInput[i] <= '9')
                    || (hexInput[i] >= 'A' && hexInput[i] <= 'f'))
                {
                    sb.Append(hexInput[i]);
                }
            }

            string newHex = sb.ToString().Trim().Replace(" ", "");

            // check if it is either 3/6 characters
            if( 3 !=  newHex.Length && newHex.Length != 6)
            {
                newHex = "000000"; // default
            }

            return newHex;
        }

        public static string ToHexFromHSV(HSV hsv)
        {
            HSL hsl = ToHSLFromHSV(hsv);

            var h = hsl.H / 360;
            var s = hsl.S / 100;
            var l = hsl.L / 100;

            double hueToRGB(double p, double q, double t)
            {
                if (t < 0) t += 1;
                if (t > 1) t -= 1;
                if (t < 1 / 6) return p + (q - p) * 6 * t;
                if (t < 1 / 2) return q;
                if (t < 2 / 3) return p + (q - p) * (2 / 3 - t) * 6;
                return p;
            };

            double r, g, b;
            if (s == 0)
            {
                r = l;
                g = l;
                b = l; // achromatic
            }
            else
            {
                var q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                var p = 2 * l - q;
                r = hueToRGB(p, q, h + 1 / 3);
                g = hueToRGB(p, q, h);
                b = hueToRGB(p, q, h - 1 / 3);
            }
            string ToHex(int x)
            {
                var hex = (x * 255).ToString("X2");
                return hex.Length == 1 ? '0' + hex : hex;
            };
            return $"#{ToHex((Int32)r)}${ToHex((Int32)g)}${ToHex((Int32)b)}";
        }
      
    }
}
