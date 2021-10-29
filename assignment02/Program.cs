using System;

namespace assignment02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SVG creator 1.0, press 0 then enter to start.");
            Console.WriteLine("Otherwise press 1 to exit");
            Console.WriteLine();
            Console.WriteLine("To view commands list please pres 9 or consult README.md");

            string start = Console.ReadLine();

            if (start == "0")
            {

                Console.WriteLine();
                Console.WriteLine("Please enter size of canvas: [width] [height]");
                string[] size = Console.ReadLine().Split(" ");
                var canvas = new Canvas(int.Parse(size[0]), int.Parse(size[1]));
                Console.WriteLine();
                Console.WriteLine("To add a shape to the canvas please use the following syntax");
                Console.WriteLine("[shape letter] [x] [y] [width] [height]");
                Console.WriteLine();
                Console.WriteLine("When complete, enter 0 to continue");
                Console.WriteLine();

                string command = "";
                bool step = true;

                while (step)
                {
                    command = Console.ReadLine();
                    command = command.ToLower();
                    string[] cmdArr = command.Split(" ");

                    switch (cmdArr[0])
                    {
                        case "c":
                            int x = int.Parse(cmdArr[1]);
                            int y = int.Parse(cmdArr[2]);
                            int r = int.Parse(cmdArr[3]);
                            canvas.addShape(new Circle(x, y, r));
                            break;

                        case "r":
                            x = int.Parse(cmdArr[1]);
                            y = int.Parse(cmdArr[2]);
                            int w = int.Parse(cmdArr[3]);
                            int h = int.Parse(cmdArr[4]);
                            var rect = new Rectangle(x, y, w, h);
                            canvas.addShape(rect);
                            break;

                        case "e":
                            x = int.Parse(cmdArr[1]);
                            y = int.Parse(cmdArr[2]);
                            int rx = int.Parse(cmdArr[3]);
                            int ry = int.Parse(cmdArr[4]);
                            var ellipse = new Ellipse(x, y, rx, ry);
                            canvas.addShape(ellipse);
                            break;



                        case "l":
                            x = int.Parse(cmdArr[1]);
                            y = int.Parse(cmdArr[2]);
                            rx = int.Parse(cmdArr[3]);
                            ry = int.Parse(cmdArr[4]);
                            var line = new Line(x, y, rx, ry);
                            canvas.addShape(line);
                            break;
                        case "0":
                            step = false;
                            break;
                        default:
                            Console.WriteLine("Invalid syntax, try again");
                            break;


                    }
                }

                Console.WriteLine("If you would like to edit any of the shapes on the canvas so far, use the following syntax:");
                Console.WriteLine("[edit command] [z-index]:[new shape command if update]");
                Console.WriteLine();
                Console.WriteLine("When complete, enter 0 to continue");

                bool step2 = true;
                while (step2)
                {
                    string edit = Console.ReadLine();

                    if (edit == "0")
                    {
                        step2 = false;
                        break;
                    }

                    edit = edit.ToLower();

                    string[] eArr = edit.Split(" ");

                    if (eArr[0] == "d")
                    {
                        int index = int.Parse(eArr[1]);
                        canvas.deleteShape(index);
                    }

                    if (eArr[0] == "u")
                    {
                        string[] options = eArr[1].Split(":");
                        // edits to be implemented
                    }

                }

                Console.WriteLine();
                Console.WriteLine("SVG to be created: ");
                Console.WriteLine();
                canvas.printCanvas();
                Console.WriteLine();
                Console.WriteLine("SVG outputing to file in svg folder.");

                canvas.drawSVG();

                Console.WriteLine();
                Console.WriteLine("SVG file successfully created! Happy Hacking!");


            }
            else if (start == "9")
            {
                Console.WriteLine("shape letters:");
                Console.WriteLine("c - circle");
                Console.WriteLine("e - ellipse");
                Console.WriteLine("l - line");
                Console.WriteLine("r - rect");
                Console.WriteLine();
                Console.WriteLine("Dimensions:");
                Console.WriteLine("for circle -  x y raidus");
                Console.WriteLine("for rectangle - x y width height ");
                Console.WriteLine("for ellipse - cx cy rx ry");
                Console.WriteLine("for line - x1 y1 x2 y2");
                Console.WriteLine();
            }
            else
            {
                Environment.Exit(1);
            }

        }
    }
}
