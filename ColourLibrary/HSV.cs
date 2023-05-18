using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLibrary
{
    public class HSV
    {
        private int h;
        private int s;
        private int v;

        public int H { 
            get { return h; } 
            set { 
                if(0 > value || value > 360)
                {
                    throw new ArgumentOutOfRangeException("Hue must be between 0 and 360 degrees.");
                }
                h = value; 
            }
        }
        public int S { 
            get { return s; } 
            set {
                if (0 > value || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Saturation must be between 0% and 100%.");
                }
                s = value; 
            }
        }
        public int V { 
            get { return v; } 
            set {
                if (0 > value || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Value must be between 0% and 100%.");
                }
                v = value; 
            }
        }

        public HSV(int h, int s, int v)
        {
            this.H = h;
            this.S = s;
            this.V = v;
        }

        public override string ToString()
        {
            return $"hsv({this.H},{this.S},{this.V})";
        }
    }
}
