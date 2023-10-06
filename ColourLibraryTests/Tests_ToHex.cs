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
    public partial class ColourTests
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

        

    }
}