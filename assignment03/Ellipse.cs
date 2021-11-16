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

            svg = toSVGString();
        }
        public override string toSVGString()
        {
            string svg = @"<svg>";
            svg += @"<ellipse cx ='" + x + "' cy ='" + y + "' rx ='" + rx + "' ry = '" + ry + "' stroke ='black' stroke - width ='3' fill ='red'/>";
            svg += @"</svg>";
            return svg;
        }
    }
}