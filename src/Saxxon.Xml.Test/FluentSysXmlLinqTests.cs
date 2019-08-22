using System.Xml.Linq;
using FluentAssertions;
using NUnit.Framework;
using Saxxon.Xml.Impl;

namespace Saxxon.Xml.Test
{
    public class FluentSysXmlLinqTests : FluentCommonTests
    {
        protected override IFluentXmlDocument GetDocument(string xml = null)
        {
            var doc = xml != null ? XDocument.Parse(xml) : new XDocument();
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
                .SetStandalone("yes")
                .SetVersion("1.1");

            doc
                .Declaration
                .Use(d => d.Encoding.Should().Be("ASCII"))
                .Use(d => d.Standalone.Should().Be("yes"))
                .Use(d => d.Version.Should().Be("1.1"));
        }
    }
}