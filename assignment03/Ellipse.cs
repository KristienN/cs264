namespace assignment03
{
    public class Ellipse : Shape
    {
        public int rx { get; set; }
        public int ry { get; set; }
        public Ellipse() : this(100, 100, 100, 100) { }
        public Ellipse(int cx, int cy, int rx, int ry)
        {
            this.rx = rx;
            this.ry = ry;
            x = cx;
            y = cy;
            styles = new string[] { " black", "red", "5px" };
            svg = toSVGString();
        }

        public Ellipse(int cx, int cy, int rx, int ry, string[] styles)
        {
            this.rx = rx;
            this.ry = ry;
            x = cx;
            y = cy;
            this.styles = styles;

            svg = toSVGString();
        }
        public override string toSVGString()
        {
            return @"<ellipse cx='" + x + "' cy='" + y + "' rx='" + rx + "' ry= '" + ry + "' stroke='" + styles[0] + "' stroke-width='" + styles[2] + "' fill='" + styles[1] + "'/>";

        }
    }
}