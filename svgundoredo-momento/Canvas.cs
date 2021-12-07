using System;
using System.Collections.Generic;


/*
 this Canvas class extends the Generic MomentoDesign class to which we can
add or remove objects (Shapes in this case).
 */
namespace svgundoredo
{
    public class Canvas : MomentoDesign<BasicShape>
    {
        public int width { get; set; }
        public int height { get; set; }
        private readonly List<string> fileContent;

        // default constructor
        public Canvas() : this(600, 600) { }
        // general constructor
        public Canvas(int width, int height)
        {
            this.width = width;
            this.height = height;
            fileContent = new();
        }

        public string AddShape(BasicShape shape)
        {
            return AddState(shape);
        }

        // returns the sorted shapes based on z-index
        public List<BasicShape> SortedShapes()
        {
            List<BasicShape> copy = new();
            foreach (BasicShape s in GetStates()) copy.Add(s);
            // anonymous class to compare two BasicShapes based on z-index
            copy.Sort(delegate (BasicShape x, BasicShape y)
            {
                return x.zindex.CompareTo(y.zindex);
            });
            return copy;
        }

        // return the content of svg file (final output file)
        public List<string> GetFileContent()
        {
            fileContent.Clear();
            fileContent.Add("<svg " +
                "width=\"" + width +
                "\" height=\"" + height +
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
