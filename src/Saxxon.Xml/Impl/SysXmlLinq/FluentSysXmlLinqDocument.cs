using System.Linq;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqDocument : FluentSysXmlLinqBase, IFluentXmlDocument
    {
        private readonly XDocument _doc;

        public FluentSysXmlLinqDocument(XDocument doc)
        {
            _doc = doc;
        }

        public IFluentXmlDeclaration Declaration => 
            _doc?.Declaration == null ? null : new FluentSysXmlLinqDeclaration(_doc.Declaration);

        public override XObject Node => _doc;
    }
}