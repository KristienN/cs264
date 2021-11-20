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
            styles = new string[] { " black", "red", "5px" };
            svg = toSVGString();
        }

        public Line(int x, int y, int x2, int y2, string[] styles)
        {
            this.x = x;
            this.y = y;
            this.width = x2;
            this.height = y2;
            this.styles = styles;

            svg = toSVGString();
        }
        public override string toSVGString()
        {
            return @"<line x1='" + x + "'y1='" + y + "' x2='" + width + "' y2='" + height + "' stroke='" + styles[0] + "' stroke-width='" + styles[2] + "' fill='" + styles[1] + "'/>";
        }


    }
}