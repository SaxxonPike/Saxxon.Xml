using System.Collections.Generic;

namespace Saxxon.Xml
{
    public interface IFluentXmlAttributeSet : IEnumerable<IFluentXmlAttribute>
    {
        IFluentXmlAttribute this[string key] { get; }

        IEnumerable<string> Keys { get; }
    }
}