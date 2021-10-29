using System.Collections.Generic;
using System.IO;
using System;

namespace assignment02
{
    public class Canvas
    {
        int height, width;
        List<Shape> model;

        public Canvas(int height, int width)
        {
            this.height = height;
            this.width = width;
            model = new List<Shape>();
        }
        public Canvas() : this(100, 100) { }
        public void addShape(Shape s)
        {
            s.z = model.Count;
            model.Add(s);
        }

        public void deleteShape(int index)
        {
            model.RemoveAt(index);
        }

        public void updateShape(int index, Shape s)
        {
            model[index] = s;
        }

        public void printCanvas()
        {
            foreach (Shape m in model)
            {
                Console.WriteLine(m.svg);
                Console.WriteLine();
            }
        }

        public void drawSVG()
        {
            try
            {
                using (StreamWriter sw = File.CreateText(@"svg/output.svg"))
                {
                    sw.WriteLine(@"<svg height = '" + height + "' width = '" + width + "' >");

                    foreach (Shape m in model)
                    {
                        // Console.WriteLine(m.svg);
                        sw.WriteLine(m.svg);
                    }

                    sw.WriteLine(@"</svg>");
                }
            }
            catch (Exception ext)
            {
                Console.WriteLine("Error  {0}", ext);
            }
        }
    }
}