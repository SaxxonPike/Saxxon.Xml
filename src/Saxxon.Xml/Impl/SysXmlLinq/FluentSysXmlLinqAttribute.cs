using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqAttribute : FluentSysXmlLinqObjectBase, IFluentXmlAttribute
    {
        private readonly XElement _element;

        public FluentSysXmlLinqAttribute(XElement element, string name)
        {
            _element = element;
            Name = name;
        }

        public override string Name { get; }

        public override XObject Node => _element?.Attribute(Name);

        public override string Value
        {
            get => _element.Attribute(Name)?.Value;
            set => _element.SetAttributeValue(Name, value);
        }
    }
}