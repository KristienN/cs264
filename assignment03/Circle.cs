namespace assignment03
{
    public class Circle : Shape
    {

        public int r { get; set; }

        public Circle() : this(100, 100, 100) { }

        public Circle(int cx, int cy, int r)
        {
            x = cx;
            y = cy;
            this.r = r;

            svg = toSVGString();

        }

        public override string toSVGString()
        {
            string svg = @"<svg>";
            svg += @"<circle cx ='" + x + "' cy ='" + y + "' r ='" + r + "' stroke ='black' stroke - width ='3' fill ='red'/>";
            svg += @"</svg>";

            return svg;
        }
    }
}