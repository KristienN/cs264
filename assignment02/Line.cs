namespace assignment02
{
    public class Line : Shape

    {
        public Line() : this(0, 0, 100, 100) { }
        public Line(int x, int y, int x2, int y2)
        {
            this.x = x;
            this.y = y;
            this.width = x2;
            this.height = y2;
        }

        public string toSVGString()
        {
            string svg = @"<svg height='100' width='100'>";
            svg += @"<circle cx ='" + x + "' cy ='" + y + "' r ='" + width + "' stroke ='black' stroke - width ='3' fill ='red'/>";
            svg += @"</svg>";

            return svg;
        }


    }
}