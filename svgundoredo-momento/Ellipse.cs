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
            Println("*[ Enter the value or <enter> to skip ]*\n");
            Print("CX: "); cx = ReadInt();
            Print("CY: "); cy = ReadInt();
            Print("RX: "); rx = ReadInt();
            Print("RY: "); ry = ReadInt();
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
