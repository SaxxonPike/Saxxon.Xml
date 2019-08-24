// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
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

        public static T SetValue<T>(this T obj, string value) where T : IFluentXmlObject
        {
            if (obj != null)
                obj.Value = value;
            return obj;
        }

        public static T SetXml<T>(this T obj, string value) where T : IFluentXmlNode
        {
            if (obj != null)
                obj.Xml = value;
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

        public static IEnumerable<T> WithName<T>(this IEnumerable<T> obj, string name) where T : IFluentXmlObject
        {
            return obj.Where(x => x.Name == name);
        }

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

        public static T IfNull<T>(this T obj, Action setup) where T : IFluentXmlObject
        {
            if (obj == null)
                setup();
            return obj;
        }

        public static T IfNotNull<T>(this T obj, Action<T> setup) where T : IFluentXmlObject
        {
            if (obj != null)
                setup(obj);
            return obj;
        }

        public static T IfEmpty<T>(this T obj, Action<T> setup) where T : IFluentXmlObject
        {
            switch (obj)
            {
                case IFluentXmlNode fxn:
                    if (fxn.Children == null || !fxn.Children.Any())
                        setup(obj);
                    break;
                case IFluentXmlObject fxo:
                    if (string.IsNullOrEmpty(fxo.Value))
                        setup(obj);
                    break;
            }

            return obj;
        }

        public static T IfNotEmpty<T>(this T obj, Action<T> setup) where T : IFluentXmlObject
        {
            switch (obj)
            {
                case IFluentXmlNode fxn:
                    if (fxn.Children != null && fxn.Children.Any())
                        setup(obj);
                    break;
                case IFluentXmlObject fxo:
                    if (!string.IsNullOrEmpty(fxo.Value))
                        setup(obj);
                    break;
            }

            return obj;
        }
    }
}