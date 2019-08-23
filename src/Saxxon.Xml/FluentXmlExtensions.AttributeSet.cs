// ReSharper disable UnusedMethodReturnValue.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static IFluentXmlAttributeSet Remove(this IFluentXmlAttributeSet obj, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            obj[name].Value = null;
            return obj;
        }

        public static IFluentXmlAttributeSet RemoveWhere(this IFluentXmlAttributeSet obj,
            Func<IFluentXmlAttribute, bool> predicate)
        {
            var eligible = obj
                .Where(predicate)
                .ToArray();

            foreach (var item in eligible.Where(i => i?.Name != null).ToArray())
                Remove(obj, item.Name);

            return obj;
        }

        public static IFluentXmlAttributeSet Set(this IFluentXmlAttributeSet obj, string name, string value)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            obj[name].Value = value;
            return obj;
        }

        public static IFluentXmlAttributeSet Set(this IFluentXmlAttributeSet obj, string name,
            Action<IFluentXmlAttribute> setup)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            setup(obj[name]);
            return obj;
        }

        public static IFluentXmlAttributeSet SetRange(this IFluentXmlAttributeSet obj,
            IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            foreach (var pair in keyValuePairs)
                Set(obj, pair.Key, pair.Value);
            return obj;
        }

        public static Dictionary<string, string> ToDictionary(this IFluentXmlAttributeSet obj) =>
            obj.ToDictionary(x => x.Name, x => x.Value);
    }
}