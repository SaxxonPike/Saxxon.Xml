namespace Saxxon.Xml
{
    public interface IFluentXmlDocument : IFluentXmlNode
    {
        IFluentXmlDeclaration Declaration { get; }

        IFluentXmlNode Root { get; }

        IFluentXmlEntitySet Entities { get; }
    }
}