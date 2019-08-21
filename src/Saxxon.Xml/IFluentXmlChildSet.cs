using System.Collections.Generic;

namespace Saxxon.Xml
{
    public interface IFluentXmlChildSet : IEnumerable<IFluentXmlObject>
    {
        IFluentXmlObject this[int index] { get; }

        IEnumerable<IFluentXmlObject> this[string name] { get; }
    }
}