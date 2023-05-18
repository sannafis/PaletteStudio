using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ColourLibrary
{
    public static class Colour
    {
        public static RGB ToRGBFromHex(string hex)
        {
            string hexInput = hex.Trim().Replace("#", "").Replace(" ", "");

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
                throw new ArgumentException("Hex value must have either 3 or 6 characters.");
            }
        }

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
                throw new Exception("Something went wrong. Make sure you have entered valid RGB values");
            }

            return "#" + hexString;
        }

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

            int h = -1, s = -1, v = -1;

            // Calculate Hue
            if (max == min) // min and max values are equal
            {
                h = 0;
            }
            else if (max == r) // red is the max value
            {
                h = (Int32)((60 * ((g - b) / difference) + 360) % 360);
            }
            else if (max == g) // green is max value
            {
                h = (Int32)((60 * ((b - r) / difference) + 120) % 360);
            }
            else if (max == b) // blue is max value
            {
                h = (Int32)((60 * ((r - g) / difference) + 240) % 360);
            }

            // Calculate Saturation
            if (max == 0)
            {
                s = 0;
            }
            else
            {
                s = (Int32)((difference / max) * 100);
            }

            // Calculate Value
            v = (Int32)(max * 100);

            return new HSV(h, s, v);

        }

        public static HSV ToHSVFromHex(string hex)
        {
            RGB rgb = ToRGBFromHex(hex);
            HSV hsv = ToHSVFromRGB(new RGB(rgb.R, rgb.G, rgb.B));
            return hsv;
        }

        public static double Luminance(RGB rgb)
        {
            double[] rgbArray = { rgb.R, rgb.G, rgb.B };

            // if RGB has value of <= 0.3928, the value is divided by 12.92
            // else : RGB = ((value + 0.055) / 1.055)^2.4
            // Formula is from WCAG 2.0 recommendation
            rgbArray = rgbArray.Select(x => x / 255).Select(x => x <= 0.03928 ? x / 12.92 : Math.Pow(((x + 0.055) / 1.055), 2.4)).ToArray();

            //Relative Luminance
            // L = 0.2126 * R + 0.7152 * G + 0.0722 + B

            return 0.2126 * rgbArray[0] + 0.7152 * rgbArray[1] + 0.0722 * rgbArray[2];

        }

        public static double ContrastRatio(RGB rgb1, RGB rgb2, out string ratio)
        {
            double luminance1 = Luminance(rgb1);
            double luminance2 = Luminance(rgb2);
            double brightest = Math.Max(luminance1, luminance2);
            double darkest = Math.Min(luminance1, luminance2);

            // Contrast Ratio = (L1 + 0.05)/(L2 + 0.05)
            // Where L1 = brightest colour , L2 = darkest colour
            double contrast = Math.Truncate(((brightest + 0.05) / (darkest + 0.05)) * 100) / 100;
            // if contrast is a whole number, truncate the result. 
            // example: contrast = 12.0 --> ratio = 12:1
            ratio = $"{(contrast.ToString("F").Contains(".00") ? Math.Truncate(contrast).ToString() : contrast.ToString("F"))}:1";

            return contrast;

        }

        public static double ContrastRatio(RGB rgb1, RGB rgb2)
        {
            double luminance1 = Luminance(rgb1);
            double luminance2 = Luminance(rgb2);
            double brightest = Math.Max(luminance1, luminance2);
            double darkest = Math.Min(luminance1, luminance2);

            // Contrast Ratio = (L1 + 0.05)/(L2 + 0.05)
            // Where L1 = brightest colour , L2 = darkest colour
            double contrast = Math.Truncate(((brightest + 0.05) / (darkest + 0.05)) * 100) / 100;

            return contrast;

        }
        
        public static double ContrastRatio(string hex1, string hex2, out string ratio)
        {
            // convert hex colours to RGB
            RGB rgb1 = ToRGBFromHex(hex1);
            RGB rgb2 = ToRGBFromHex(hex2);

            double luminance1 = Luminance(rgb1);
            double luminance2 = Luminance(rgb2);
            double brightest = Math.Max(luminance1, luminance2);
            double darkest = Math.Min(luminance1, luminance2);

            // Contrast Ratio = (L1 + 0.05)/(L2 + 0.05)
            // Where L1 = brightest colour , L2 = darkest colour
            double contrast = Math.Truncate(((brightest + 0.05) / (darkest + 0.05)) * 100) / 100;
            // if contrast is a whole number, truncate the result. 
            // example: contrast = 12.0 --> ratio = 12:1
            ratio = $"{(contrast.ToString("F").Contains(".00") ? Math.Truncate(contrast).ToString() : contrast.ToString("F"))}:1";

            return contrast;

        }      
        
        public static double ContrastRatio(string hex1, string hex2)
        {
            // convert hex colours to RGB
            RGB rgb1 = ToRGBFromHex(hex1);
            RGB rgb2 = ToRGBFromHex(hex2);

            double luminance1 = Luminance(rgb1);
            double luminance2 = Luminance(rgb2);
            double brightest = Math.Max(luminance1, luminance2);
            double darkest = Math.Min(luminance1, luminance2);

            // Contrast Ratio = (L1 + 0.05)/(L2 + 0.05)
            // Where L1 = brightest colour , L2 = darkest colour
            double contrast = Math.Truncate(((brightest + 0.05) / (darkest + 0.05)) * 100) / 100;

            return contrast;

        }

        public static string RegularTextRating(double contrast)
        {
            // return a rating based on contrast according to WCAG Regular Sized Text guidlines
            if (contrast >= WCAG.RegularTextAAA)
            {
                return "AAA";
            }
            else
            if (contrast >= WCAG.RegularTextAA)
            {
                return "AA";
            }
            return "Fail";
        }

        public static string LargeTextRating(double contrast)
        {
            // return a rating based on contrast according to WCAG Large Sized Text guidlines
            if (contrast >= WCAG.LargeTextAAA)
            {
                return "AAA";
            }
            else if (contrast >= WCAG.LargeTextAA)
            {
                return "AA";
            }
            return "Fail";

        }
    }
}
