namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML document type.
    /// </summary>
    public interface IFluentXmlDocumentType : IFluentXmlObject
    {
        /// <summary>
        /// Get or set the System ID for this document.
        /// </summary>
        string SystemId { get; set; }

        /// <summary>
        /// Get or set the Public ID for this document.
        /// </summary>
        string PublicId { get; set; }

        /// <summary>
        /// Get or set the Internal Subset for this document.
        /// </summary>
        string InternalSubset { get; set; }
    }
}