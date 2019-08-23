using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal abstract class FluentSysXmlBase : IFluentXmlObject, IFluentXmlWrappedObject<XmlNode>
    {
        public virtual IFluentXmlNode Parent =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(Node?.ParentNode);

        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlChildSet(Node);

        public virtual string Name =>
            (Node)?
            .Name;

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

        public virtual string Value
        {
            get => Node?.InnerText;
            set
            {
                if (Node is XmlNode node)
                    node.InnerText = value;
            }
        }

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

        public override string ToString() =>
            Node?.OuterXml ?? "<!--null-->";

        public IFluentXmlNode Next =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(Node?.NextSibling);

        public IFluentXmlNode Previous =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(Node?.PreviousSibling);
    }
}