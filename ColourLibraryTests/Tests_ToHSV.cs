using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColourLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLibrary.Tests
{
  
    public partial class ColourTests
    {
        [TestMethod()]
        public void ToHSVFromRGBTest1()
        {
            //Arrange
            int r = 255, g = 0, b = 0;
            RGB rgb = new RGB(r, g, b);
            int h = 360, s = 100, v = 100;
            HSV hsvExpected = new HSV(h, s, v);

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
            HSV hsvExpected = new HSV(h, s, v);

            //Act
            HSV hsvActual = Colour.ToHSVFromRGB(rgb);

            //Assert
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "RGB to HSV conversion failed for V value.");
        }

        /// <summary>
        /// Test rgb to hsv conversion
        /// </summary>
        [TestMethod()]
        public void ToHSVFromRGBTest3()
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
        
        [TestMethod()]
        public void ToHSVFromRGB4()
        {
            //Arrange
            int r = 255, g = 0, b = 0;
            RGB rgb = new RGB(r, g, b);
            int h = 0, s = 100, v = 100;
            HSV hsvExpected = new HSV(h, s, v);

            //Act
            HSV hsvActual = Colour.ToHSVFromRGB(rgb);

            //Assert
            Assert.AreEqual(hsvExpected.H, hsvActual.H, "Hue Failed.");
            Assert.AreEqual(hsvExpected.S, hsvActual.S, "Saturation Failed.");
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSVFromHex1()
        {
            //Arrange
            string hex = "#ff0000";
            int h = 0, s = 100, v = 100;
            HSV hsvExpected = new HSV(h, s, v);

            //Act
            HSV hsvActual = Colour.ToHSVFromHex(hex);

            //Assert

            Assert.AreEqual(hsvExpected.H, hsvActual.H, "Hue Failed.");
            Assert.AreEqual(hsvExpected.S, hsvActual.S, "Saturation Failed.");
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSVFromHex2()
        {
            //Arrange
            string hex = "ff0000";
            int h = 0, s = 100, v = 100;
            HSV hsvExpected = new HSV(h, s, v);

            //Act
            HSV hsvActual = Colour.ToHSVFromHex(hex);

            //Assert

            Assert.AreEqual(hsvExpected.H, hsvActual.H, "Hue Failed.");
            Assert.AreEqual(hsvExpected.S, hsvActual.S, "Saturation Failed.");
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSVFromHex3()
        {
            //Arrange
            string hex = "FF0000";
            int h = 0, s = 100, v = 100;
            HSV hsvExpected = new HSV(h, s, v);

            //Act
            HSV hsvActual = Colour.ToHSVFromHex(hex);

            //Assert

            Assert.AreEqual(hsvExpected.H, hsvActual.H, "Hue Failed.");
            Assert.AreEqual(hsvExpected.S, hsvActual.S, "Saturation Failed.");
            Assert.AreEqual(hsvExpected.V, hsvActual.V, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSLFromHSV1()
        {
            //Arrange
            int h = 0, s = 0, v = 0;
            HSV hsv = new HSV(h, s, v);

            int h2 = 0, s2 = 0, l = 0;
            HSL hslExpected = new HSL(h2, s2, l);


            //Act
            HSL hslActual = Colour.ToHSLFromHSV(hsv);

            //Assert

            Assert.AreEqual(hslExpected.H, hslActual.H, "Hue Failed.");
            Assert.AreEqual(hslExpected.S, hslActual.S, "Saturation Failed.");
            Assert.AreEqual(hslExpected.L, hslActual.L, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSLFromHSV2()
        {
            //Arrange
            int h = -1, s = -1, v = -1;
            HSV hsv = new HSV(h, s, v);

            int h2 = 0, s2 = 0, l = 0;
            HSL hslExpected = new HSL(h2, s2, l);


            //Act
            HSL hslActual = Colour.ToHSLFromHSV(hsv);

            //Assert

            Assert.AreEqual(hslExpected.H, hslActual.H, "Hue Failed.");
            Assert.AreEqual(hslExpected.S, hslActual.S, "Saturation Failed.");
            Assert.AreEqual(hslExpected.L, hslActual.L, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSLFromHSV3()
        {
            //Arrange
            int h = 360, s = 100, v = 100;
            HSV hsv = new HSV(h, s, v);

            int h2 = 360, s2 = 100, l = 50;
            HSL hslExpected = new HSL(h2, s2, l);


            //Act
            HSL hslActual = Colour.ToHSLFromHSV(hsv);

            //Assert

            Assert.AreEqual(hslExpected.H, hslActual.H, "Hue Failed.");
            Assert.AreEqual(hslExpected.S, hslActual.S, "Saturation Failed.");
            Assert.AreEqual(hslExpected.L, hslActual.L, "Value Failed.");
        }

        [TestMethod()]
        public void ToHSLFromHSV4()
        {
            //Arrange
            int h = 361, s = 101, v = 101;
            HSV hsv = new HSV(h, s, v);

            int h2 = 360, s2 = 100, l = 50;
            HSL hslExpected = new HSL(h2, s2, l);


            //Act
            HSL hslActual = Colour.ToHSLFromHSV(hsv);

            //Assert

            Assert.AreEqual(hslExpected.H, hslActual.H, "Hue Failed.");
            Assert.AreEqual(hslExpected.S, hslActual.S, "Saturation Failed.");
            Assert.AreEqual(hslExpected.L, hslActual.L, "Value Failed.");
        }
    }
}