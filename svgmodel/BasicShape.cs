using System;
namespace svgmodel
{
    public abstract class BasicShape : IComparable<BasicShape>
    {

        public int zindex { get; set; }
        public string style { get; set; }
        public string stroke { get; set; }
        public string strokeWidth { get; set; }
        public string fill { get; set; }

        public BasicShape() : this (0, "", "black", "1", "none") { }

        public BasicShape(int zindex, string style, string stroke, string strokeWidth, string fill)
        {
            SetStyle(zindex, style, stroke, strokeWidth, fill);
        }

        public abstract override string ToString();
        public abstract void SetProps();

        public void SetStyle (int zindex, string style, string stroke, string strokeWidth, string fill)
        {
            this.zindex = zindex;
            this.style = style;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.fill = fill;
        }

        public void SetStyle()
        {
            Console.WriteLine("[ STYLES ]");
            Console.WriteLine("[ Enter value or <enter> to skip ]\n");

            Console.Write("Z-Index: ");
            zindex = int.Parse(Console.ReadLine());

            Console.Write("Stroke: ");
            stroke = Console.ReadLine();

            Console.Write("StrokeWidth: ");
            strokeWidth = Console.ReadLine();

            Console.Write("Fill: ");
            fill = Console.ReadLine();

            Console.Write("Style: ");
            style = Console.ReadLine();
        }

        public int CompareTo(BasicShape other)
        {
            // A null value means that this object is greater.
            if (other == null)
                return 1;
            else
                return zindex.CompareTo(other.zindex);
        }
    }
}
