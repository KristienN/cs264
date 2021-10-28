using System;
using System.IO;
using System.Collections.Generic;

// NuGet PAckgae manager unfortunately would not install these packages to parse HTML & JSON
// using HtmlAgilityPack;
// using Newtonsoft.json

namespace assignment01
{
    public class Tabconv
    {
        // booleans for the options
        bool v, i, o, l, h;
        string inputFile, outputFile;
        public string[][] array_table;

        public Tabconv(){
            v = false;
            i = false;
            o = false;
            l = false;
            h = false; 
        }


        public Tabconv(string inputFile, string outputFile, bool v, bool i, bool o, bool l, bool h){
            this.v = v;
            this.i = i;
            this.o = o;
            this.l = l;
            this.h = h;
            this.inputFile = inputFile;
            this.outputFile = outputFile;


            if(i){
                Console.WriteLine("tabconv version 1.0.0");
                Console.WriteLine("c# .NET version 5.0.401");
            }

            if(l){
                Console.WriteLine("Formats:");
                Console.WriteLine(".csv");
                Console.WriteLine(".html");
                Console.WriteLine(".md");
                Console.WriteLine(".json");
            }

            if(h){
                Console.WriteLine(@"This	app	will	provide	funcConality	to	convert	between	different	markup	 formats	 for	 tabular	data,	 for	example,	it	will	convert	between	CSV	 (Comma	Separated	Values),	MD	 (Markdown),	 JSON	 (JavaScript	Object	NotaCon,	and	HTML-TABLE	 (HTML	<table>	element)	 formats.CLI	(command-line	interface)	user	interface	along	the	lines	for	the	following:	
tabconv		-v	-i	<file.ext>	-o	<file.ext>	
	 -v,	—verbose	 	 	 	 Verbose	mode	(debugging	output	to	STDOUT)	
	 -o	<file>,	—output=<file>	 Output	file	specified	by	<file>	
	 -l,	—list-formats	 	 	 List	formats	
	 -h,	—help		 	 	 	 Show	usage	message	
	 -i,	—info		 	 	 	 Show	version	information		
<.ext>	will	be	one	of	[.html	|	.md	|	.csv	|	.json]	");
            }


            

            if(o){
                ToArray(inputFile);
                ToOutput(outputFile);
            }
            

        }


        // method containing switch case to convert diffrent formats to 2d array
        public void ToArray(string inputPath){
            string[] ext = inputPath.Split(".");
            switch(ext[1]){
                case "csv":
                    array_table = fromCSV(inputPath);
                    break;
                case "md":
                    array_table = fromMD(inputPath);
                    break;
                // case "html":
                //     fromHTML();
                //     break;
                // case "json":
                //     fromJSON(inputPath);
                //     break;
                default:
                    break;
            }

        }


        //  method containing switch case to convert 2d array to different formats
        public void ToOutput(string outputPath){
            string[] ext = outputPath.Split(".");
            switch(ext[1]){
                case "csv":
                    toCSV(outputPath);
                    break;
                case "html":
                    toHTML(outputPath);
                    break;
                case "json":
                    toJSON(outputPath);
                    break;
                case "md":
                    toMD(outputPath);
                    break;
                default:
                    break;
            }
        }

        // public static void fromHTML(string inputPath){
        //     HtmlDocument doc = new HtmlDocument();
        //     doc.Load(inputPath);
        //     HtmlNode[] h_nodes = doc.DocumentNode.SelectNodes("//th").ToArray();
        //     HtmlNode[] d_nodes = doc.DocumentNode.SelectNodes("//td").ToArray();

        //     foreach(HtmlNode item in h_nodes){
        //         Console.WriteLine(item.InnerHtml);
        //     }
        // }

        // method to parse Comma seperated values
        public string[][] fromCSV(string inputFile){
            if(this.v){
                Console.WriteLine("Reading file...");
            }
            StreamReader sr = new StreamReader(inputFile);
            var lines = new List<string[]>();
            while(!sr.EndOfStream){
                string[] line = sr.ReadLine().Split(",");
                foreach(string l in line){
                    l.Replace("\"", "");
                }
                lines.Add(line);
            }

            if(this.v){
                Console.WriteLine("Converting .csv to array...");
            }

            return lines.ToArray();

        }

        // method to parse Markdown
        public string[][] fromMD(string inputFile){
            if(this.v){
                Console.WriteLine("Reading file...");
            }
            StreamReader sr = new StreamReader(inputFile);
            var lines = new List<string[]>();
            int count = 0;
            while(!sr.EndOfStream){
                string[] line = sr.ReadLine().Substring(1).Split("|");
                for(int i = 1; i< line.Length-1; i++){
                    line[i].Trim();
                    line[i].Trim(' ');
                }

                if(count!=1){
                    lines.Add(line);
                }

                count++;

            }

            if(this.v){
                Console.WriteLine("Converting .csv to array...");
            }
            return lines.ToArray();
        }

        // public string[][] fromJSON(string input){

        //     StreamReader sr = new StreamReader(input);
        //     List<string[]> table = new List<string[]>();
        //     List<string> headers = new List<string>();
        //             List<string> values = new List<string>();
        //     while(!sr.EndOfStream){
        //         string line = sr.ReadLine().Trim();
        //         if(line!="[" || line!="{" || line!="}" || line !="]"){
        //             string[] temp = line.Split(":");
                    

        //             foreach(string t in temp){ 
        //                 headers.Add(temp[0]);
        //                 values.Add(temp[1]);

        //             }

                    


        //         }
        //     }

        //     string[] array_h = headers.ToArray();
        //     string[] array_v = values.ToArray();
        //     table.Add(array_h);
        //     table.Add(array_v);

        // }

        // method to convert to comma seperated values
        public void toCSV(string output){
            if(this.v){
                Console.WriteLine("Creating new csv file...");
            }

            try{
                using(StreamWriter sw = File.CreateText(@"test/" + output)){
                    
                    for(int i = 0; i < array_table.Length; i++){
                        string line = "";

                        for(int j = 0; j < array_table[i].Length; j++){
                            line += array_table[i][j] +","; 
                        }

                        sw.WriteLine(line);
                    }

                    if(this.v){
                Console.WriteLine("Conversion succesful. No errors.");
            }
                }
            } catch(Exception ext){
                Console.WriteLine("Error: {0}", ext.ToString());
            }
        }


        // method to convert to JSON
        public void toJSON(string output){

            if(this.v){
                Console.WriteLine("Creating new csv file...");
            }

            try{
                using(StreamWriter sw = File.CreateText(@"test/" + output)){

                    sw.WriteLine("[");
                    
                    for(int i = 1; i < array_table.Length; i++){
                        sw.WriteLine("  {");

                        for(int j = 0; j < array_table[i].Length; j++){
                            sw.WriteLine("      " + array_table[0][j] + ":" + array_table[i][j] + ",");
                        }

                        sw.WriteLine("  },");
                    }

                    sw.WriteLine("]");
                }
            } catch(Exception ext){
                Console.WriteLine("Error: {0}", ext.ToString());
            }

            if(this.v){
                Console.WriteLine("Conversion succesful. No errors.");
            }
        }


        //  method to convert to HTML
        public void toHTML(string output){

            if(this.v){
                Console.WriteLine("Creating new html file...");
            }

            try{
                using(StreamWriter sw = File.CreateText(@"test/" + output)){

                    
                    
                    for(int i = 0; i < array_table.Length; i++){
                        sw.WriteLine("<tr>");

                        for(int j = 0; j < array_table[i].Length; j++){
                            if(i == 0){
                                sw.WriteLine("  <th>" + array_table[i][j].Trim('"') + "</th>");
                            } else {
                                sw.WriteLine("  <td>" + array_table[i][j].Trim('"') + "</td>");
                            }
                            
                        }

                        sw.WriteLine("</tr>");
                    }

                    
                }
            } catch(Exception ext){
                Console.WriteLine("Error: {0}", ext.ToString());
            }

            if(this.v){
                Console.WriteLine("Conversion succesful. No errors.");
            }
        }


        // Method to convert to markdown
        public void toMD(string output){
            if(this.v){
                Console.WriteLine("Creating new md file...");
            }

            try{
                using(StreamWriter sw = File.CreateText(@"test/" + output)){

                    for(int i = 0; i < array_table.Length; i++){
                        string line = "|";
                        for(int j = 0; j < array_table[i].Length; j++){
                            
                            line += array_table[i][j].Trim('"') + "|";
                            
                        }

                        sw.WriteLine(line);
                        if(i == 0){
                            string headline = "|";
                            for(int j = 0; j < array_table[i].Length; j++){
                        
                                headline +="------|";
                                
                            }

                            sw.WriteLine(headline);
                        }
                    }

                    
                }
            } catch(Exception ext){
                Console.WriteLine("Error: {0}", ext.ToString());
            }

            if(this.v){
                Console.WriteLine("Conversion succesful. No errors.");
            }
        }
        
        
    }
}