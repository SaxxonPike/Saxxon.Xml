using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlText : FluentSysXmlBase, IFluentXmlText
    {
        private readonly XmlText _text;

        public FluentSysXmlText(XmlText text)
        {
            _text = text;
        }

        public override XmlNode Node => _text;
    }
}