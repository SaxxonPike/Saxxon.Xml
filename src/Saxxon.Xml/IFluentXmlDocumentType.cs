namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML document type.
    /// </summary>
    public interface IFluentXmlDocumentType : IFluentXmlObject
    {
        string SystemId { get; set; }

        string PublicId { get; set; }

        string InternalSubset { get; set; }
    }
}