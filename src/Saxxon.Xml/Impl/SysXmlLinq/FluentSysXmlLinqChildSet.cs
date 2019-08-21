using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqChildSet : IFluentXmlChildSet
    {
        private readonly XContainer _node;

        public FluentSysXmlLinqChildSet(XContainer node)
        {
            _node = node;
        }

        public IEnumerator<IFluentXmlObject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IFluentXmlObject this[int index] => throw new NotImplementedException();

        public IEnumerable<IFluentXmlObject> this[string name] => throw new NotImplementedException();
    }
}