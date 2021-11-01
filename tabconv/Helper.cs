using System;
using System.Collections.Generic;
using System.IO;

namespace tabconv
{
    public class Helper
    {   // all options/flags that can be passed to this program
        private readonly string[] validOptions = {
            "-v", "-verbose",
            "-i", "-info",
            "-o", "-output",
            "-l", "-list-formats",
            "-h", "-help"
        };
        // all valid formats that are supported
        private readonly string[] validFileFormats = {
            ".csv",
            ".html",
            ".json",
            ".md"
        };

        private string inFile; // file to read data from
        private string outFile; // file to write to
        private List<string> options; // program flags

        public Helper()
        {
            inFile = null;
            outFile = null;
            options = new List<string>();
        }

        public Helper(string cmd)
        {
            inFile = null;
            outFile = null;
            options = new List<string>();
            SetCommand(cmd);
        }

        public void SetCommand(string cmd)
        {
            foreach (string arg in cmd.Split(' '))
            {
                if (IsArg(arg))
                {
                    options.Add(arg); // flags/ options
                }
                else if (IsFileName(arg))
                {
                    if (inFile == null)
                    {
                        inFile = arg;
                    }
                    else
                    {
                        outFile = arg;
                    }
                }
            }
        }

        public string[] GetOptions()
        {
            return options.ToArray();
        }

        public string GetOutFile()
        {
            return outFile;
        }

        public string GetInFile()
        {
            return inFile;
        }

        public string GetInFileExt()
        {   // getting extension of in-file
            return inFile[inFile.IndexOf('.')..]; 
        }

        public string GetOutFileExt()
        {   // getting extension of out-file
            return outFile[outFile.IndexOf('.')..]; 
        }

        public void Debug(string s)
        {
            if (options.Contains("-v") || options.Contains("-verbose"))
            {
                Print("[DEBUG] "+s);
            }
        }

        public void EnableOutputFile()
        {
            if (options.Contains("-o") || options.Contains("-output"))
            {
                Print("Output File:");
                Print(outFile);
                Print("");
            }
        }

        public void EnableListFormats()
        {
            if (options.Contains("-l") || options.Contains("-list-formats"))
            {
                Print("List Formats:");
                Print(".html");
                Print(".json");
                Print(".csv");
                Print(".md");
                Print("");
            }
        }

        public void EnableHelp()
        {
            if (options.Contains("-h") || options.Contains("-help"))
            {
                Print("Help:");
                Print("tabconv -v -i <file.ext> -o <file.ext>");
                Print("-v, —verbose Verbose mode (debugging output to STDOUT");
                Print("-o <file>, —output=<file> Output file specified by <file>");
                Print("-l,	—list-formats List formats");
                Print("-h,	—help Show usage message");
                Print("-i,	—info Show version information");
                Print("<.ext> will be one of [ .html | .md | .csv | .json ]");
                Print("");
            }
        }

        public void EnableInfo()
        {
            if (options.Contains("-i") || options.Contains("-info"))
            {
                Print("Info:");
                Print("tabconv version beta 1.0.0");
                Print("C# version 5.0.401");
                Print("");
            }
        }

        public string[] ReadFile()
        {
            if (inFile == null)
            {
                Print("Cannot read from file name= null");
                return null;
            }
            return File.ReadAllLines(inFile);
        }

        public void WriteFile(string[] lines)
        {
            if (outFile == null)
            {
                Debug("Cannot write to null file");
                return;
            }
            File.WriteAllLines(GetOutFile(), lines);
        }

        public void Print(string s)
        {
            Console.WriteLine(s);
        }

        private bool IsArg(string token)
        {
            foreach (string t in validOptions)
            {
                if (string.Equals(t, token)) { return true; }
            }
            return false;
        }

        private bool IsFileName(string token)
        {
            foreach (string t in validFileFormats)
            {
                if (token.EndsWith(t)) { return true; }
            }
            return false;
        }
    }
}
