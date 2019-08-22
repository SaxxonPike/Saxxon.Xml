namespace Saxxon.Xml
{
    public interface IFluentXmlNode : IFluentXmlObject
    {
        string Xml { get; }

        IFluentXmlChildSet Children { get; }

        IFluentXmlAttributeSet Attributes { get; }

        IFluentXmlNode NextNode { get; }

        IFluentXmlNode PreviousNode { get; }
    }
}