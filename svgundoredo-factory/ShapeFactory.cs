using System;
namespace svgundoredo
{
    abstract public class ShapeFactory
    {
        public enum Shape { CIRCLE, RECT, ELLIPSE, LINE, POLYLINE, POLYGON, PATH, NULL };

        public static BasicShape GetShape(string name)
        {
            Shape shape = name switch
            {
                "CIRCLE" => Shape.CIRCLE,
                "RECT" => Shape.RECT,
                "ELLIPSE" => Shape.ELLIPSE,
                "LINE" => Shape.LINE,
                "POLYLINE" => Shape.POLYLINE,
                "POLYGON" => Shape.POLYGON,
                "PATH" => Shape.PATH,
                _ => Shape.NULL,
            };
            return GetShape(shape);
        }

        private static BasicShape GetShape(Shape shape)
        {
            return shape switch
            {
                Shape.CIRCLE => new Circle(),
                Shape.RECT => new Rectangle(),
                Shape.ELLIPSE => new Ellipse(),
                Shape.LINE => new Line(),
                Shape.POLYLINE => new PolyLine(),
                Shape.POLYGON => new Polygon(),
                Shape.PATH => new Path(),
                Shape.NULL => null,
                _ => null
            };
        }

    }
}
