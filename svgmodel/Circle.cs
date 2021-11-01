using System;
namespace svgmodel
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

        public override void SetProps()
        {
            Console.WriteLine("*[ Enter the value or <enter> to skip ]*");

            Console.WriteLine("X: ");
            cx = int.Parse(Console.ReadLine());
            Console.WriteLine("Y: ");
            cy = int.Parse(Console.ReadLine());
            Console.WriteLine("Radius: ");
            r = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return "<circle cx = \"" + cx +
                "\" cy = \"" + cy +
                "\" r = \"" + r +
                "\" stroke = \""+ stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" fill = \""+ fill +
                "\" style = \"" + style +
                "\" />";
        }
    }
}
