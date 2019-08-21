using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlAttributeSet : IFluentXmlAttributeSet
    {
        private readonly XmlAttributeCollection _attrList;

        public FluentSysXmlAttributeSet(XmlAttributeCollection attrList)
        {
            _attrList = attrList;
        }
        
        private IEnumerable<XmlAttribute> GetNodes() =>
            _attrList?
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

        public IFluentXmlAttribute this[int index] =>
            (IFluentXmlAttribute) FluentSysXmlFactory.Create(_attrList[index]);

        public IFluentXmlAttribute this[string name] =>
            (IFluentXmlAttribute) FluentSysXmlFactory.Create(_attrList[name]);
    }
}