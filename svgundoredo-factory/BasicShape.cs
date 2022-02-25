using System;

/*
this is basic shape class. It is abstract by defualt because it's need to be
extended by a each shape. e.g. Circle class for creating circle shape.
It also provides basic styling for most of the shapes
 */
namespace svgundoredo
{
    public abstract class BasicShape : IComparable<BasicShape>
    {
        public IProperty zindex, stroke, strokeWidth, fill, style;

        public BasicShape()
        {
            zindex = StyleFactory.GetProperty("ZINDEX");
            stroke = StyleFactory.GetProperty("STROKE");
            strokeWidth = StyleFactory.GetProperty("STROKEWIDTH");
            fill = StyleFactory.GetProperty("FILL");
            style = StyleFactory.GetProperty("STYLE");
        }

        public void ReadUserDefineStyles()
        {
            IO.Println("[ STYLES ] <Enter the value or <enter> to skip>");
            IO.Print("Z-Index: "); zindex.Set(IO.ReadInt().ToString());
            IO.Print("Stroke: "); stroke.Set(IO.ReadString());
            IO.Print("StrokeWidth: "); strokeWidth.Set(IO.ReadString());
            IO.Print("Fill: "); fill.Set(IO.ReadString());
            IO.Print("Style: "); style.Set(IO.ReadString());
        }

        public int CompareTo(BasicShape other)
        {
            // A null value means that this object is greater.
            if (other == null)
                return 1;
            else
                return zindex.GetValue().CompareTo(other.zindex.GetValue());
        }

        public abstract void ReadUserDefinedProps();
        public abstract override string ToString();
    }
}
