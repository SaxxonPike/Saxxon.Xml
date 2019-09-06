namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML declaration.
    /// </summary>
    public interface IFluentXmlDeclaration : IFluentXmlObject
    {
        /// <summary>
        /// Get or set the text encoding for the document.
        /// </summary>
        string Encoding { get; set; }

        /// <summary>
        /// Get or set the standalone value, indicating whether or not external resources are expected.
        /// </summary>
        string Standalone { get; set; }

        /// <summary>
        /// Get or set the XML version number.
        /// </summary>
        string Version { get; set; }
    }
}