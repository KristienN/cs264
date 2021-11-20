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
            styles = new string[] { " black", "red", "5px" };
            svg = toSVGString();
        }

        public Circle(int cx, int cy, int r, string[] styles)
        {
            x = cx;
            y = cy;
            this.r = r;
            this.styles = styles;
            svg = toSVGString();

        }

        public override string toSVGString()
        {
            return @"<circle x='" + x + "' y='" + y + "' r='" + r + "' stroke='" + styles[0] + "' stroke-width='" + styles[2] + "' fill='" + styles[1] + "'/>";
        }
    }
}