using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlElement : FluentSysXmlBase, IFluentXmlElement
    {
        private readonly XmlElement _element;

        public FluentSysXmlElement(XmlElement element)
        {
            _element = element;
        }

        public override XmlNode Node => _element;
    }
}