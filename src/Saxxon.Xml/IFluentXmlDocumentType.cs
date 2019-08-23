namespace Saxxon.Xml
{
    public interface IFluentXmlDocumentType : IFluentXmlObject
    {
        string SystemId { get; set; }

        string PublicId { get; set; }

        string InternalSubset { get; set; }
    }
}