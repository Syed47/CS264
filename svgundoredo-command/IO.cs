using System;
using System.IO;

/*
this class contains all the basic IO functionalilty this program require
    e.g. printing to console, saving to file, reading user input etc.
 */

namespace svgundoredo
{
    public class IO
    {
        public static void SaveToFile(string pathOrFileName, string[] contents)
        {
            File.WriteAllLines(pathOrFileName, contents);
            Println("File Saved");
            Println("");
        }

        public static void Print(string s)
        {
            Console.Write(s);
        }

        public static void Println(string s)
        {
            Console.WriteLine(s);
        }

        public static string ReadString()
        {
            return Console.ReadLine();
        }

        public static int ReadInt()
        {
            return int.Parse(ReadString());
        }
    }
}
