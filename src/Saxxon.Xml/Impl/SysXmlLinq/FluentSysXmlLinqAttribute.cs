using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqAttribute : FluentSysXmlLinqNode, IFluentXmlAttribute
    {
        private readonly XAttribute _attribute;

        public FluentSysXmlLinqAttribute(XAttribute attribute) : base(attribute)
        {
            _attribute = attribute;
        }

        public override string Name =>
            $"{_attribute.Name}";

        public string Value
        {
            get => _attribute.Value;
            set => _attribute.Value = value;
        }
    }
}