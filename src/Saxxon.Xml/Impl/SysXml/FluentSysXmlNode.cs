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
    }
}