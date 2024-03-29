using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlAttribute : FluentSysXmlBase, IFluentXmlAttribute
    {
        private readonly XmlNode _parent;

        public FluentSysXmlAttribute(XmlNode parent, string name)
        {
            _parent = parent;
            Name = name;
        }

        public override XmlNode Node =>
            _parent?
                .Attributes?
                .GetNamedItem(Name);

        public override IFluentXmlNode Parent =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(_parent);

        public override string Name { get; }

        public override string Value
        {
            get => Node?.Value;
            set
            {
                var existing = _parent?.Attributes?.GetNamedItem(Name);

                if (existing == null && value != null)
                {
                    var newNode = _parent?.OwnerDocument?.CreateAttribute(Name);
                    if (newNode == null)
                        return;

                    newNode.Value = value;
                    _parent?.Attributes?.Append(newNode);
                }
                else if (existing != null && value == null)
                {
                    _parent?.Attributes?.RemoveNamedItem(Name);
                }
            }
        }
    }
}