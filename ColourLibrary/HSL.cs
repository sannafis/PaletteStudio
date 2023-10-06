using System;

namespace ColourLibrary
{
    public class HSL
    {
        private double h;
        private double s;
        private double l;

        public double H
        {
            get { return Math.Round(h, 2); }
            set
            {
                if (value < 0 || Double.IsNaN(value))
                {
                    h = 0;
                }
                else if (value > 360)
                {
                    h = 360;
                }
                else
                {
                    h = value;
                }
            }
        }

        public double S
        {
            get { return Math.Round(s, 2); }
            set
            {
                if (value < 0 || Double.IsNaN(value))
                {
                    s = 0;
                }
                else if (value > 100)
                {
                    s = 100;
                }
                else
                {
                    s = value;
                }
            }
        }

        public double L
        {
            get { return Math.Round(l, 2); }
            set
            {
                if (value < 0 || Double.IsNaN(value))
                {
                    l = 0;
                }
                else if (value > 100)
                {
                    l = 100;
                }
                else
                {
                    l = value;
                }
            }
        }

        public HSL(double hue = 0, double saturation = 0, double luminance = 0)
        {
            this.H = hue;
            this.S = saturation;
            this.L = luminance;
        }

        public override string ToString()
        {
            return $"hsv({this.H},{this.S},{this.L})";
        }
    }
}