using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqChildSet : IFluentXmlChildSet
    {
        private readonly XContainer _node;

        public FluentSysXmlLinqChildSet(XContainer node)
        {
            _node = node;
        }

        private IEnumerable<XElement> GetNodes() =>
            _node?.Nodes().OfType<XElement>() ??
            Enumerable
                .Empty<XElement>();

        public IEnumerator<IFluentXmlObject> GetEnumerator() =>
            GetNodes()
                .Select(FluentSysXmlLinqFactory.Create)
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public IFluentXmlObject this[int index] =>
            FluentSysXmlLinqFactory.Create(_node?.Nodes().Skip(index).Take(1).FirstOrDefault());

        public IEnumerable<IFluentXmlObject> this[string name] =>
            GetNodes()
                .Where(x => x.Name == name)
                .Select(FluentSysXmlLinqFactory.Create);
    }
}