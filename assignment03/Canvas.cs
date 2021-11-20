using System.Collections.Generic;
using System;

namespace assignment03
{
    public class Canvas
    {
        public int height { get; set; }
        public int width { get; set; }
        public Stack<Shape> model { get; set; }
        public Stack<Shape> lastShapes { get; set; }

        public Canvas(int height, int width)
        {
            this.height = height;
            this.width = width;
            model = new Stack<Shape>();
            lastShapes = new Stack<Shape>();
        }
        public Canvas() : this(500, 500) { }
        public void addShape(String s)
        {
            s = s.ToLower();
            String[] array = s.Split(":");
            string st = array.Length > 1 ? st = array[1] : st = null;
            Boolean check = st != null && st == "s";


            switch (array[0])
            {
                case "circle":
                    if (check)
                    {
                        int[] attr = cAttr();
                        string[] style = styling();
                        model.Push(new Circle(attr[0], attr[1], attr[2], style));
                        Console.WriteLine("Shape Added!");
                    }
                    else
                    {
                        model.Push(new Circle(0, 0, 100));
                        Console.WriteLine("Shape Added!");
                    }
                    break;
                case "rect":
                    if (check)
                    {
                        int[] attr = rAttr();
                        string[] style = styling();
                        model.Push(new Rectangle(attr[0], attr[1], attr[2], attr[3], style));
                        Console.WriteLine("Shape Added!");
                    }
                    else
                    {
                        model.Push(new Rectangle(0, 0, 100, 200));
                        Console.WriteLine("Shape Added!");
                    }
                    break;
                case "ellipse":
                    if (check)
                    {
                        int[] attr = eAttr();
                        string[] style = styling();
                        model.Push(new Ellipse(attr[0], attr[1], attr[2], attr[3], style));
                        Console.WriteLine("Shape Added!");
                    }
                    else
                    {
                        model.Push(new Ellipse(0, 0, 100, 100));
                        Console.WriteLine("Shape Added!");
                    }
                    break;
                case "line":
                    if (check)
                    {
                        int[] attr = cAttr();
                        string[] style = styling();
                        model.Push(new Line(attr[0], attr[1], attr[2], attr[3], style));
                        Console.WriteLine("Shape Added!");
                    }
                    else
                    {
                        model.Push(new Line(0, 0, 100, 100));
                        Console.WriteLine("Shape Added!");
                    }
                    break;
                default:
                    Console.WriteLine("Shape failed to add. Enter a valid command");
                    break;
            }

            if (lastShapes.Count > 0)
            {
                lastShapes.Clear();
            }
        }

        public void clear()
        {
            model.Clear();
        }

        public void undo()
        {
            if (model.Count > 0)
            {
                Shape s = model.Pop();
                lastShapes.Push(s);
                Console.WriteLine("Undo!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Cannot undo");
                Console.WriteLine();
            }
        }

        public void redo()
        {

            if (lastShapes.Count > 0)
            {
                model.Push(lastShapes.Pop());
                Console.WriteLine("Redo!");
            }
            else
            {
                Console.WriteLine("Cannot redo");
            }

        }

        public void show()
        {
            Console.WriteLine(@"<svg width='" + width + "'  height='" + height + "' >");
            foreach (Shape m in model)
            {
                Console.WriteLine(" " + m.svg);
            }
            Console.WriteLine("</svg>");
        }

        public int[] cAttr()
        {
            Console.Write("Enter X: ");
            string r = Console.ReadLine();
            int x = int.Parse(r);

            Console.Write("Enter Y: ");
            r = Console.ReadLine();
            int y = int.Parse(r);

            Console.Write("Enter Radius: ");
            r = Console.ReadLine();
            int rad = int.Parse(r);


            return new int[] { x, y, rad };

        }

        public int[] rAttr()
        {
            Console.Write("Enter X: ");
            string r = Console.ReadLine();
            int x = int.Parse(r);

            Console.Write("Enter Y: ");
            r = Console.ReadLine();
            int y = int.Parse(r);

            Console.Write("Enter Height: ");
            r = Console.ReadLine();
            int w = int.Parse(r);

            Console.Write("Enter Width: ");
            r = Console.ReadLine();
            int h = int.Parse(r);

            return new int[] { x, y, w, h };

        }

        public int[] eAttr()
        {
            Console.Write("Enter CX: ");
            string r = Console.ReadLine();
            int x = int.Parse(r);

            Console.Write("Enter CY: ");
            r = Console.ReadLine();
            int y = int.Parse(r);

            Console.Write("Enter RX: ");
            r = Console.ReadLine();
            int cx = int.Parse(r);

            Console.Write("Enter RY: ");
            r = Console.ReadLine();
            int cy = int.Parse(r);

            return new int[] { x, y, cx, cy };

        }

        public int[] lAttr()
        {
            Console.Write("Enter X: ");
            string r = Console.ReadLine();
            int x = int.Parse(r);

            Console.Write("Enter Y: ");
            r = Console.ReadLine();
            int y = int.Parse(r);

            Console.Write("Enter next X: ");
            r = Console.ReadLine();
            int x1 = int.Parse(r);

            Console.Write("Enter next Y: ");
            r = Console.ReadLine();
            int y1 = int.Parse(r);

            return new int[] { x, y, x1, y1 };

        }

        public string[] styling()
        {
            Console.Write("line colour:");
            string x = Console.ReadLine();

            Console.Write("fill colour:");
            string y = Console.ReadLine();

            Console.Write("thickness:");
            string z = Console.ReadLine();

            return new string[] { x, y, z };
        }

    }
}