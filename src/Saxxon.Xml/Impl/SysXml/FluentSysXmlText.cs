using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal class FluentSysXmlText : FluentSysXmlBase, IFluentXmlText
    {
        private readonly XmlText _text;

        public FluentSysXmlText(XmlText text)
        {
            _text = text;
        }

        public override XmlNode Node => _text;
    }
}