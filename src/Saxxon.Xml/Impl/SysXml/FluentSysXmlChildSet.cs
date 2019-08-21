using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlChildSet : IFluentXmlChildSet
    {
        private readonly XmlNodeList _nodeList;

        public FluentSysXmlChildSet(XmlNodeList nodeList)
        {
            _nodeList = nodeList;
        }

        private IEnumerable<XmlNode> GetNodes() =>
            _nodeList?
                .Cast<XmlNode>() ??
            Enumerable
                .Empty<XmlNode>();

        public IEnumerator<IFluentXmlObject> GetEnumerator() =>
            GetNodes()
                .Select(FluentSysXmlFactory.Create)
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public IFluentXmlObject this[int index] =>
            FluentSysXmlFactory.Create(_nodeList[index]);

        public IEnumerable<IFluentXmlObject> this[string name] =>
            GetNodes()
                .Where(x => x.Name == name)
                .Select(FluentSysXmlFactory.Create);
    }
}