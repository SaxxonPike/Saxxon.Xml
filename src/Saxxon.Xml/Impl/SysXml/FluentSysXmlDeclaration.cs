using System;
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
            set => throw new NotSupportedException("XmlDeclaration does not support setting Version.");
        }

        public override string ToString()
        {
            return _declaration?.OuterXml ?? "<!--null-->";
        }
    }
}