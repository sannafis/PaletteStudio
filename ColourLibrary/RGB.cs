namespace ColourLibrary
{
    public class RGB
    {
        private int r;
        private int g;
        private int b;

        public int R
        {
            get { return r; }
            set
            {
                if (value < 0)
                {
                    r = 0;
                }
                else if (value > 255)
                {
                    r = 255;
                }
                else
                {
                    r = value;
                }
            }
        }

        public int G
        {
            get { return g; }
            set
            {
                if (value < 0)
                {
                    g = 0;
                }
                else if (value > 255)
                {
                    g = 255;
                }
                else
                {
                    g = value;
                }
            }
        }

        public int B
        {
            get { return b; }
            set
            {
                if (value < 0)
                {
                    b = 0;
                }
                else if (value > 255)
                {
                    b = 255;
                }
                else
                {
                    b = value;
                }
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