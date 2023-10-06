using System;

namespace ColourLibrary
{
    public class HSV
    {
        private double h;
        private double s;
        private double v;

        public double H
        {
            get { return Math.Round(h, 2); }
            set
            {
                if (value < 0)
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
                if (value < 0)
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

        public double V
        {
            get { return Math.Round(v, 2); }
            set
            {
                if (value < 0)
                {
                    v = 0;
                }
                else if (value > 100)
                {
                    v = 100;
                }
                else
                {
                    v = value;
                }
            }
        }

        public HSV(double hue = 0, double saturation = 0, double value = 0)
        {
            this.H = hue;
            this.S = saturation;
            this.V = value;
        }

        public override string ToString()
        {
            return $"hsv({this.H},{this.S},{this.V})";
        }
    }
}