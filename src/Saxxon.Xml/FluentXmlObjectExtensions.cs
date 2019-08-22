// ReSharper disable UnusedMethodReturnValue.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml
{
    public static class FluentXmlObjectExtensions
    {
        public static T AppendComment<T>(this T obj, string content) where T : IFluentXmlNode
        {
            obj?.Children.AppendComment(content);
            return obj;
        }

        public static T AppendComment<T>(this T obj, Action<IFluentXmlComment> setup) where T : IFluentXmlNode
        {
            obj?.Children.AppendComment(setup);
            return obj;
        }

        public static T AppendElement<T>(this T obj, string name) where T : IFluentXmlNode
        {
            obj?.Children.AppendElement(name);
            return obj;
        }

        public static T AppendElement<T>(this T obj, string name, Action<IFluentXmlElement> setup)
            where T : IFluentXmlNode
        {
            obj?.Children.AppendElement(name, setup);
            return obj;
        }

        public static T AppendText<T>(this T obj, string content) where T : IFluentXmlNode
        {
            obj?.Children.AppendText(content);
            return obj;
        }

        public static T AppendText<T>(this T obj, Action<IFluentXmlText> setup) where T : IFluentXmlNode
        {
            obj?.Children.AppendText(setup);
            return obj;
        }

        public static T RemoveAttribute<T>(this T obj, string name) where T : IFluentXmlNode
        {
            obj?.Attributes.Remove(name);
            return obj;
        }

        public static T RemoveAttributesWhere<T>(this T obj, Func<IFluentXmlAttribute, bool> predicate)
            where T : IFluentXmlNode
        {
            obj?.Attributes.RemoveWhere(predicate);
            return obj;
        }

        public static T RemoveChildrenWhere<T>(this T obj, Func<IFluentXmlObject, bool> predicate)
            where T : IFluentXmlNode
        {
            obj?.Children.RemoveWhere(predicate);
            return obj;
        }

        public static T SetAttribute<T>(this T obj, string name, string value) where T : IFluentXmlNode
        {
            obj?.Attributes.Set(name, value);
            return obj;
        }

        public static T SetAttribute<T>(this T obj, string name, Action<IFluentXmlAttribute> setup)
            where T : IFluentXmlNode
        {
            obj?.Attributes.Set(name, setup);
            return obj;
        }

        public static T ForEach<T>(this T obj, Action<T> scope)
            where T : IFluentXmlObject
        {
            scope(obj);
            return obj;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> obj, Action<T> scope)
            where T : IFluentXmlObject
        {
            foreach (var node in obj)
                scope(node);

            return obj;
        }

        public static IEnumerable<T> WithName<T>(this IEnumerable<T> obj, string name) where T : IFluentXmlObject =>
            obj.Where(x => x.Name == name);

        public static IFluentXmlObject SetValue(this IFluentXmlObject obj, string value)
        {
            obj.Value = value;
            return obj;
        }

        public static T Use<T>(this T obj, Action<T> setup) where T : IFluentXmlObject
        {
            setup(obj);
            return obj;
        }
    }
}