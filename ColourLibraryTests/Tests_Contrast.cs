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
            double actualContrast = Colour.ContrastRatio(rgb1, rgb2, out string actualRatio);

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
            double actualContrast = Colour.ContrastRatio(rgb1, rgb2, out string actualRatio);

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
            double actualContrast = Colour.ContrastRatio(rgb1, rgb2, out string actualRatio);

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