// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Linq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static IFluentXmlChildSet AppendComment(this IFluentXmlChildSet obj, string content)
        {
            var comment = obj.CreateComment();
            comment.Value = content;
            return obj;
        }

        public static IFluentXmlChildSet AppendComment(this IFluentXmlChildSet obj, Action<IFluentXmlComment> setup)
        {
            var comment = obj.CreateComment();
            setup(comment);
            return obj;
        }

        public static IFluentXmlChildSet AppendElement(this IFluentXmlChildSet obj, string name)
        {
            obj.CreateElement(name);
            return obj;
        }

        public static IFluentXmlChildSet AppendElement(this IFluentXmlChildSet obj, string name,
            Action<IFluentXmlElement> setup)
        {
            var element = obj.CreateElement(name);
            setup(element);
            return obj;
        }

        public static IFluentXmlChildSet AppendText(this IFluentXmlChildSet obj, string content)
        {
            var text = obj.CreateText();
            text.Value = content;
            return obj;
        }

        public static IFluentXmlChildSet AppendText(this IFluentXmlChildSet obj, Action<IFluentXmlText> setup)
        {
            var text = obj.CreateText();
            setup(text);
            return obj;
        }

        public static IFluentXmlChildSet GetOrAppendElement(this IFluentXmlChildSet obj, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (!obj.Any(x => name == x?.Name))
                obj.CreateElement(name);
            return obj;
        }

        public static IFluentXmlChildSet GetOrAppendElement(this IFluentXmlChildSet obj, string name,
            Action<IFluentXmlElement> setup)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var element = obj
                              .OfType<IFluentXmlElement>()
                              .FirstOrDefault(x => name == x?.Name) ??
                          obj.CreateElement(name);
            setup(element);
            return obj;
        }

        public static IFluentXmlChildSet RemoveWhere(this IFluentXmlChildSet obj,
            Func<IFluentXmlNode, bool> predicate)
        {
            foreach (var node in obj.Where(predicate).ToArray())
                obj.Remove(node);
            return obj;
        }
    }
}