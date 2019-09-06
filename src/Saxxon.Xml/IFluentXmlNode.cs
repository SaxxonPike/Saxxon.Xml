namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML node.
    /// </summary>
    public interface IFluentXmlNode : IFluentXmlObject
    {
        /// <summary>
        /// Get the Nth sibling node of the same type. 
        /// </summary>
        IFluentXmlNode this[int index] { get; }

        /// <summary>
        /// Get or set the inner XML of this node.
        /// </summary>
        string Xml { get; set; }

        /// <summary>
        /// Get the collection of child nodes that belong to this node.
        /// </summary>
        IFluentXmlChildSet Children { get; }

        /// <summary>
        /// Get the collection of attributes for this node.
        /// </summary>
        IFluentXmlAttributeSet Attributes { get; }

        /// <summary>
        /// Get the next sibling of this node.
        /// </summary>
        IFluentXmlNode Next { get; }

        /// <summary>
        /// Get the previous sibling of this node.
        /// </summary>
        IFluentXmlNode Previous { get; }
    }
}