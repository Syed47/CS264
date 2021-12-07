using System;
namespace svgundoredo
{
    public class Path : BasicShape
    {
        public string path { get; set; }

        public Path() : this("") { }

        public Path(string path) : base()
        {
            this.path = path;
        }

        public override void ReadUserDefinedProps()
        {
            IO.Println("*[ Enter the value or <Q|q> to skip ]*");
            IO.Print("Path:"); path = IO.ReadString();
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
