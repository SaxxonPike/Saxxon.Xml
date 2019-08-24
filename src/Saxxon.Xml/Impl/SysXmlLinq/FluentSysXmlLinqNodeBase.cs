using System;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal abstract class FluentSysXmlLinqNodeBase : FluentSysXmlLinqObjectBase, IFluentXmlNode
    {
        public virtual IFluentXmlNode this[int index]
        {
            get
            {
                return Name == null
                    ? Parent?.Children[index]
                    : Parent?.Children.Where(x => x.Name == Name).Skip(index).FirstOrDefault();
            }
        }

        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlLinqChildSet(Node as XContainer);

        public virtual string Xml
        {
            get => string.Join(string.Empty,
                (Node as XContainer)?.Nodes().Select(n => n.ToString()) ??
                Enumerable.Empty<string>());

            set
            {
                if (Node is XContainer node)
                    try
                    {
                        node.ReplaceNodes(XElement.Parse(value));
                    }
                    catch (Exception)
                    {
                        node.ReplaceNodes(new XText(value));
                    }
            }
        }

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlLinqAttributeSet(Node as XElement);

        public IFluentXmlNode Next =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create((Node as XNode)?.NextNode);

        public IFluentXmlNode Previous =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create((Node as XNode)?.PreviousNode);

        public override string ToString()
        {
            return Node?.ToString() ?? "<!--null-->";
        }
    }
}