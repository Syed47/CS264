using System;
namespace svgundoredo
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

        public override void ReadUserDefinedProps()
        {
            Println("*[ Enter the value or <enter> to skip ]*");
            Print("X1: "); x1 = ReadInt();
            Print("Y1: "); y1 = ReadInt();
            Print("X2: "); x2 = ReadInt();
            Print("Y2: "); y2 = ReadInt();
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
