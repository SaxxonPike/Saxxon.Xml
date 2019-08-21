using System;
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
        
        public virtual string Xml =>
            (Node as XNode)?
            .ToString();

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlLinqAttributeSet(Node as XElement);

        public virtual string Value
        {
            get => (Node as XElement)?.Value;
            set
            {
                if (Node is XElement element)
                    element.SetValue(value);
                else
                    throw new InvalidOperationException();
            }
        }

        public abstract XObject Node { get; }

        public override string ToString() => 
            Node?.ToString() ?? string.Empty;
    }
}