namespace assignment03
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

            svg = toSVGString();
        }
        public override string toSVGString()
        {
            string svg = @"<svg>";
            svg += @"<line x1='" + x + "' y1='" + y + "' x2='" + width + "' y2='" + height + "' style='stroke: red; stroke - width:2' />";
            svg += @"</svg>";

            return svg;
        }


    }
}