using System;
namespace svgundoredo
{
    public class StyleFactory
    {
        public static IProperty GetProperty(string property)
        {
            return property.ToUpper() switch
            {
                "ZINDEX" => new ZIndex(),
                "STROKE" => new Stroke(),
                "STROKEWIDTH" => new StrokeWidth(),
                "FILL" => new Fill(),
                "STYLE" => new Style(),
                _ => null
            };
        }
    }

    public interface IProperty
    {
        public void Set(string value);
        public string GetKey();
        public string GetValue();
    }

    public abstract class PropertyCreator : IProperty
    {
        private string key, value;
        protected PropertyCreator(string key)
        {
            this.key = key;
            this.value = null;
        }

        public void Set(string value)
        {
            this.value = value;
        }

        public string GetKey()
        {
            return key;
        }

        public string GetValue()
        {
            return value;
        }
    }

    class Fill : PropertyCreator
    {
        public Fill() : base("fill") { }
    }

    class ZIndex : PropertyCreator
    {
        public ZIndex() : base("z-index") { }
    }

    class Stroke : PropertyCreator
    {
        public Stroke() : base("stroke") { }
    }

    class StrokeWidth : PropertyCreator
    {
        public StrokeWidth() : base("stroke-width") { }
    }

    class Style : PropertyCreator
    {
        public Style() : base("style") { }
    }
}
