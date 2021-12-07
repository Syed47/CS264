using System;
using System.IO;

/*
this class contains all the basic IO functionalilty this program require
    e.g. printing to console, saving to file, reading user input etc.
 */

namespace svgundoredo
{
    public abstract class BasicIO
    {
        public void SaveToFile(string pathOrFileName, string[] contents)
        {
            File.WriteAllLines(pathOrFileName, contents);
            Println("File Saved");
            Println("");
        }

        public void Print(string s)
        {
            Console.Write(s);
        }

        public void Println(string s)
        {
            Console.WriteLine(s);
        }

        public string ReadString()
        {
            return Console.ReadLine();
        }

        public int ReadInt()
        {
            return int.Parse(ReadString());
        }
    }
}
