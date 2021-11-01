using System;
namespace svgmodel
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

        public override void SetProps()
        {
            Console.WriteLine("*[ Enter the value or <enter> to skip ]*");

            Console.WriteLine("X: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Y: ");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Width: ");
            width = int.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            height = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return "<rect " +
                "x = \"" + x +
                "\" y = \"" + y +
                "\" width = \"" + width +
                "\" height = \"" + height +
                "\" stroke = \"" + stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" fill = \"" + fill +
                "\" style = \"" + style +
                "\" />";
        }
    }
}
