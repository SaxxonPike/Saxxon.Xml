namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing an XML entity.
    /// </summary>
    public interface IFluentXmlEntity : IFluentXmlNode
    {
        /// <summary>
        /// Get or set the System ID for this entity.
        /// </summary>
        string SystemId { get; }

        /// <summary>
        /// Get or set the Public ID for this entity.
        /// </summary>
        string PublicId { get; }

        /// <summary>
        /// Get or set the Notation Name for this entity.
        /// </summary>
        string NotationName { get; }
    }
}