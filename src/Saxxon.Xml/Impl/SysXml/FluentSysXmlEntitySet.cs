using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlEntitySet : IFluentXmlEntitySet
    {
        private readonly XmlDocument _doc;

        public FluentSysXmlEntitySet(XmlDocument doc)
        {
            _doc = doc;
        }

        public IEnumerator<IFluentXmlEntity> GetEnumerator()
        {
            return GetNodes()
                .Select(FluentSysXmlFactory.Create)
                .Cast<IFluentXmlEntity>()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<XmlEntity> GetNodes()
        {
            return _doc?.ChildNodes.OfType<XmlEntity>() ??
                   Enumerable.Empty<XmlEntity>();
        }

        public override string ToString()
        {
            var nodes = _doc?.ChildNodes.OfType<XmlEntity>().Select(e => e.OuterXml);
            return nodes == null
                ? "<!--null-->"
                : string.Join(string.Empty, nodes);
        }
    }
}