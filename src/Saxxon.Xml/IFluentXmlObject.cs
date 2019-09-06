namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML object, which can be either a node type or an attribute type.
    /// </summary>
    public interface IFluentXmlObject
    {
        /// <summary>
        /// Get the parent node of this object.
        /// </summary>
        IFluentXmlNode Parent { get; }

        /// <summary>
        /// Get the name of this object.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the namespace of this object.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// Get or set the text value of this object.
        /// </summary>
        string Value { get; set; }
    }
}