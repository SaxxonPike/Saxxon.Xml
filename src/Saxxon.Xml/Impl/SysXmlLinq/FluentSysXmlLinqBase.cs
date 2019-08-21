using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal abstract class FluentSysXmlLinqBase : IFluentXmlObject, IFluentXmlWrappedObject<XObject>
    {
        public virtual IFluentXmlObject Parent =>
            FluentSysXmlLinqFactory.Create(Node?.Parent);

        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlLinqChildSet(Node as XContainer);

        public virtual string Name =>
            (Node as XElement)?
            .Name
            .ToString();
        
        public virtual string InnerXml =>
            (Node as XNode)?
            .ToString();

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlLinqAttributeSet(Node as XElement);

        public abstract XObject Node { get; }
    }
}