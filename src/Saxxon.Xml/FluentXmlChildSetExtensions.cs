// ReSharper disable UnusedMethodReturnValue.Global

using System;

namespace Saxxon.Xml
{
    public static class FluentXmlChildSetExtensions
    {
        public static IFluentXmlChildSet AddElement(this IFluentXmlChildSet obj, string name)
        {
            obj.CreateElement(name);
            return obj;
        }

        public static IFluentXmlChildSet AddElement(this IFluentXmlChildSet obj, string name, string value)
        {
            var element = obj.CreateElement(name);
            element.Value = value;
            return obj;
        }

        public static IFluentXmlChildSet AddElementUsing(this IFluentXmlChildSet obj, string name,
            Action<IFluentXmlElement> setup)
        {
            var element = obj.CreateElement(name);
            setup(element);
            return obj;
        }
    }
}