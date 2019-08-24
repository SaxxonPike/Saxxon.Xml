using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqAttributeSet : IFluentXmlAttributeSet
    {
        private readonly XElement _node;

        public FluentSysXmlLinqAttributeSet(XElement node)
        {
            _node = node;
        }

        public IEnumerator<IFluentXmlAttribute> GetEnumerator()
        {
            return GetNodes()
                .Select(FluentSysXmlLinqFactory.Create)
                .Cast<IFluentXmlAttribute>()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IFluentXmlAttribute this[string name] =>
            new FluentSysXmlLinqAttribute(_node, name);
        //FluentSysXmlLinqFactory.Create(_node?.Attribute(name)) as IFluentXmlAttribute;

        public IEnumerable<string> Keys =>
            GetNodes()
                .Select(x => $"{x.Name}");

        private IEnumerable<XAttribute> GetNodes()
        {
            return _node?.Attributes() ??
                   Enumerable
                       .Empty<XAttribute>();
        }
    }
}