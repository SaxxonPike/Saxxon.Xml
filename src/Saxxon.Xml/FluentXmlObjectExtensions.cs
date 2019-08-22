using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UnusedMethodReturnValue.Global

namespace Saxxon.Xml
{
    public static class FluentXmlObjectExtensions
    {
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

        public static T Within<T>(this T obj, Action<T> setup) where T : IFluentXmlObject
        {
            setup(obj);
            return obj;
        }
    }
}