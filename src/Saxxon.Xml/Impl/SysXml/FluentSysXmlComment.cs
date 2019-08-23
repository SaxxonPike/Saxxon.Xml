using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlComment : FluentSysXmlBase, IFluentXmlComment
    {
        private readonly XmlComment _comment;

        public FluentSysXmlComment(XmlComment comment)
        {
            _comment = comment;
        }

        public override XmlNode Node => _comment;
    }
}