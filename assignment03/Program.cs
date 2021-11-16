using System;

namespace assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            var canvas = new Canvas();
            Console.WriteLine();
            Console.WriteLine("Canvas created - use commands to add, undo & redo shapes on the canvas");
            Console.WriteLine("A <shape> [specific attributes]   Add Shape");
            Console.WriteLine("C            Clear canvas");
            Console.WriteLine("D            Display canvas");
            Console.WriteLine("H            Help");
            Console.WriteLine("Q            Quit Program");
            Console.WriteLine("R            Redo");
            Console.WriteLine("U            Undpo");


            string command = "";
            bool step = true;

            while (step)
            {
                command = Console.ReadLine();
                command = command.ToLower();
                string[] cmdArr = command.Split(" ");
                switch (cmdArr[0])
                {
                    case "a":
                        canvas.addShape(cmdArr[1]);
                        break;
                    case "c":
                        canvas.clear();
                        break;
                    case "d":
                        canvas.show();
                        break;
                    case "h":
                        Console.WriteLine("Commands");
                        Console.WriteLine("A <shape> [specific attributes]   Add Shape");
                        Console.WriteLine("C            Clear canvas");
                        Console.WriteLine("D            Display canvas");
                        Console.WriteLine("H            Help");
                        Console.WriteLine("Q            Quit Program");
                        Console.WriteLine("R            Redo");
                        Console.WriteLine("U            Undo");
                        Console.WriteLine();
                        Console.WriteLine("Specific Shape Commands:");
                        Console.WriteLine("Circle       [x][y][r]");
                        Console.WriteLine("Rectangle    [x][y][l][w]");
                        Console.WriteLine("Line         [x0][y0][x1][y1");
                        Console.WriteLine("Ellipse      [x][y][cx][cy");
                        Console.WriteLine();
                        break;
                    case "q":
                        var svgOut = new SVGFileCreator();
                        svgOut.createFile(canvas.model);
                        Console.WriteLine("Goodbye!");
                        step = true;
                        Environment.Exit(1);
                        break;
                    case "r":
                        canvas.redo();
                        break;
                    case "u":
                        canvas.undo();
                        break;
                    default:
                        Console.WriteLine("Invalid Entry, please try again");
                        break;
                }
            }


        }

    }
}
