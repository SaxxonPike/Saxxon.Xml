using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqText : FluentSysXmlLinqBase, IFluentXmlText
    {
        private readonly XText _text;

        public FluentSysXmlLinqText(XText text)
        {
            _text = text;
        }

        public override XObject Node => _text;

        public override string Value
        {
            get => _text.Value;
            set => _text.Value = value;
        }
    }
}