using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal abstract class FluentSysXmlBase : IFluentXmlObject
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
            new FluentSysXmlChildSet(Node);

        public virtual string Xml
        {
            get => Node?.InnerXml;
            set
            {
                if (Node is XmlNode node)
                    node.InnerXml = value;
            }
        }

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlAttributeSet(Node);

        public abstract XmlNode Node { get; }

        protected XmlDocument Document
        {
            get
            {
                if (Node is XmlDocument document)
                    return document;

                return Node?.OwnerDocument;
            }
        }

        public IFluentXmlNode Next =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(Node?.NextSibling);

        public IFluentXmlNode Previous =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(Node?.PreviousSibling);

        public virtual IFluentXmlNode Parent =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(Node?.ParentNode);

        public virtual string Name =>
            Node?
                .Name;

        public string Namespace =>
            Node?
                .GetPrefixOfNamespace(Node.NamespaceURI);

        public virtual string Value
        {
            get => Node?.InnerText;
            set
            {
                if (Node is XmlNode node)
                    node.InnerText = value;
            }
        }

        public override string ToString()
        {
            return Node?.OuterXml ?? "<!--null-->";
        }
    }
}