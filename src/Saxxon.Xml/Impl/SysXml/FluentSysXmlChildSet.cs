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

        private IEnumerable<XmlNode> GetNodes() =>
            _parent?.ChildNodes
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
            FluentSysXmlFactory.Create(_parent?.ChildNodes[index]);

        public IEnumerable<IFluentXmlObject> this[string name] =>
            GetNodes()
                .Where(x => x.Name == name)
                .Select(FluentSysXmlFactory.Create);

        public IFluentXmlElement CreateElement(string name)
        {
            var element = _parent?.OwnerDocument?.CreateElement(name);
            if (element != null)
                _parent.AppendChild(element);
            else
                return null;
            return (IFluentXmlElement) FluentSysXmlFactory.Create(element);
        }

        public IFluentXmlComment CreateComment()
        {
            var comment = _parent?.OwnerDocument?.CreateComment(string.Empty);
            if (comment != null)
                _parent.AppendChild(comment);
            else
                return null;
            return (IFluentXmlComment) FluentSysXmlFactory.Create(comment);
        }

        public void Remove(IFluentXmlObject node)
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

        public override string ToString() => 
            _parent?.ToString() ?? string.Empty;
    }
}