using System.Xml;

namespace Saxxon.Xml.Test
{
    public class FluentSysXmlLinqTests : FluentCommonTests
    {
        protected override IFluentXmlDocument GetDocument(string xml = null)
        {
            var doc = new XmlDocument();
            if (xml != null)
                doc.LoadXml(xml);
            return doc.Fluent();
        }
    }
}