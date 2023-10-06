using System;
using System.Linq;

namespace ColourLibrary
{
    public static partial class Colour
    {
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
