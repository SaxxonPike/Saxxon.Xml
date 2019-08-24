namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML object, which can be either a node type or an attribute type.
    /// </summary>
    public interface IFluentXmlObject
    {
        IFluentXmlNode Parent { get; }

        string Name { get; }

        string Namespace { get; }

        string Value { get; set; }
    }
}