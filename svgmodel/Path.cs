using System;
namespace svgmodel
{
    public class Path : BasicShape
    {
        public string path { get; set; }

        public Path() : this("") { }

        public Path(string path) : base()
        {
            this.path = path;
        }

        public override void SetProps()
        {
            Console.WriteLine("*[ Enter the value or <Q|q> to skip ]*");
            Console.Write(":");
            path = Console.ReadLine();
        }

        public override string ToString()
        {
            return "<path " +
                " points = \"" + path +
                "\" stroke = \"" + stroke +
                "\" stroke-width = \"" + strokeWidth +
                "\" fill = \"" + fill +
                "\" style = \"" + style +
                "\" />";
        }
    }
}
