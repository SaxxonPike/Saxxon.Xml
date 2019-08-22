// ReSharper disable UnusedMethodReturnValue.Global

using System;
using System.Linq;

namespace Saxxon.Xml
{
    public static class FluentXmlChildSetExtensions
    {
        public static IFluentXmlChildSet AddComment(this IFluentXmlChildSet obj, string content)
        {
            var comment = obj.CreateComment();
            comment.Value = content;
            return obj;
        }

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

        public static IFluentXmlChildSet AddText(this IFluentXmlChildSet obj, string content)
        {
            var text = obj.CreateText();
            text.Value = content;
            return obj;
        }

        public static IFluentXmlChildSet RemoveWhere(this IFluentXmlChildSet obj,
            Func<IFluentXmlObject, bool> predicate)
        {
            foreach (var node in obj.Where(predicate).ToArray())
                obj.Remove(node);
            return obj;
        }
    }
}