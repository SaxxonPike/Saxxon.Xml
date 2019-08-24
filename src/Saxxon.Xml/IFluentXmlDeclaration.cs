namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML declaration.
    /// </summary>
    public interface IFluentXmlDeclaration : IFluentXmlObject
    {
        string Encoding { get; set; }

        string Standalone { get; set; }

        string Version { get; set; }
    }
}