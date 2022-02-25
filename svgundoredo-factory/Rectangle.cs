using System;
namespace svgundoredo
{
    public class Rectangle : BasicShape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Rectangle() : this(0, 0, 0, 0) { }

        public Rectangle(int x, int y, int width, int height) : base()
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override void ReadUserDefinedProps()
        {
            IO.Print("X: "); x = IO.ReadInt();
            IO.Print("Y: "); y = IO.ReadInt();
            IO.Print("Width: "); width = IO.ReadInt();
            IO.Print("Height: "); height = IO.ReadInt();
        }

        public override string ToString()
        {
            return "<rect " +
                "x = \"" + x +
                "\" y = \"" + y +
                "\" width = \"" + width +
                "\" height = \"" + height +
                "\" stroke = \"" + stroke.GetValue() +
                "\" stroke-width = \"" + strokeWidth.GetValue() +
                "\" fill = \"" + fill.GetValue() +
                "\" style = \"" + style.GetValue() +
                "\" />";
        }
    }
}
