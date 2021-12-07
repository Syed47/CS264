using System;
namespace svgundoredo
{
    public class Ellipse : BasicShape
    {
        public int cx { get; set; }
        public int cy { get; set; }
        public int rx { get; set; }
        public int ry { get; set; }

        public Ellipse() : this(0, 0, 0, 0) { }

        public Ellipse(int cx, int cy, int rx, int ry) : base()
        {
            this.cx = cx;
            this.cy = cy;
            this.rx = rx;
            this.ry = ry;
        }

        public override void ReadUserDefinedProps()
        {
            IO.Println("*[ Enter the value or <enter> to skip ]*\n");
            IO.Print("CX: "); cx = IO.ReadInt();
            IO.Print("CY: "); cy = IO.ReadInt();
            IO.Print("RX: "); rx = IO.ReadInt();
            IO.Print("RY: "); ry = IO.ReadInt();
        }

        public override string ToString()
        {
            return "<ellipse " +
                "cx = \"" + cx +
                "\" cy = \"" + cy +
                "\" rx = \"" + rx +
                "\" ry = \"" + ry +
                "\" stroke = \"" + stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" fill = \"" + fill +
                "\" style = \"" + style +
                "\" />";
        }
        
    }
}
