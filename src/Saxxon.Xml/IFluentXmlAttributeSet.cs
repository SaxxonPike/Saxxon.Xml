using System.Collections.Generic;

namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing a set of XML attributes attached to an XML object.
    /// </summary>
    public interface IFluentXmlAttributeSet : IEnumerable<IFluentXmlAttribute>
    {
        /// <summary>
        ///     Get an attribute with the specified key. This will not return null if the attribute
        ///     does not exist; its inner value will be null in this case.
        /// </summary>
        IFluentXmlAttribute this[string key] { get; }

        /// <summary>
        ///     Get all the attribute keys that have values.
        /// </summary>
        IEnumerable<string> Keys { get; }
    }
}