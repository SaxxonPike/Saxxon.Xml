using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqComment : FluentSysXmlLinqNode, IFluentXmlComment
    {
        private readonly XComment _comment;

        public FluentSysXmlLinqComment(XComment comment) : base(comment)
        {
            _comment = comment;
        }
    }
}