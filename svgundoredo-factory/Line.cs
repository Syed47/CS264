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
            IO.Println("*[ Enter the value or <enter> to skip ]*");
            IO.Print("X1: "); x1 = IO.ReadInt();
            IO.Print("Y1: "); y1 = IO.ReadInt();
            IO.Print("X2: "); x2 = IO.ReadInt();
            IO.Print("Y2: "); y2 = IO.ReadInt();
        }

        public override string ToString()
        {
            return "<line " +
                "x1 = \"" + x1 +
                "\" y1 = \"" + y1 +
                "\" x2 = \"" + x2 +
                "\" y2 = \"" + y2 +
                "\" stroke = \"" + stroke.GetValue() +
                "\" stroke-width = \"" + strokeWidth.GetValue() +
                "\" style = \"" + style.GetValue() +
                "\" />";
        }
    }
}
