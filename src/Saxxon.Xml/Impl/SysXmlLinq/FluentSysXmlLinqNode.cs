using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqNode : IFluentXmlNode, IFluentXmlWrappedObject<XObject>
    {
        public FluentSysXmlLinqNode(XObject node)
        {
            Node = node;
        }

        public virtual IFluentXmlObject Parent =>
            FluentSysXmlLinqFactory.Create(Node?.Parent);

        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlLinqChildSet(Node as XContainer);

        public virtual string Name =>
            (Node as XElement)?
            .Name
            .ToString();

        public virtual IFluentXmlObject this[int index] =>
            (Node as XContainer)?
            .Elements()
            .Skip(index)
            .Select(FluentSysXmlLinqFactory.Create)
            .FirstOrDefault() ??
            throw new IndexOutOfRangeException();

        public virtual IEnumerable<IFluentXmlObject> this[string name] =>
            (Node as XContainer)?
            .Elements()
            .Where(x => name == x.Name.ToString())
            .Select(FluentSysXmlLinqFactory.Create);

        public virtual string InnerXml =>
            (Node as XNode)?
            .ToString();

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlLinqAttributeSet(Node as XElement);

//        public IFluentXmlAttribute AddAttribute(Action<IFluentXmlAttributeBuilder> setup)
//        {
//            var builder = new FluentSysXmlLinqAttributeBuilder();
//            setup(builder);
//            var attribute = builder.Create();
//            var element = Node as XElement;
//            element?.SetAttributeValue(attribute.Name, attribute.Value);
//            return new FluentSysXmlLinqAttribute(element?.Attribute(attribute.Name));
//        }

        public virtual XObject Node { get; }
    }
}