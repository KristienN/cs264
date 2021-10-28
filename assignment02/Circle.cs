namespace assignment02
{
    public class Circle : Shape
    {

        public int r { get; set; }

        public Circle()
        {
            x = 100;
            y = 100;
            r = 100;

            svg = toSVGString();
        }

        public Circle(int cx, int cy, int r)
        {
            x = cx;
            y = cy;
            this.r = r;

        }

        public string toSVGString()
        {
            string svg = @"<svg height='100' width='100'>";
            svg += @"<circle cx ='" + x + "' cy ='" + y + "' r ='" + r + "' stroke ='black' stroke - width ='3' fill ='red'/>";
            svg += @"</svg>";

            return svg;
        }
    }
}