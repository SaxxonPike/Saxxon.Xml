// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Linq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static IFluentXmlChildSet AppendComment(this IFluentXmlChildSet self, string content)
        {
            Assert.NotNull(self, nameof(self));

            var comment = self.CreateComment();
            comment.Value = content;
            return self;
        }

        public static IFluentXmlChildSet AppendComment(this IFluentXmlChildSet self, Action<IFluentXmlComment> setup)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(setup, nameof(setup));

            var comment = self.CreateComment();
            setup(comment);
            return self;
        }

        public static IFluentXmlChildSet AppendElement(this IFluentXmlChildSet self, string name)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(name, nameof(name));

            self.CreateElement(name);
            return self;
        }

        public static IFluentXmlChildSet AppendElement(this IFluentXmlChildSet self, string name,
            Action<IFluentXmlElement> setup)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(setup, nameof(setup));

            var element = self.CreateElement(name);
            setup(element);
            return self;
        }

        public static IFluentXmlChildSet AppendText(this IFluentXmlChildSet self, string content)
        {
            Assert.NotNull(self, nameof(self));

            var text = self.CreateText();
            text.Value = content;
            return self;
        }

        public static IFluentXmlChildSet AppendText(this IFluentXmlChildSet self, Action<IFluentXmlText> setup)
        {
            Assert.NotNull(self, nameof(self));

            var text = self.CreateText();
            setup(text);
            return self;
        }

        public static IFluentXmlChildSet GetOrAppendElement(this IFluentXmlChildSet self, string name)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(name, nameof(name));

            if (self.All(x => name != x?.Name))
                self.CreateElement(name);
            return self;
        }

        public static IFluentXmlChildSet GetOrAppendElement(this IFluentXmlChildSet self, string name,
            Action<IFluentXmlElement> setup)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(name, nameof(name));

            var element = self
                              .OfType<IFluentXmlElement>()
                              .FirstOrDefault(x => name == x?.Name) ??
                          self.CreateElement(name);
            setup(element);
            return self;
        }

        public static IFluentXmlChildSet RemoveWhere(this IFluentXmlChildSet self,
            Func<IFluentXmlNode, bool> predicate)
        {
            Assert.NotNull(self, nameof(self));
            Assert.NotNull(predicate, nameof(predicate));

            foreach (var node in self.Where(predicate).ToArray())
                self.Remove(node);
            return self;
        }
    }
}