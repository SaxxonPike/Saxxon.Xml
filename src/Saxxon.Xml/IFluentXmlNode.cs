namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML node.
    /// </summary>
    public interface IFluentXmlNode : IFluentXmlObject
    {
        IFluentXmlNode this[int index] { get; }

        string Xml { get; set; }

        IFluentXmlChildSet Children { get; }

        IFluentXmlAttributeSet Attributes { get; }

        IFluentXmlNode Next { get; }

        IFluentXmlNode Previous { get; }
    }
}