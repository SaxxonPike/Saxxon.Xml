using System;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal abstract class FluentSysXmlLinqObjectBase : IFluentXmlObject
    {
        public virtual IFluentXmlNode Parent =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create(Node?.Parent);

        public virtual string Name =>
            (Node as XElement)?
            .Name
            .ToString();

        public string Namespace =>
            (Node as XElement)?
            .GetPrefixOfNamespace((Node as XElement).Name.Namespace);

        public virtual string Value
        {
            get => (Node as XElement)?.Value;
            set
            {
                switch (Node)
                {
                    case XComment comment:
                        comment.Value = value;
                        break;
                    case XElement element:
                        element.SetValue(value);
                        break;
                    case XText text:
                        text.Value = value;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public abstract XObject Node { get; }

        public override string ToString() =>
            Node?.ToString() ?? string.Empty;
    }
}