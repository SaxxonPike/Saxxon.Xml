using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqDeclaration : FluentSysXmlLinqNode, IFluentXmlDeclaration
    {
        private readonly XDeclaration _declaration;

        public FluentSysXmlLinqDeclaration(XDeclaration declaration) : base(null)
        {
            // declaration is not an object type in System.Xml.Linq like it is in System.Xml
            _declaration = declaration;
        }
    }
}