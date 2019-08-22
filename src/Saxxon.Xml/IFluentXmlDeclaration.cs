namespace Saxxon.Xml
{
    public interface IFluentXmlDeclaration : IFluentXmlNode
    {
        string Encoding { get; set; }
        
        string Standalone { get; set; }
        
        string Version { get; set; }
    }
}