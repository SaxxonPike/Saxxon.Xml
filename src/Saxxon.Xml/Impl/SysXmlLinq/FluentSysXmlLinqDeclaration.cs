using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal sealed class FluentSysXmlLinqDeclaration : FluentSysXmlLinqObjectBase, IFluentXmlDeclaration
    {
        // XDeclaration does *not* derive from XObject, making
        // this a particularly interesting case. We still treat it
        // as if it were like an XObject so that the difference
        // is entirely invisible to the end user.
        
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