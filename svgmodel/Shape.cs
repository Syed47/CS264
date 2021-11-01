using System;
using System.Collections.Generic;

namespace svgmodel
{
    public abstract class Shape
    {
        // common properties
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string fill { get; set; }
        public string stroke { get; set; }
        public string strokeWidth { get; set; }
        public string style { get; set; }

        public Shape() : this(0, 0, 0, 0) { }

        public Shape(int x, int y) : this(x, y, 0, 0) { }

        public Shape(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void SetFill() { fill = "none";  }
        public void SetStroke() { stroke = "black"; }
        public void SetStrokeWidth() { strokeWidth = "2"; }
        public void SetStyle() { style = ""; }

        public abstract string Tag();
    }
}
