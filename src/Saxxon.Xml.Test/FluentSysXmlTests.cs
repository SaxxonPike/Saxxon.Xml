using System.Xml;
using FluentAssertions;
using NUnit.Framework;
using Saxxon.Xml.Impl;

namespace Saxxon.Xml.Test
{
    public class FluentSysXmlTests : FluentCommonTests
    {
        protected override IFluentXmlDocument GetDocument(string xml = null)
        {
            var doc = new XmlDocument();
            if (xml != null)
                doc.LoadXml(xml);
            return doc.Fluent();
        }

        [Test]
        public void Declaration_CanGetAndSetProperties()
        {
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            doc
                .Declaration
                .SetEncoding("ASCII")
                .SetStandalone("yes");

            doc
                .Declaration
                .Within(d => d.Encoding.Should().Be("ASCII"))
                .Within(d => d.Standalone.Should().Be("yes"));
        }
    }
}