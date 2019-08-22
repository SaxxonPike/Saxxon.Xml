using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal static class FluentSysXmlLinqFactory
    {
        public static IFluentXmlObject Create(XObject obj)
        {
            switch (obj)
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

                // the cases below are catch-all; use more specific ones first

                case XNode node:
                    return new FluentSysXmlLinqNode(node);
                default:
                    return new FluentSysXmlLinqObject(obj);
            }
        }
    }
}