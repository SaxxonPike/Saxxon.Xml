using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlAttributeSet : IFluentXmlAttributeSet
    {
        private readonly XmlNode _owner;

        public FluentSysXmlAttributeSet(XmlNode owner)
        {
            _owner = owner;
        }

        public IEnumerator<IFluentXmlAttribute> GetEnumerator()
        {
            return GetNodes()
                .Select(FluentSysXmlFactory.Create)
                .Cast<IFluentXmlAttribute>()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IFluentXmlAttribute this[string name] =>
            new FluentSysXmlAttribute(_owner, name);

        public IEnumerable<string> Keys =>
            GetNodes()
                .Select(x => x.Name);

        private IEnumerable<XmlAttribute> GetNodes()
        {
            return _owner?.Attributes?
                       .Cast<XmlAttribute>() ??
                   Enumerable
                       .Empty<XmlAttribute>();
        }

        public override string ToString()
        {
            var nodes = _owner?.ChildNodes.OfType<XmlAttribute>().Select(e => e.OuterXml);
            return nodes == null
                ? "<!--null-->"
                : string.Join(string.Empty, nodes);
        }
    }
}