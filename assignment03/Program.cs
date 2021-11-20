using System;

namespace assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opening Remarks of the program
            Console.WriteLine();
            var canvas = new Canvas();
            Console.WriteLine();
            Console.WriteLine("Canvas created - use commands to add, undo & redo shapes on the canvas");
            Console.WriteLine("A <shape>:<s>    Add Shape (add :s to input styles)");
            Console.WriteLine("C                Clear canvas");
            Console.WriteLine("D                Display canvas");
            Console.WriteLine("H                Help");
            Console.WriteLine("Q                Quit Program");
            Console.WriteLine("R                Redo");
            Console.WriteLine("U                Undo");


            string command = "";
            bool step = true;

            // While loop  to loop through the commands
            while (step)
            {
                command = Console.ReadLine();
                command = command.ToLower();
                string[] cmdArr = command.Split(" ");
                switch (cmdArr[0])
                {

                    case "a":                                       // Add a shape
                        canvas.addShape(cmdArr[1]);
                        break;
                    case "c":                                       // Clear the canvas
                        canvas.clear();
                        Console.WriteLine("Canvas Cleared!");
                        break;
                    case "d":                                       // Display the canvas
                        canvas.show();
                        break;
                    case "h":
                        Console.WriteLine();                        // Display Help
                        Console.WriteLine("Commands");
                        Console.WriteLine("A <shape>:<s>    Add Shape");
                        Console.WriteLine("C                Clear canvas");
                        Console.WriteLine("D                Display canvas");
                        Console.WriteLine("H                Help");
                        Console.WriteLine("Q                Quit Program");
                        Console.WriteLine("R                Redo");
                        Console.WriteLine("U                Undo");
                        Console.WriteLine();
                        break;
                    case "q":                                       // Quit
                        var svgOut = new SVGFileCreator();          // Method to create svg files
                        svgOut.createFile(canvas);
                        Console.WriteLine("SVG saved to svg/output.svg");
                        Console.WriteLine("Goodbye!");
                        step = true;                                // to exit the loop
                        Environment.Exit(1);                        // to exit the code
                        break;
                    case "r":                                       // Redo
                        canvas.redo();
                        Console.WriteLine("Redo");
                        break;
                    case "u":                                       // Undo
                        canvas.undo();
                        Console.WriteLine("Undo");
                        break;
                    default:
                        Console.WriteLine("Invalid Entry, please try again");
                        break;
                }
            }


        }

    }
}
