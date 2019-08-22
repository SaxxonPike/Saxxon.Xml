namespace Saxxon.Xml
{
    public interface IFluentXmlDocument : IFluentXmlNode
    {
        IFluentXmlDeclaration Declaration { get; }

        IFluentXmlObject Root { get; }

        IFluentXmlEntitySet Entities { get; }
    }
}