namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML document.
    /// </summary>
    public interface IFluentXmlDocument : IFluentXmlNode
    {
        /// <summary>
        /// Get the declaration object for to this document.
        /// </summary>
        IFluentXmlDeclaration Declaration { get; }

        /// <summary>
        /// Get the root element of this document.
        /// </summary>
        IFluentXmlNode Root { get; }

        /// <summary>
        /// Get the entity collection for this document.
        /// </summary>
        IFluentXmlEntitySet Entities { get; }
    }
}