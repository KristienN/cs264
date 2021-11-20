namespace assignment03
{
    public class Rectangle : Shape
    {
        public Rectangle() : this(0, 0, 100, 400) { }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            styles = new string[] { " black", "red", "" };
            svg = toSVGString();
        }

        public Rectangle(int x, int y, int width, int height, string[] styles)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.styles = styles;

            svg = toSVGString();
        }

        public override string toSVGString()
        {
            return @"<rect x='" + x + "' y='" + y + "' width='" + width + "' height='" + height + "' stroke='" + styles[0] + "' stroke-width='" + styles[2] + "' fill='" + styles[1] + "'/>";


        }
    }
}