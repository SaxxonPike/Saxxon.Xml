namespace Saxxon.Xml
{
    public interface IFluentXmlEntity : IFluentXmlNode
    {
        string SystemId { get; }
        
        string PublicId { get; }
        
        string NotationName { get; }
    }
}