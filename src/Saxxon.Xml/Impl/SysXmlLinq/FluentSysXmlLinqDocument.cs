using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqDocument : FluentSysXmlLinqNodeBase, IFluentXmlDocument
    {
        private readonly XDocument _doc;

        public FluentSysXmlLinqDocument(XDocument doc)
        {
            _doc = doc;
        }

        public override XObject Node => _doc;

        public IFluentXmlDeclaration Declaration =>
            _doc?.Declaration == null ? null : new FluentSysXmlLinqDeclaration(_doc.Declaration);

        public IFluentXmlNode Root =>
            (IFluentXmlNode) FluentSysXmlLinqFactory.Create(_doc?.Root);

        public IFluentXmlEntitySet Entities => new FluentSysXmlLinqEntitySet();
    }
}