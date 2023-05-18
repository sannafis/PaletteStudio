using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLibrary
{
     public class RGB
    {
        private int r;
        private int g;
        private int b;

        public int R {
            get { return r; } 
            set 
            {
                if(0 > value || value > 255) { throw new ArgumentOutOfRangeException("R value is not in range (0 - 255)."); }
                r = value;
            } 
        }
        public int G
        {
            get { return g; }
            set
            {
                if (0 > value || value > 255) { throw new ArgumentOutOfRangeException("G value is not in range (0 - 255)."); }
                g = value;
            }
        }
        public int B
        {
            get { return b; }
            set
            {
                if (0 > value || value > 255) { throw new ArgumentOutOfRangeException("B value is not in range (0 - 255)."); }
                b = value;
            }
        }


        public RGB(int r = 0, int g = 0, int b = 0)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public override string ToString()
        {
            return $"rgb({this.R},{this.G},{this.B})";
        }
    }
}
