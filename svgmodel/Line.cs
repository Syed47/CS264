using System;
namespace svgmodel
{
    public class Line : BasicShape
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Line() : this(0, 0, 0, 0) { }

        public Line(int x1, int y1, int x2, int y2) : base()
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void SetProps()
        {
            Console.WriteLine("*[ Enter the value or <enter> to skip ]*");

            Console.WriteLine("X1: ");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Y1: ");
            y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("X2: ");
            x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Y2: ");
            y2 = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return "<line " +
                "x1 = \"" + x1 +
                "\" y1 = \"" + y1 +
                "\" x2 = \"" + x2 +
                "\" y2 = \"" + y2 +
                "\" stroke = \"" + stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" style = \"" + style +
                "\" />";
        }
    }
}
