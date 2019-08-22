using System.Collections.Generic;

namespace Saxxon.Xml
{
    public interface IFluentXmlChildSet : IEnumerable<IFluentXmlNode>
    {
        IFluentXmlNode this[int index] { get; }

        IEnumerable<IFluentXmlNode> this[string name] { get; }

        IFluentXmlElement CreateElement(string name);

        IFluentXmlComment CreateComment();

        void Remove(IFluentXmlNode node);

        IFluentXmlText CreateText();
    }
}