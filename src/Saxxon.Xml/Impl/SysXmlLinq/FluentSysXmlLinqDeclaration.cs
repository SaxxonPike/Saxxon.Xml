using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqDeclaration : FluentSysXmlLinqObjectBase, IFluentXmlDeclaration
    {
        private readonly XDeclaration _declaration;

        public FluentSysXmlLinqDeclaration(XDeclaration declaration)
        {
            _declaration = declaration;
        }

        public override XObject Node => null;

        public string Encoding
        {
            get => _declaration?.Encoding;
            set
            {
                if (_declaration != null)
                    _declaration.Encoding = value;
            }
        }

        public string Standalone
        {
            get => _declaration?.Standalone;
            set
            {
                if (_declaration != null)
                    _declaration.Standalone = value;
            }
        }

        public string Version
        {
            get => _declaration?.Version;
            set
            {
                if (_declaration != null)
                    _declaration.Version = value;
            }
        }
    }
}