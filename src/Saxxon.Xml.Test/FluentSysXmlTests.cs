using System.Xml.Linq;

namespace Saxxon.Xml.Test
{
    public class FluentSysXmlTests : FluentCommonTests
    {
        protected override IFluentXmlDocument GetDocument(string xml = null)
        {
            var doc = xml != null ? XDocument.Parse(xml) : new XDocument();
            return doc.Fluent();
        }
    }
}