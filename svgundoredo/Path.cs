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
            Println("*[ Enter the value or <Q|q> to skip ]*");
            Print("Path:"); path = ReadString();
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
