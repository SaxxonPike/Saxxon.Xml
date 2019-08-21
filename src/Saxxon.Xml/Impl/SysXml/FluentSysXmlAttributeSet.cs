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
        
        private IEnumerable<XmlAttribute> GetNodes() =>
            _owner?.Attributes?
                .Cast<XmlAttribute>() ??
            Enumerable
                .Empty<XmlAttribute>();

        public IEnumerator<IFluentXmlAttribute> GetEnumerator() =>
            GetNodes()
                .Select(FluentSysXmlFactory.Create)
                .Cast<IFluentXmlAttribute>()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public IFluentXmlAttribute this[string name] =>
            new FluentSysXmlAttribute(_owner, name);

        public IEnumerable<string> Keys =>
            GetNodes()
                .Select(x => x.Name);
    }
}