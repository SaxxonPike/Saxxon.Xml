using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqNode : FluentSysXmlLinqNodeBase
    {
        private readonly XNode _node;

        public FluentSysXmlLinqNode(XNode node)
        {
            _node = node;
        }

        public override XObject Node => _node;
    }
}