using System;
using System.Collections.Generic;

namespace svgmodel
{
    public class Canvas
    {
        public int width { get; set; }
        public int height { get; set; }
        public List<BasicShape> shapes { get; set; }
        private readonly List<string> fileContent;

        public Canvas() : this(400, 400) { }

        public Canvas(int width, int height) : this(width, height, new()) { }

        public Canvas(int width, int height, List<BasicShape> shapes)
        {
            this.width = width;
            this.height = height;
            this.shapes = shapes;
            fileContent = new();
        }

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
                fileContent.Add("\t"+s.ToString());
            }
            fileContent.Add("</svg>");
            return fileContent;
        } 

        public void AddShape(BasicShape shape)
        {
            shapes.Add(shape);
        }

        public bool DeleteShape(BasicShape shape)
        {
            return shapes.Remove(shape);
        }

        public List<BasicShape> SortedShapes()
        {
            List<BasicShape> copy = new(); foreach (BasicShape s in shapes) copy.Add(s);

            copy.Sort(delegate (BasicShape x, BasicShape y)
            {
                //if (x.zindex < y.zindex) return -1;
                //else if (x.zindex > y.zindex) return 1;
                //else return 0;
                return x.zindex.CompareTo(y.zindex);
            });
            return copy;
        }
    }
}
