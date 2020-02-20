using System.Linq;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;
using Saxxon.Xml.Impl.SysXml;

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
                .Use(d => d.Encoding.Should().Be("ASCII"))
                .Use(d => d.Standalone.Should().Be("yes"));
        }

        [Test]
        public void Fluent_ShouldReturnWrappedAttribute()
        {
            // Arrange.
            var document = new XmlDocument();
            document.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                             "<root test=\"attr\">" +
                             "</root>");

            // Act.
            var fluent = document.ChildNodes.OfType<XmlElement>().First().Attributes["test"].Fluent();

            // Assert.
            fluent.Name.Should().Be("test");
            fluent.Value.Should().Be("attr");
        }

        [Test]
        public void Fluent_ShouldReturnWrappedComment()
        {
            // Arrange.
            var document = new XmlDocument();
            document.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                             "<root>" +
                             "<!--blah-->" +
                             "</root>");

            // Act.
            var fluent = document.ChildNodes.OfType<XmlElement>().First().ChildNodes[0].Fluent();

            // Assert.
            fluent.Value.Should().Be("blah");
        }

        [Test]
        public void Fluent_ShouldReturnWrappedDeclaration()
        {
            // Arrange.
            var document = new XmlDocument();
            document.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                             "<root test=\"attr\">" +
                             "<!--blah-->" +
                             "</root>");

            // Act.
            var fluent = document.ChildNodes.OfType<XmlDeclaration>().First().Fluent();

            // Assert.
            fluent.Version.Should().Be("1.0");
            fluent.Encoding.Should().Be("UTF-8");
            fluent.Standalone.Should().BeEmpty();
        }

        [Test]
        public void Node_ShouldGetUnderlyingNode()
        {
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>")
                .As<FluentSysXmlDocument>();

            var node = doc.Node;
            node.Fluent().AsXmlNode().Should().BeSameAs(node);
        }
    }
}