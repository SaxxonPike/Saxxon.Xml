// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

using System.Xml;
using System.Xml.Linq;
using Saxxon.Xml.Impl.SysXml;
using Saxxon.Xml.Impl.SysXmlLinq;

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        // System.Xml

        public static IFluentXmlAttribute Fluent(this XmlAttribute self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlAttribute) FluentSysXmlFactory.Create(self);
        }

        public static IFluentXmlComment Fluent(this XmlComment self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlComment) FluentSysXmlFactory.Create(self);
        }

        public static IFluentXmlDeclaration Fluent(this XmlDeclaration self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlDeclaration) FluentSysXmlFactory.Create(self);
        }

        public static IFluentXmlDocument Fluent(this XmlDocument self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlDocument) FluentSysXmlFactory.Create(self);
        }

        public static IFluentXmlNode Fluent(this XmlNode self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlNode) FluentSysXmlFactory.Create(self);
        }

        // System.Xml.Linq

        public static IFluentXmlAttribute Fluent(this XAttribute self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlAttribute) FluentSysXmlLinqFactory.Create(self);
        }

        public static IFluentXmlDocument Fluent(this XDocument self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlDocument) FluentSysXmlLinqFactory.Create(self);
        }

        public static IFluentXmlNode Fluent(this XNode self)
        {
            Assert.NotNull(self, nameof(self));

            return (IFluentXmlNode) FluentSysXmlLinqFactory.Create(self);
        }
    }
}