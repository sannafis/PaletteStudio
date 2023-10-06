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
        //From Hex

        [TestMethod()]
        public void ToRGBFromHex_Red4()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "#000000";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHex_Red5()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "000000";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }


        //Testing Red Boundaries

        [TestMethod()]
        public void ToRGBFromHex_Red1()
        {
            //Arrange
            int r = 255, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "#ff0000";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }
        [TestMethod()]
        public void ToRGBFromHex_Red2()
        {
            //Arrange
            int r = 255, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "ff0000";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }
        [TestMethod()]
        public void ToRGBFromHex_Red3()
        {
            //Arrange
            int r = 255, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "FF0000";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        

        //Testing Green Boundaries

        [TestMethod()]
        public void ToRGBFromHex_Green1()
        {
            //Arrange
            int r = 0, g = 255, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "#00ff00";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }
        [TestMethod()]
        public void ToRGBFromHex_Green2()
        {
            //Arrange
            int r = 0, g = 255, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "00ff00";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }
        [TestMethod()]
        public void ToRGBFromHex_Green3()
        {
            //Arrange
            int r = 0, g = 255, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "00FF00";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }



        
        //Testing Blue Boundaries

        [TestMethod()]
        public void ToRGBFromHex_Blue1()
        {
            //Arrange
            int r = 0, g = 0, b = 255;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "#0000ff";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }
        [TestMethod()]
        public void ToRGBFromHex_Blue2()
        {
            //Arrange
            int r = 0, g = 0, b = 255;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "0000ff";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }
        [TestMethod()]
        public void ToRGBFromHex_Blue3()
        {
            //Arrange
            int r = 0, g = 0, b = 255;
            RGB rgbExpected = new RGB(r, g, b);
            string hex = "0000FF";

            //Act
            RGB rgbActual = Colour.ToRGBFromHex(hex);

            //Assert
            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }



        

        // From HSV

        [TestMethod()]
        public void ToRGBFromHSV()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = 0, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        //Hue Boundary Testing

        [TestMethod()]
        public void ToRGBFromHSV_Hue1()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = -1, s = 0, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHSV_Hue2()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 360, s = 0, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHSV_Hue3()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 361, s = 0, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        //Saturation Boundary Testing

        [TestMethod()]
        public void ToRGBFromHSV_Saturation1()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = -1, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHSV_Saturation2()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = 100, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHSV_Saturation3()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = 101, v = 0;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        //Value Boundary Testing

        [TestMethod()]
        public void ToRGBFromHSV_Value1()
        {
            //Arrange
            int r = 0, g = 0, b = 0;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = 0, v = -1;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHSV_Value2()
        {
            //Arrange
            int r = 255, g = 255, b = 255;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = 0, v = 100;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        [TestMethod()]
        public void ToRGBFromHSV_Value3()
        {
            //Arrange
            int r = 255, g = 255, b = 255;
            RGB rgbExpected = new RGB(r, g, b);
            int h = 0, s = 0, v = 101;
            HSV hsv = new HSV(h, s, v);

            //Act
            RGB rgbActual = Colour.ToRGBFromHSV(hsv);

            //Assert

            Assert.AreEqual(rgbExpected.R, rgbActual.R, "Red Failed.");
            Assert.AreEqual(rgbExpected.G, rgbActual.G, "Green Failed.");
            Assert.AreEqual(rgbExpected.B, rgbActual.B, "Blue Failed.");
        }

        // COMPLETE LIBRARY

    }
}