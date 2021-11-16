using System.Collections.Generic;
using System.IO;
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
        }
        public Canvas() : this(500, 500) { }
        public void addShape(String s)
        {
            switch (s)
            {
                case "circle":
                    model.Push(new Circle(0, 0, 100));
                    break;
                case "rect":
                    model.Push(new Rectangle(0, 0, 100, 100));
                    break;
                case "ellipse":
                    model.Push(new Ellipse(0, 0, 100, 100));
                    break;
                case "line":
                    model.Push(new Line(0, 0, 5, 6));
                    break;
                default:
                    Console.WriteLine("Shape failed to add.");
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
            }
            else
            {
                Console.WriteLine("Cannot undo");
            }
        }

        public void redo()
        {

            if (lastShapes.Count > 0)
            {
                model.Push(lastShapes.Pop());
            }
            else
            {
                Console.WriteLine("Cannot redo");
            }

        }

        public void show()
        {
            foreach (Shape m in model)
            {
                Console.WriteLine(m.svg);
                Console.WriteLine();
            }
        }

    }
}