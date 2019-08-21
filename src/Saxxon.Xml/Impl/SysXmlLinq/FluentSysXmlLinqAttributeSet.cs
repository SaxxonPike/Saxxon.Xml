using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqAttributeSet : IFluentXmlAttributeSet
    {
        private readonly XElement _node;

        public FluentSysXmlLinqAttributeSet(XElement node)
        {
            _node = node;
        }

        private IEnumerable<XAttribute> GetNodes() =>
            _node?.Attributes() ??
            Enumerable
                .Empty<XAttribute>();

        public IEnumerator<IFluentXmlAttribute> GetEnumerator() =>
            GetNodes()
                .Select(FluentSysXmlLinqFactory.Create)
                .Cast<IFluentXmlAttribute>()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public IFluentXmlAttribute this[int index] =>
            FluentSysXmlLinqFactory.Create(_node?.Attributes().Skip(index).FirstOrDefault()) as IFluentXmlAttribute;

        public IFluentXmlAttribute this[string name] =>
            FluentSysXmlLinqFactory.Create(_node?.Attribute(name)) as IFluentXmlAttribute;
    }
}