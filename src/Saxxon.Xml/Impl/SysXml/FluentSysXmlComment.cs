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

//        public override string Value
//        {
//            get => _comment.Value;
//            set => _comment.Value = value;
//        }
        
        public override XmlNode Node => _comment;
    }
}