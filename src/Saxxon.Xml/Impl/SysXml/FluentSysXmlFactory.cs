using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal static class FluentSysXmlFactory
    {
        public static IFluentXmlObject Create(XmlNode node)
        {
            if (node == null)
                return null;

            if (node is XmlAttribute attribute)
                return new FluentSysXmlAttribute(attribute.OwnerElement, attribute.Name);

            if (node is XmlComment comment)
                return new FluentSysXmlComment(comment);

            if (node is XmlDeclaration declaration)
                return new FluentSysXmlDeclaration(declaration);

            if (node is XmlDocument document)
                return new FluentSysXmlDocument(document);

            if (node is XmlElement element)
                return new FluentSysXmlElement(element);

            return new FluentSysXmlNode(node);
        }
    }
}