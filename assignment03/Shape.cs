namespace assignment03
{
    public abstract class Shape
    {

        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string svg { get; set; }
        public string[] styles { get; set; }
        public Shape() : this(100, 100, 100, 100) { }
        public Shape(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.z = 0;
        }

        public Shape(int x, int y, int width, int height, string[] styles)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.z = 0;
            this.styles = styles;
        }

        public abstract string toSVGString();



    }
}