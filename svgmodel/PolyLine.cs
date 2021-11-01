using System;

namespace svgmodel
{
    public class PolyLine : BasicShape
    {

        protected string points = "";

        public PolyLine() : this("0,0") { }

        public PolyLine(string points) : base()
        {
            this.points = points.Trim();
        }

        public override void SetProps()
        {
            Console.WriteLine("*[ Enter the points in svg format. <Q|q> to skip ] *");
            string points = Console.ReadLine().Trim().ToUpper();
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
