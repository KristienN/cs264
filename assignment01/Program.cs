// Place file to convert into the test folder, then use the CLI to convert file to a different format
// PRogram uses a Tabconv class which includes methods to convert it to a 2D array in the program memory, then out the file to the selected format;

using System;

namespace assignment01
{
    class Program
    {
        static void Main(string[] args)
        {


            // styling the termal
            Console.ForegroundColor= ConsoleColor.Blue;

            
            string cmd = null;
            string inputFilePath, outputFile;
            cmd = Console.ReadLine();
            bool v, i, o, h, l;

            // Program to be case insensitive
            cmd = cmd.ToLower();


            // spliting up the CLI commands to get the differnt options and file paths
            string[] cmdArray = cmd.Split(" ");
            outputFile = cmdArray[cmdArray.Length-1];
            inputFilePath = @"test/" + cmdArray[cmdArray.Length-3];


            if(cmdArray[0] == "tabconv"){
                v = false;
                i = false;
                o = false;
                h = false;
                l = false;


                // switch case to select optinos from readline
                for(int k = 0; k < cmdArray.Length; k++){
                    switch(cmdArray[k]){
                        case "-v":
                            v = true;
                            break;
                        case "-i":
                            i = true;
                            break;
                        case "-o":
                            o = true;
                            break;
                        case "-l":
                            l = true;
                            break;
                        case "-h":
                            h = true;
                            break;
                        default:
                            break;
                    }
                }


                // creating a new tabconv to convert the file
                var converter = new Tabconv(inputFilePath, outputFile, v, i, o, l, h);
                

            }




        }
    }
}
