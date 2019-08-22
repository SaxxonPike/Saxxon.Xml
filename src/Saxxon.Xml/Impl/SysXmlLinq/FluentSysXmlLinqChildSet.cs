using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqChildSet : IFluentXmlChildSet
    {
        private readonly XContainer _node;

        public FluentSysXmlLinqChildSet(XContainer node)
        {
            _node = node;
        }

        private IEnumerable<XNode> GetNodes() =>
            _node?.Nodes() ??
            Enumerable
                .Empty<XNode>();

        public IEnumerator<IFluentXmlNode> GetEnumerator() =>
            GetNodes()
                .Select(FluentSysXmlLinqFactory.Create)
                .Cast<IFluentXmlNode>()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        public IFluentXmlNode this[int index] =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create(_node?.Nodes().Skip(index).Take(1).FirstOrDefault());

        public IEnumerable<IFluentXmlNode> this[string name] =>
            GetNodes()
                .OfType<XElement>()
                .Where(x => x.Name == name)
                .Select(FluentSysXmlLinqFactory.Create)
                .Cast<IFluentXmlNode>();

        public IFluentXmlElement CreateElement(string name)
        {
            var element = new XElement(name);
            _node.Add(element);
            return (IFluentXmlElement) FluentSysXmlLinqFactory.Create(element);
        }

        public IFluentXmlComment CreateComment()
        {
            var comment = new XComment(string.Empty);
            _node.Add(comment);
            return (IFluentXmlComment) FluentSysXmlLinqFactory.Create(comment);
        }

        public void Remove(IFluentXmlNode node)
        {
            if (node is FluentSysXmlLinqObjectBase child && child.Node?.Parent == _node)
                (child.Node as XNode)?.Remove();
        }

        public IFluentXmlText CreateText()
        {
            var text = new XText(string.Empty);
            _node.Add(text);
            return (IFluentXmlText) FluentSysXmlLinqFactory.Create(text);
        }
    }
}