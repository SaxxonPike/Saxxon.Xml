using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqNode : FluentSysXmlLinqBase, IFluentXmlNode
    {
        public FluentSysXmlLinqNode(XObject node)
        {
            Node = node;
        }

        public override XObject Node { get; }
    }
}