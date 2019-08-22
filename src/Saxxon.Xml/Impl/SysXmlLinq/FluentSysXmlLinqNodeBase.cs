using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal abstract class FluentSysXmlLinqNodeBase : FluentSysXmlLinqObjectBase, IFluentXmlNode
    {
        public virtual IFluentXmlChildSet Children =>
            new FluentSysXmlLinqChildSet(Node as XContainer);

        public virtual string Xml =>
            (Node as XNode)?
            .ToString();

        public virtual IFluentXmlAttributeSet Attributes =>
            new FluentSysXmlLinqAttributeSet(Node as XElement);

        public IFluentXmlNode Next =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create((Node as XNode)?.NextNode);

        public IFluentXmlNode Previous =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create((Node as XNode)?.PreviousNode);
    }
}