using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqNode : FluentSysXmlLinqBase, IFluentXmlNode
    {
        public FluentSysXmlLinqNode(XObject node)
        {
            Node = node;
        }

//        public virtual IFluentXmlObject this[int index] =>
//            (Node as XContainer)?
//            .Elements()
//            .Skip(index)
//            .Select(FluentSysXmlLinqFactory.Create)
//            .FirstOrDefault() ??
//            throw new IndexOutOfRangeException();
//
//        public virtual IEnumerable<IFluentXmlObject> this[string name] =>
//            (Node as XContainer)?
//            .Elements()
//            .Where(x => name == x.Name.ToString())
//            .Select(FluentSysXmlLinqFactory.Create);
//
        public override XObject Node { get; }
    }
}