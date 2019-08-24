using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlChildSet : IFluentXmlChildSet
    {
        private readonly XmlNode _parent;

        public FluentSysXmlChildSet(XmlNode parent)
        {
            _parent = parent;
        }

        public IEnumerator<IFluentXmlNode> GetEnumerator()
        {
            return GetNodes()
                .Select(FluentSysXmlFactory.Create)
                .Cast<IFluentXmlNode>()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IFluentXmlNode this[int index] =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(_parent?.ChildNodes[index]);

        public IEnumerable<IFluentXmlNode> this[string name] =>
            GetNodes()
                .Where(x => x.Name == name)
                .Select(FluentSysXmlFactory.Create)
                .Cast<IFluentXmlNode>();

        public IFluentXmlComment CreateComment()
        {
            var comment = _parent?.OwnerDocument?.CreateComment(string.Empty);
            if (comment != null)
                _parent.AppendChild(comment);
            else
                return null;
            return (IFluentXmlComment) FluentSysXmlFactory.Create(comment);
        }

        public IFluentXmlElement CreateElement(string name)
        {
            var element = _parent?.OwnerDocument?.CreateElement(name);
            if (element != null)
                _parent.AppendChild(element);
            else
                return null;
            return (IFluentXmlElement) FluentSysXmlFactory.Create(element);
        }

        public void Remove(IFluentXmlNode node)
        {
            if (node is FluentSysXmlBase child)
                _parent.RemoveChild(child.Node);
        }

        public IFluentXmlText CreateText()
        {
            var text = _parent?.OwnerDocument?.CreateTextNode(string.Empty);
            if (text != null)
                _parent.AppendChild(text);
            else
                return null;
            return (IFluentXmlText) FluentSysXmlFactory.Create(text);
        }

        private IEnumerable<XmlNode> GetNodes()
        {
            return _parent?.ChildNodes
                       .OfType<XmlNode>() ??
                   Enumerable
                       .Empty<XmlNode>();
        }

        public override string ToString()
        {
            var nodes = _parent?.ChildNodes.OfType<XmlNode>().Select(e => e.OuterXml);
            return nodes == null
                ? "<!--null-->"
                : string.Join(string.Empty, nodes);
        }
    }
}