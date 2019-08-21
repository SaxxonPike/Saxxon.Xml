using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlNode : FluentSysXmlBase, IFluentXmlNode
    {
        public FluentSysXmlNode(XmlNode node)
        {
            Node = node;
        }

        public override XmlNode Node { get; }

//
//        public IFluentXmlAttribute AddAttribute(Action<IFluentXmlAttributeBuilder> setup)
//        {
//            var builder = new FluentSysXmlAttributeBuilder(Node.OwnerDocument);
//            setup(builder);
//            var attribute = Node?.Attributes.Append(builder.Create());
//            return new FluentSysXmlAttribute(attribute);
//        }
    }
}