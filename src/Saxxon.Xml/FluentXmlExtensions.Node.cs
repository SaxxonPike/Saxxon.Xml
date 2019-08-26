// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static T AppendComment<T>(this T self, string content) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.AppendComment(content);
            return self;
        }

        public static T AppendComment<T>(this T self, Action<IFluentXmlComment> setup) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.AppendComment(setup);
            return self;
        }

        public static T AppendElement<T>(this T self, string name) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.AppendElement(name);
            return self;
        }

        public static T AppendElement<T>(this T self, string name, Action<IFluentXmlElement> setup)
            where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.AppendElement(name, setup);
            return self;
        }

        public static T AppendText<T>(this T self, string content) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.AppendText(content);
            return self;
        }

        public static T AppendText<T>(this T self, Action<IFluentXmlText> setup) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.AppendText(setup);
            return self;
        }

        public static T RemoveAttribute<T>(this T self, string name) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Attributes.Remove(name);
            return self;
        }

        public static T RemoveAttributesWhere<T>(this T self, Func<IFluentXmlAttribute, bool> predicate)
            where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Attributes.RemoveWhere(predicate);
            return self;
        }

        public static T RemoveChildrenWhere<T>(this T self, Func<IFluentXmlObject, bool> predicate)
            where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Children.RemoveWhere(predicate);
            return self;
        }

        public static T SetAttribute<T>(this T self, string name, string value) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Attributes.Set(name, value);
            return self;
        }

        public static T SetAttribute<T>(this T self, string name, Action<IFluentXmlAttribute> setup)
            where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Attributes.Set(name, setup);
            return self;
        }

        public static T SetValue<T>(this T self, string value) where T : IFluentXmlObject
        {
            Assert.NotNull(self, nameof(self));

            self.Value = value;
            return self;
        }

        public static T SetXml<T>(this T self, string value) where T : IFluentXmlNode
        {
            Assert.NotNull(self, nameof(self));

            self.Xml = value;
            return self;
        }

        public static T ForEach<T>(this T self, Action<T> scope)
            where T : IFluentXmlObject
        {
            Assert.NotNull(self, nameof(self));

            scope(self);
            return self;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> self, Action<T> scope)
            where T : IFluentXmlObject
        {
            Assert.NotNull(self, nameof(self));

            foreach (var node in self)
                scope(node);

            return self;
        }

        public static IEnumerable<T> WithName<T>(this IEnumerable<T> self, string name) where T : IFluentXmlObject
        {
            Assert.NotNull(self, nameof(self));

            return self.Where(x => x.Name == name);
        }

        public static IFluentXmlObject SetValue(this IFluentXmlObject self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.Value = value;
            return self;
        }

        public static T Use<T>(this T self, Action<T> setup) where T : IFluentXmlObject
        {
            Assert.NotNull(self, nameof(self));

            setup(self);
            return self;
        }

        public static T IfNull<T>(this T self, Action setup) where T : IFluentXmlObject
        {
            if (self == null)
                setup();
            return self;
        }

        public static T IfNotNull<T>(this T self, Action<T> setup) where T : IFluentXmlObject
        {
            if (self != null)
                setup(self);
            return self;
        }

        public static T IfEmpty<T>(this T self, Action<T> setup) where T : IFluentXmlObject
        {
            switch (self)
            {
                case IFluentXmlNode fxn:
                    if (fxn.Children == null || !fxn.Children.Any())
                        setup(self);
                    break;
                case IFluentXmlObject fxo:
                    if (string.IsNullOrEmpty(fxo.Value))
                        setup(self);
                    break;
            }

            return self;
        }

        public static T IfNotEmpty<T>(this T self, Action<T> setup) where T : IFluentXmlObject
        {
            switch (self)
            {
                case IFluentXmlNode fxn:
                    if (fxn.Children != null && fxn.Children.Any())
                        setup(self);
                    break;
                case IFluentXmlObject fxo:
                    if (!string.IsNullOrEmpty(fxo.Value))
                        setup(self);
                    break;
            }

            return self;
        }
    }
}