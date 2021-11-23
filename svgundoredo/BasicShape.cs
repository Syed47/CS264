using System;

/*
this is basic shape class. It is abstract by defualt because it's need to be
extended by a particuler shape. e.g. Circle class for creating circle shape.
It also provides basic styling for most of the shapes
It's extended by all the shape classes
 */
namespace svgundoredo
{
    public abstract class BasicShape : BasicIO, IComparable<BasicShape>
    {

        public int zindex { get; set; }
        public string style { get; set; }
        public string stroke { get; set; }
        public string strokeWidth { get; set; }
        public string fill { get; set; }
        // default constructor
        public BasicShape() : this (0, "", "black", "1", "none") { }
        // general constructor
        public BasicShape(int zindex, string style, string stroke, string strokeWidth, string fill)
        {
            SetStyle(zindex, style, stroke, strokeWidth, fill);
        }

        public void SetStyle (int zindex, string style, string stroke, string strokeWidth, string fill)
        {
            this.zindex = zindex;
            this.style = style;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.fill = fill;
        }

        public void ReadUserDefineStyles()
        {
            Println("[ STYLES ] <Enter the value or <enter> to skip>");

            Print("Z-Index: "); zindex = ReadInt();
            Print("Stroke: "); stroke = ReadString();
            Print("StrokeWidth: "); strokeWidth = ReadString();
            Print("Fill: "); fill = ReadString();
            Print("Style: "); style = ReadString();
        }

        public int CompareTo(BasicShape other)
        {
            // A null value means that this object is greater.
            if (other == null)
                return 1;
            else
                return zindex.CompareTo(other.zindex);
        }

        public abstract void ReadUserDefinedProps();
        public abstract override string ToString();
    }
}
