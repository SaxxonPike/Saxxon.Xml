namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML document.
    /// </summary>
    public interface IFluentXmlDocument : IFluentXmlNode
    {
        IFluentXmlDeclaration Declaration { get; }

        IFluentXmlNode Root { get; }

        IFluentXmlEntitySet Entities { get; }
    }
}