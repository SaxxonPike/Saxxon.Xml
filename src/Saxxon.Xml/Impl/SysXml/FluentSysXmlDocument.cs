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
    }
}