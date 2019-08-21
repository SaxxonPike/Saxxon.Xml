using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal static class FluentSysXmlLinqFactory
    {
        public static IFluentXmlObject Create(XObject node)
        {
            if (node == null)
                return null;

            if (node is XAttribute attribute)
                return new FluentSysXmlLinqAttribute(attribute.Parent, $"{attribute.Name}");

            if (node is XComment comment)
                return new FluentSysXmlLinqComment(comment);

            if (node is XDocument document)
                return new FluentSysXmlLinqDocument(document);

            if (node is XElement element)
                return new FluentSysXmlLinqElement(element);
            
            return new FluentSysXmlLinqNode(node);
        }
    }
}