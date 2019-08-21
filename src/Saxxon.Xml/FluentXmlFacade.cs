using System.Xml;
using System.Xml.Linq;
using Saxxon.Xml.Impl.SysXml;
using Saxxon.Xml.Impl.SysXmlLinq;

namespace Saxxon.Xml
{
    public static class FluentXmlFacade
    {
        // System.Xml
        
        public static IFluentXmlAttribute Fluent(this XmlAttribute obj) =>
            (IFluentXmlAttribute) FluentSysXmlFactory.Create(obj);

        public static IFluentXmlComment Fluent(this XmlComment obj) =>
            (IFluentXmlComment) FluentSysXmlFactory.Create(obj);
        
        public static IFluentXmlDeclaration Fluent(this XmlDeclaration obj) =>
            (IFluentXmlDeclaration) FluentSysXmlFactory.Create(obj);
        
        public static IFluentXmlDocument Fluent(this XmlDocument obj) =>
            (IFluentXmlDocument) FluentSysXmlFactory.Create(obj);
        
        // System.Xml.Linq
        
        public static IFluentXmlAttribute Fluent(this XAttribute obj) =>
            (IFluentXmlAttribute) FluentSysXmlLinqFactory.Create(obj);

        public static IFluentXmlDocument Fluent(this XDocument obj) =>
            (IFluentXmlDocument) FluentSysXmlLinqFactory.Create(obj);
    }
}