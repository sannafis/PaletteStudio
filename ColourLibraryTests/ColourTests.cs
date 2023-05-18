using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColourLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLibrary.Tests
{
    [TestClass()]
    public class ColourTests
    {
        [TestMethod()]
        public void ToHexFromRGBTest1()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgb = new RGB(r, g, b);
            string hexExpected = "#000000";

            //Act
            string hexActual = Colour.ToHexFromRGB(rgb);

            //Assert
            Assert.AreEqual(hexExpected, hexActual, "RGB to Hex conversion failed.");
        }

        /// <summary>
        /// Test R value below excepted range (0 - 255)
        /// </summary>
        [TestMethod()]
        public void ToHexFromRGBTestR1()
        {
            //Arrange
            int r = -1, g = 0, b = 0;

            //Act
            try { RGB rgb = new RGB(r, g, b); }
            catch (ArgumentOutOfRangeException){ return; }

            //Assert
            Assert.Fail("Expected exception not found for R value.");
        }
        /// <summary>
        /// Test R value above excepted range (0 - 255)
        /// </summary>
        [TestMethod()]
        public void ToHexFromRGBTestR2()
        {
            //Arrange
            int r = 256, g = 0, b = 0;

            //Act
            try { RGB rgb = new RGB(r, g, b); }
            catch (ArgumentOutOfRangeException){ return; }

            //Assert
            Assert.Fail("Expected exception not found for R value.");
        }

        /// <summary>
        /// Test G value below excepted range (0 - 255)
        /// </summary>
        [TestMethod()]
        public void ToHexFromRGBTestG1()
        {
            //Arrange
            int r = 0, g = -1, b = 0;

            //Act
            try { RGB rgb = new RGB(r, g, b); }
            catch (ArgumentOutOfRangeException){ return; }

            //Assert
            Assert.Fail("Expected exception not found for G value.");
        }
        /// <summary>
        /// Test G value above excepted range (0 - 255)
        /// </summary>
        [TestMethod()]
        public void ToHexFromRGBTestG2()
        {
            //Arrange
            int r = 0, g = 256, b = 0;

            //Act
            try { RGB rgb = new RGB(r, g, b); }
            catch (ArgumentOutOfRangeException){ return; }

            //Assert
            Assert.Fail("Expected exception not found for G value.");
        }

        /// <summary>
        /// Test B value below excepted range (0 - 255)
        /// </summary>
        [TestMethod()]
        public void ToHexFromRGBTestB1()
        {
            //Arrange
            int r = 0, g = 0, b = -1;

            //Act
            try { RGB rgb = new RGB(r, g, b); }
            catch (ArgumentOutOfRangeException){ return; }

            //Assert
            Assert.Fail("Expected exception not found for B value.");
        }
        /// <summary>
        /// Test B value above excepted range (0 - 255)
        /// </summary>
        [TestMethod()]
        public void ToHexFromRGBTestB2()
        {
            //Arrange
            int r = 0, g = 0, b = 256;

            //Act
            try { RGB rgb = new RGB(r, g, b); }
            catch (ArgumentOutOfRangeException){ return; }

            //Assert
            Assert.Fail("Expected exception not found for B value.");
        }

        [TestMethod()]
        public void ToHexFromRGBTest2()
        {
            //Arrange
            int r = 255, g = 255, b = 255;
            RGB rgb = new RGB(r, g, b);
            string hexExpected = "#FFFFFF";

            //Act
            string hexActual = Colour.ToHexFromRGB(rgb);

            //Assert
            Assert.AreEqual(hexExpected, hexActual, "RGB to Hex conversion failed.");
        }

        [TestMethod()]
        public void ToHexFromRGBTest3()
        {
            //Arrange
            int r = 127, g = 127, b = 127;
            RGB rgb = new RGB(r, g, b);
            string hexExpected = "#7F7F7F";

            //Act
            string hexActual = Colour.ToHexFromRGB(rgb);

            //Assert
            Assert.AreEqual(hexExpected, hexActual, "RGB to Hex conversion failed.");
        }

        /// <summary>
        /// Test different string formats for hex input
        /// </summary>
        [TestMethod()]
        public void ToRGBFromHexTest1()
        {
            //Arrange
            string hex = "#a3626e";
            RGB rgbExpected = new RGB(163,98,110);

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Hex to RGB conversion failed for R value.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Hex to RGB conversion failed for G value.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Hex to RGB conversion failed for B value.");
        }

        [TestMethod()]
        public void ToHSVFromRGBTest1()
        {
            //Arrange
            int r = 255, g = 0, b = 0;
            RGB rgb = new RGB(r, g, b);
            int h = 360, s = 100, v = 100;
            HSV hsvExpected = new HSV(h,s,v);

            //Act
            HSV hsvActual = Colour.ToHSVFromRGB(rgb);

            //Assert
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "RGB to HSV conversion failed for V value.");
        }

        [TestMethod()]
        public void ToHSVFromRGBTest2()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgb = new RGB(r, g, b);
            int h = 0, s = 0, v = 0;
            HSV hsvExpected = new HSV(h,s,v);

            //Act
            HSV hsvActual = Colour.ToHSVFromRGB(rgb);

            //Assert
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "RGB to HSV conversion failed for V value.");
        }

        /// <summary>
        /// Test H value below excepted range (0 - 360)
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest3()
        {
            //Arrange
            int h = -1, s = 0, v = 0;

            //Act
            try { HSV hsv = new HSV(h,s,v); }
            catch (ArgumentOutOfRangeException) { return; }

            //Assert
            Assert.Fail("Expected exception not found for H value.");
        }

        /// <summary>
        /// Test H value above excepted range (0 - 360)
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest4()
        {
            //Arrange
            int h = 361, s = 0, v = 0;

            //Act
            try { HSV hsv = new HSV(h,s,v); }
            catch (ArgumentOutOfRangeException) { return; }

            //Assert
            Assert.Fail("Expected exception not found for H value.");
        }
        /// <summary>
        /// Test S value below excepted range (0 - 100)
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest5()
        {
            //Arrange
            int h = 0, s = -1, v = 0;

            //Act
            try { HSV hsv = new HSV(h,s,v); }
            catch (ArgumentOutOfRangeException) { return; }

            //Assert
            Assert.Fail("Expected exception not found for S value.");
        }
        /// <summary>
        /// Test S value above excepted range (0 - 100)
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest6()
        {
            //Arrange
            int h = 0, s = 101, v = 0;

            //Act
            try { HSV hsv = new HSV(h,s,v); }
            catch (ArgumentOutOfRangeException) { return; }

            //Assert
            Assert.Fail("Expected exception not found for S value.");
        }
        /// <summary>
        /// Test V value below excepted range (0 - 100)
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest7()
        {
            //Arrange
            int h = 0, s = 0, v = -1;

            //Act
            try { HSV hsv = new HSV(h,s,v); }
            catch (ArgumentOutOfRangeException) { return; }

            //Assert
            Assert.Fail("Expected exception not found for V value.");
        }
        /// <summary>
        /// Test V value above excepted range (0 - 100)
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest8()
        {
            //Arrange
            int h = 0, s = 0, v = 101;

            //Act
            try { HSV hsv = new HSV(h,s,v); }
            catch (ArgumentOutOfRangeException) { return; }

            //Assert
            Assert.Fail("Expected exception not found for V value.");
        }

        /// <summary>
        /// Test rgb to hsv conversion
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest9()
        {
            //Arrange
            int r = 62, g = 133, b = 81;
            RGB rgb = new RGB(r, g, b);
            int h = 136, s = 53, v = 52;
            HSV hsvExpected = new HSV(h, s, v);

            //Act
            HSV hsvActual = Colour.ToHSVFromRGB(rgb);

            //Assert
            Assert.AreEqual(hsvExpected.H, hsvActual.H, "RGB to HSV conversion failed for Hue.");
            Assert.AreEqual(hsvExpected.S, hsvActual.S, "RGB to HSV conversion failed for Saturation.");
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "RGB to HSV conversion failed for Value.");
        }
        /// <summary>
        /// Test luminance from rgb lower boundary
        /// </summary>
        [TestMethod()]
        public void LuminanceTest1()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgb = new RGB(r, g, b);
            double expectedLuminance = 0.00;

            //Act
            double actualLuminance = Colour.Luminance(rgb);

            //Assert
            Assert.AreEqual(expectedLuminance, actualLuminance,0.001, "Luminance from RGB Failed.");
        }
        /// <summary>
        /// Test luminance from rgb upper boundary
        /// </summary>
        [TestMethod()]
        public void LuminanceTest2()
        {
            //Arrange
            int r = 255, g = 255, b = 255;
            RGB rgb = new RGB(r, g, b);
            double expectedLuminance = 1.00;

            //Act
            double actualLuminance = Colour.Luminance(rgb);

            //Assert
            Assert.AreEqual(expectedLuminance, actualLuminance,0.001, "Luminance from RGB Failed.");
        }
        /// <summary>
        /// Test luminance from rgb
        /// </summary>
        [TestMethod()]
        public void LuminanceTest3()
        {
            //Arrange
            int r = 153, g = 35, b = 35;
            RGB rgb = new RGB(r, g, b);
            double expectedLuminance = 0.08;

            //Act
            double actualLuminance = Colour.Luminance(rgb);

            //Assert
            Assert.AreEqual(expectedLuminance, actualLuminance,0.001, "Luminance from RGB Failed.");
        }
        /// <summary>
        /// Test Contrast Ratio calculation
        /// </summary>
        [TestMethod()]
        public void ContrastRatioTest1()
        {
            //Arrange
            int r1 = 0, g1 = 0, b1 = 0;
            RGB rgb1 = new RGB(r1, g1, b1);
            int r2 = 255, g2 = 255, b2 = 255;
            RGB rgb2 = new RGB(r2, g2, b2);
            double expectedContrast = 21;
            string expectedRatio = "21:1";

            //Act
            double actualContrast = Colour.ContrastRatio(rgb1,rgb2, out string actualRatio);

            //Assert
            Assert.AreEqual(expectedContrast, actualContrast, "Contrast calculation Failed.");
            StringAssert.Contains(expectedRatio, actualRatio, "Ratio does not match expected output.");
        }
        /// <summary>
        /// Test Contrast Ratio calculation
        /// </summary>
        [TestMethod()]
        public void ContrastRatioTest2()
        {
            //Arrange
            int r1 = 255, g1 = 255, b1 = 255;
            RGB rgb1 = new RGB(r1, g1, b1);
            int r2 = 0, g2 = 0, b2 = 0;
            RGB rgb2 = new RGB(r2, g2, b2);
            double expectedContrast = 21;
            string expectedRatio = "21:1";

            //Act
            double actualContrast = Colour.ContrastRatio(rgb1,rgb2, out string actualRatio);

            //Assert
            Assert.AreEqual(expectedContrast, actualContrast, "Contrast calculation Failed.");
            StringAssert.Contains(expectedRatio, actualRatio, "Ratio does not match expected output.");
        }
        /// <summary>
        /// Contrast Ratio calculation
        /// </summary>
        [TestMethod()]
        public void ContrastRatioTest3()
        {
            //Arrange
            int r1 = 255, g1 = 0, b1 = 0;
            RGB rgb1 = new RGB(r1, g1, b1);
            int r2 = 255, g2 = 0, b2 = 0;
            RGB rgb2 = new RGB(r2, g2, b2);
            double expectedContrast = 1;
            string expectedRatio = "1:1";

            //Act
            double actualContrast = Colour.ContrastRatio(rgb1,rgb2, out string actualRatio);

            //Assert
            Assert.AreEqual(expectedContrast, actualContrast, "Contrast calculation Failed.");
            StringAssert.Contains(expectedRatio, actualRatio, "Ratio does not match expected output.");
        }
        /// <summary>
        /// Contrast Ratio calculation
        /// </summary>
        [TestMethod()]
        public void ContrastRatioTest4()
        {
            //Arrange
            string hex1 = "#ACC8E5";
            string hex2 = "#112A46";
            double expectedContrast = 8.41;
            string expectedRatio = "8.41:1";

            //Act
            double actualContrast = Colour.ContrastRatio(Colour.ToRGBFromHex(hex1), Colour.ToRGBFromHex(hex2), out string actualRatio);

            //Assert
            Assert.AreEqual(expectedContrast, actualContrast, "Contrast calculation Failed.");
            StringAssert.Contains(expectedRatio, actualRatio, "Ratio does not match expected output.");
        }
        /// <summary>
        /// Contrast Ratio calculation
        /// </summary>
        [TestMethod()]
        public void ContrastRatioTest5()
        {
            //Arrange
            string hex1 = "#FFFEFD";
            string hex2 = "#D36E70";
            double expectedContrast = 3.34;
            string expectedRatio = "3.34:1";

            //Act
            double actualContrast = Colour.ContrastRatio(Colour.ToRGBFromHex(hex1), Colour.ToRGBFromHex(hex2), out string actualRatio);

            //Assert
            Assert.AreEqual(expectedContrast, actualContrast, "Contrast calculation Failed.");
            StringAssert.Contains(expectedRatio, actualRatio, "Ratio does not match expected output.");
        }
        /// <summary>
        /// Contrast Ratio calculation
        /// </summary>
        [TestMethod()]
        public void ContrastRatioTest6()
        {
            //Arrange
            string hex1 = "#FF3436";
            string hex2 = "#D36E70";
            double expectedContrast = 1.07;
            string expectedRatio = "1.07:1";

            //Act
            double actualContrast = Colour.ContrastRatio(Colour.ToRGBFromHex(hex1), Colour.ToRGBFromHex(hex2), out string actualRatio);

            //Assert
            Assert.AreEqual(expectedContrast, actualContrast, "Contrast calculation Failed.");
            StringAssert.Contains(expectedRatio, actualRatio, "Ratio does not match expected output.");
        }
    }
}