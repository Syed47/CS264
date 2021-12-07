using System;

namespace svgundoredo
{
    public class PolyLine : BasicShape
    {

        protected string points = "";

        public PolyLine() : this("0,0") { }

        public PolyLine(string points) : base()
        {
            this.points = points.Trim();
        }

        public override void ReadUserDefinedProps()
        {
            IO.Println("*[ Enter the points in svg format. <Q|q> to skip ] *");
            IO.Print("Points: ");
            string points = IO.ReadString().Trim().ToUpper();
            if (points[0] == 'Q') return;
            this.points = points;
        }

        public override string ToString()
        {
            return "<polyline " +
                "points = \"" + points +
                "\" stroke = \"" + stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" fill = \"" + fill +
                "\" style = \"" + style +
                "\" />";
        }
    }
}
