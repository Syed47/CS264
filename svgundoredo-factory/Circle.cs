using System;
namespace svgundoredo
{
    public class Circle : BasicShape
    {
        public int r { get; set; }
        public int cx { get; set; }
        public int cy { get; set; }

        public Circle() : this(0, 0, 0) { }

        public Circle(int r, int cx, int cy) : base() {
            this.r = r;
            this.cx = cx;
            this.cy = cy;
        }

        public override void ReadUserDefinedProps()
        {
            IO.Print("X: "); cx = IO.ReadInt();
            IO.Print("Y: "); cy = IO.ReadInt();
            IO.Print("Radius: "); r = IO.ReadInt();
        }

        public override string ToString()
        {
            return "<circle cx = \"" + cx +
                "\" cy = \"" + cy +
                "\" r = \"" + r +
                "\" stroke = \""+ stroke.GetValue() +
                "\" stroke-width = \"" + strokeWidth.GetValue() +
                "\" fill = \""+ fill.GetValue() +
                "\" style = \"" + style.GetValue() +
                "\" />";
        }
    }
}
