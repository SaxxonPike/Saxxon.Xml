namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML entity.
    /// </summary>
    public interface IFluentXmlEntity : IFluentXmlNode
    {
        string SystemId { get; }

        string PublicId { get; }

        string NotationName { get; }
    }
}