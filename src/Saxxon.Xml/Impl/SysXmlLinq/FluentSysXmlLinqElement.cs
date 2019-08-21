using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqElement : FluentSysXmlLinqBase, IFluentXmlElement
    {
        private readonly XElement _element;

        public FluentSysXmlLinqElement(XElement element)
        {
            _element = element;
        }

        public override XObject Node => _element;
    }
}