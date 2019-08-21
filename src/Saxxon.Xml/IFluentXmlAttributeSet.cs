using System.Collections.Generic;

namespace Saxxon.Xml
{
    public interface IFluentXmlAttributeSet : IEnumerable<IFluentXmlAttribute>
    {
        IFluentXmlAttribute this[string key] { get; }
        
        IFluentXmlAttribute this[int index] { get; }
    }
}