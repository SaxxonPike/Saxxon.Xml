using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqObject : FluentSysXmlLinqObjectBase
    {
        public FluentSysXmlLinqObject(XObject obj)
        {
            Node = obj;
        }

        public override XObject Node { get; }
    }
}