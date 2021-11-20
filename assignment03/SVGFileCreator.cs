using System;
using System.IO;
using System.Collections.Generic;

namespace assignment03
{
    public class SVGFileCreator
    {
        public void createFile(Canvas canvas)



        {
            try
            {
                using (StreamWriter sw = File.CreateText(@"svg/output.svg"))
                {
                    sw.WriteLine(@"<svg width='" + canvas.width + "'  height='" + canvas.height + "' >");

                    Shape[] modelArray = canvas.model.ToArray();

                    foreach (Shape m in modelArray)
                    {
                        // Console.WriteLine(m.svg);
                        sw.WriteLine("" + m.svg);
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