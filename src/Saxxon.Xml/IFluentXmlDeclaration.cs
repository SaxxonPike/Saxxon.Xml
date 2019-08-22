namespace Saxxon.Xml
{
    public interface IFluentXmlDeclaration : IFluentXmlObject
    {
        string Encoding { get; set; }

        string Standalone { get; set; }

        string Version { get; set; }
    }
}