using System.Collections.Generic;
/*
 this Canvas class extends the Generic CommandDesign class which we can use
 to add or remove shapes.
 */
namespace svgundoredo
{
    public class Canvas : CommandDesign
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public readonly List<BasicShape> shapes;

        // default constructor
        public Canvas() : this(800, 800) { }
        // general constructor
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            shapes = new List<BasicShape>();
        }

        public string AddShape(BasicShape shape)
        {
            Execute(new AddShapeCommand(this, shape));
            return shape.ToString();
        }

        // returns the sorted shapes based on z-index
        public List<BasicShape> SortedShapes()
        {
            List<BasicShape> copy = new();
            foreach (BasicShape s in shapes) copy.Add(s);
            // anonymous class to compare two BasicShapes based on z-index
            copy.Sort(delegate (BasicShape x, BasicShape y)
            {
                return x.zindex.GetValue().CompareTo(y.zindex.GetValue());
            });
            return copy;
        }

        // return the content of svg file (final output file)
        public List<string> GetFileContent()
        {
            List<string> fileContent = new();
            fileContent.Clear();
            fileContent.Add("<svg " +
                "width=\"" + Width +
                "\" height=\"" + Height +
                "\" xmlns=\"http://www.w3.org/2000/svg\">");
            var shapes = SortedShapes();
            foreach (BasicShape s in shapes)
            {
                fileContent.Add("\t" + s.ToString());
            }
            fileContent.Add("</svg>");
            return fileContent;
        }

        public override string ToString()
        {
            string s = "";
            foreach(string tag in GetFileContent())
            {
                s += tag + "\n";
            }
            return s;
        }
    }
}
