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

            svg = toSVGString();
        }

        public override string toSVGString()
        {
            string svg = @"<svg height='" + height + "' width='" + width + "'>";
            svg += @"<rect cx ='" + x + "' cy ='" + y + "' stroke ='black' stroke - width ='3' fill ='red'/>";
            svg += @"</svg>";

            return svg;

        }
    }
}