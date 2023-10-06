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
            Assert.AreEqual(expectedLuminance, actualLuminance, 0.001, "Luminance from RGB Failed.");
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
            Assert.AreEqual(expectedLuminance, actualLuminance, 0.001, "Luminance from RGB Failed.");
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
            Assert.AreEqual(expectedLuminance, actualLuminance, 0.001, "Luminance from RGB Failed.");
        }
    }
}