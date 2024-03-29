using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqElement : FluentSysXmlLinqNodeBase, IFluentXmlElement
    {
        private readonly XElement _element;

        public FluentSysXmlLinqElement(XElement element)
        {
            _element = element;
        }

        public override XObject Node => _element;

        public override string Value
        {
            get => _element.Value;
            set => _element.Value = value;
        }
    }
}