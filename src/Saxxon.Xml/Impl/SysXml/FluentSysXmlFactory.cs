using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal static class FluentSysXmlFactory
    {
        public static IFluentXmlObject Create(XmlNode node)
        {
            switch (node)
            {
                case null:
                    return null;
                case XmlAttribute attribute:
                    return new FluentSysXmlAttribute(attribute.OwnerElement, attribute.Name);
                case XmlComment comment:
                    return new FluentSysXmlComment(comment);
                case XmlDeclaration declaration:
                    return new FluentSysXmlDeclaration(declaration);
                case XmlDocument document:
                    return new FluentSysXmlDocument(document);
                case XmlElement element:
                    return new FluentSysXmlElement(element);
                case XmlEntity entity:
                    return new FluentSysXmlEntity(entity);
                case XmlText text:
                    return new FluentSysXmlText(text);

                // the cases below are catch-all; use more specific ones first

                default:
                    return new FluentSysXmlNode(node);
            }
        }
    }
}