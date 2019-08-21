using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml
{
    public static class FluentXmlAttributeExtensions
    {
        public static IFluentXmlAttributeSet Add(this IFluentXmlAttributeSet obj, string name, string value)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            obj[name].Value = value;
            return obj;
        }

        public static IFluentXmlAttributeSet Add(this IFluentXmlAttributeSet obj, IFluentXmlAttribute attribute)
        {
            Add(obj, attribute.Name, attribute.Value);
            return obj;
        }

        public static IFluentXmlAttributeSet Add(this IFluentXmlAttributeSet obj, string name)
        {
            Add(obj, name, string.Empty);
            return obj;
        }

        public static IFluentXmlAttributeSet AddRange(this IFluentXmlAttributeSet obj,
            IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            foreach (var pair in keyValuePairs)
                Add(obj, pair.Key, pair.Value);
            return obj;
        }

        public static IFluentXmlAttributeSet Remove(this IFluentXmlAttributeSet obj, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            obj[name].Value = null;
            return obj;
        }

        public static IFluentXmlAttributeSet Remove(this IFluentXmlAttributeSet obj, IFluentXmlAttribute attribute)
        {
            Remove(obj, attribute.Name);
            return obj;
        }

        public static IFluentXmlAttributeSet RemoveWhere(this IFluentXmlAttributeSet obj,
            Func<IFluentXmlAttribute, bool> predicate)
        {
            var eligible = obj
                .Where(predicate)
                .ToArray();

            foreach (var item in eligible)
                Remove(obj, item);

            return obj;
        }

        public static Dictionary<string, string> ToDictionary(this IFluentXmlAttributeSet obj) => 
            obj.ToDictionary(x => x.Name, x => x.Value);
    }
}