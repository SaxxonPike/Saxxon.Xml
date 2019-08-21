using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal abstract class FluentSysXmlBase : IFluentXmlObject, IFluentXmlWrappedObject<XmlNode>
    {
        public virtual IFluentXmlObject Parent =>
            FluentSysXmlFactory.Create(Node?.ParentNode);

        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlChildSet(Node?.ChildNodes);

        public virtual string Name =>
            (Node)?
            .Name;

        public virtual string InnerXml =>
            (Node)?.InnerXml;

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlAttributeSet(Node);

        public abstract XmlNode Node { get; }
    }
}