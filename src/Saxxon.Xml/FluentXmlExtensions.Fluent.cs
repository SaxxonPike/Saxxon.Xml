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

        public static IFluentXmlAttribute Fluent(this XmlAttribute obj)
        {
            return (IFluentXmlAttribute) FluentSysXmlFactory.Create(obj);
        }

        public static IFluentXmlComment Fluent(this XmlComment obj)
        {
            return (IFluentXmlComment) FluentSysXmlFactory.Create(obj);
        }

        public static IFluentXmlDeclaration Fluent(this XmlDeclaration obj)
        {
            return (IFluentXmlDeclaration) FluentSysXmlFactory.Create(obj);
        }

        public static IFluentXmlDocument Fluent(this XmlDocument obj)
        {
            return (IFluentXmlDocument) FluentSysXmlFactory.Create(obj);
        }

        public static IFluentXmlNode Fluent(this XmlNode obj)
        {
            return (IFluentXmlNode) FluentSysXmlFactory.Create(obj);
        }

        // System.Xml.Linq

        public static IFluentXmlAttribute Fluent(this XAttribute obj)
        {
            return (IFluentXmlAttribute) FluentSysXmlLinqFactory.Create(obj);
        }

        public static IFluentXmlDocument Fluent(this XDocument obj)
        {
            return (IFluentXmlDocument) FluentSysXmlLinqFactory.Create(obj);
        }
        
        public static IFluentXmlNode Fluent(this XNode obj)
        {
            return (IFluentXmlNode) FluentSysXmlLinqFactory.Create(obj);
        }
    }
}