using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal abstract class FluentSysXmlBase : IFluentXmlObject, IFluentXmlWrappedObject<XmlNode>
    {
        public virtual IFluentXmlObject Parent =>
            FluentSysXmlFactory.Create(Node?.ParentNode);

        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlChildSet(Node);

        public virtual string Name =>
            (Node)?
            .Name;

        public virtual string Xml =>
            (Node)?.InnerXml;

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
            Node?.OuterXml ?? string.Empty;
    }
}