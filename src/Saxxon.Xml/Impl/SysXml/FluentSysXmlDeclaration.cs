using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlDeclaration : FluentSysXmlBase, IFluentXmlDeclaration
    {
        private readonly XmlDeclaration _declaration;

        public FluentSysXmlDeclaration(XmlDeclaration declaration)
        {
            _declaration = declaration;
        }

        public override XmlNode Node => _declaration;
    }
}