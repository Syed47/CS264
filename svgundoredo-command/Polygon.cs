using System;
namespace svgundoredo
{
    public class Polygon : BasicShape
    {

        protected string points = "";
        protected string start;

        public Polygon() : this("0,0") { }

        public Polygon(string _points) : base()
        {
            points = _points.Trim();
            start = points.Substring(0, 3);
        }

        public override void ReadUserDefinedProps()
        {
            IO.Println("*[ Enter the value or <Q|q> to stop ]*");
            IO.Print("Points: ");
            string points = IO.ReadString().Trim().ToUpper();
            if (points[0] == 'Q') return;
            this.points = points+" "+start[0] + "," + start[1];
        }

        public override string ToString()
        {
            return "<polygon " +
                "points = \"" + points +
                "\" stroke = \"" + stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" fill = \"" + fill +
                "\" style = \"" + style +
                "\" />";
        }
    }
}
