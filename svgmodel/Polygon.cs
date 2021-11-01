using System;
namespace svgmodel
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

        public override void SetProps()
        {
            Console.WriteLine("*[ Enter the value or <Q|q> to stop ]*");
            string points = Console.ReadLine().Trim();
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
