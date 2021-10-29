namespace assignment02
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
            System.Console.WriteLine(svg);
        }
        public string toSVGString()
        {
            string svg = @"<svg height='100' width='50'>";
            svg += @"<ellipse cx ='" + x + "' cy ='" + y + "' rx ='" + rx + "' ry = '" + ry + "' stroke ='black' stroke - width ='3' fill ='red'/>";
            svg += @"</svg>";
            return svg;
        }
    }
}