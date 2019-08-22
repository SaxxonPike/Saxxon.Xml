using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal static class FluentSysXmlLinqFactory
    {
        public static IFluentXmlObject Create(XObject node)
        {
            switch (node)
            {
                case null:
                    return null;
                case XAttribute attribute:
                    return new FluentSysXmlLinqAttribute(attribute.Parent, $"{attribute.Name}");
                case XComment comment:
                    return new FluentSysXmlLinqComment(comment);
                case XDocument document:
                    return new FluentSysXmlLinqDocument(document);
                case XElement element:
                    return new FluentSysXmlLinqElement(element);
                case XText text:
                    return new FluentSysXmlLinqText(text);
                default:
                    return new FluentSysXmlLinqNode(node);
            }
        }
    }
}