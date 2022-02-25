/*

Assignment 5

*/

namespace svgundoredo
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI program = new(new Canvas(), "canvas.svg");
            program.Run();
        }
    }
}