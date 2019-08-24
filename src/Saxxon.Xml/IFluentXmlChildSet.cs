using System.Collections.Generic;

namespace Saxxon.Xml
{
    /// <summary>
    ///     A fluent interface representing a collection of child nodes within an XML node.
    /// </summary>
    public interface IFluentXmlChildSet : IEnumerable<IFluentXmlNode>
    {
        /// <summary>
        ///     Get the node at the specified index. Returns null if the node does not exist.
        /// </summary>
        /// <param name="index"></param>
        IFluentXmlNode this[int index] { get; }

        IEnumerable<IFluentXmlNode> this[string name] { get; }

        IFluentXmlElement CreateElement(string name);

        IFluentXmlComment CreateComment();

        void Remove(IFluentXmlNode node);

        IFluentXmlText CreateText();
    }
}