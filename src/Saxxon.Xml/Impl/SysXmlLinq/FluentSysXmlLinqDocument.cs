using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqDocument : FluentSysXmlLinqNode, IFluentXmlDocument
    {
        private readonly XDocument _doc;

        public FluentSysXmlLinqDocument(XDocument doc) : base(doc)
        {
            _doc = doc;
        }
    }
}