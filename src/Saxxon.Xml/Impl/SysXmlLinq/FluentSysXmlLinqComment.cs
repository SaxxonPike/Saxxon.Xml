using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqComment : FluentSysXmlLinqBase, IFluentXmlComment
    {
        private readonly XComment _comment;

        public FluentSysXmlLinqComment(XComment comment)
        {
            _comment = comment;
        }

        public override XObject Node => _comment;

        public override string Value
        {
            get => _comment.Value;
            set => _comment.Value = value;
        }
    }
}