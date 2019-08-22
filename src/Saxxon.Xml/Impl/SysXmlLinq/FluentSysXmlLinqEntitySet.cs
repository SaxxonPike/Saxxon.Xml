using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqEntitySet : IFluentXmlEntitySet
    {
        public IEnumerator<IFluentXmlEntity> GetEnumerator() =>
            Enumerable.Empty<IFluentXmlEntity>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}