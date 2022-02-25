using System;
/*
Assignment 2
*/
namespace svgmodel
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI cli = new(new Canvas(600, 600));
            cli.Run();
        }
    }
}