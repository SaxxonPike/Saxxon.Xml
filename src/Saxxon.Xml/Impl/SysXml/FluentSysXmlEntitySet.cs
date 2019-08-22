using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    public class FluentSysXmlEntitySet : IFluentXmlEntitySet
    {
        private readonly XmlDocument _doc;

        public FluentSysXmlEntitySet(XmlDocument doc)
        {
            _doc = doc;
        }

        private IEnumerable<XmlEntity> GetNodes() =>
            _doc?.ChildNodes.OfType<XmlEntity>() ??
            Enumerable.Empty<XmlEntity>();

        public IEnumerator<IFluentXmlEntity> GetEnumerator() =>
            GetNodes()
                .Select(FluentSysXmlFactory.Create)
                .Cast<IFluentXmlEntity>()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}