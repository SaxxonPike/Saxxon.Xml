// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static IFluentXmlAttributeSet Remove(this IFluentXmlAttributeSet self, string name)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNullOrEmpty(name, nameof(name));

            self[name].Value = null;
            return self;
        }

        public static IFluentXmlAttributeSet RemoveWhere(this IFluentXmlAttributeSet self,
            Func<IFluentXmlAttribute, bool> predicate)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(predicate, nameof(predicate));

            var eligible = self
                .Where(predicate)
                .ToArray();

            foreach (var item in eligible.Where(i => i?.Name != null).ToArray())
                Remove(self, item.Name);

            return self;
        }

        public static IFluentXmlAttributeSet Set(this IFluentXmlAttributeSet self, string name, string value)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNullOrEmpty(name, nameof(name));

            self[name].Value = value;
            return self;
        }

        public static IFluentXmlAttributeSet Set(this IFluentXmlAttributeSet self, string name,
            Action<IFluentXmlAttribute> setup)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNullOrEmpty(name, nameof(name));

            setup(self[name]);
            return self;
        }

        public static IFluentXmlAttributeSet SetRange(this IFluentXmlAttributeSet self,
            IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(keyValuePairs, nameof(keyValuePairs));

            foreach (var pair in keyValuePairs)
                Set(self, pair.Key, pair.Value);
            return self;
        }

        public static Dictionary<string, string> ToDictionary(this IFluentXmlAttributeSet self)
        {
            Assert.NotNull(self, nameof(self));

            return self.ToDictionary(x => x.Name, x => x.Value);
        }
    }
}