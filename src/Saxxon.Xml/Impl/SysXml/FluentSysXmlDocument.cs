using System.Linq;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlDocument : FluentSysXmlBase, IFluentXmlDocument
    {
        private readonly XmlDocument _doc;

        public FluentSysXmlDocument(XmlDocument doc)
        {
            _doc = doc;
        }

        public override XmlNode Node => _doc;

        public IFluentXmlDeclaration Declaration
        {
            get
            {
                var declaration = _doc.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
                return declaration == null ? null : new FluentSysXmlDeclaration(declaration);
            }
        }

        public IFluentXmlDocumentType Type =>
            (IFluentXmlDocumentType) FluentSysXmlFactory.Create(_doc?.DocumentType);

        public IFluentXmlNode Root =>
            (IFluentXmlNode) FluentSysXmlFactory.Create(_doc?.ChildNodes.OfType<XmlElement>().Single());

        public IFluentXmlEntitySet Entities => new FluentSysXmlEntitySet(_doc);
    }
}