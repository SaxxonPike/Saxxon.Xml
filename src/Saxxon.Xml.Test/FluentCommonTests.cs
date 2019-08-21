using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    [TestFixture]
    public abstract class FluentCommonTests
    {
        protected abstract IFluentXmlDocument GetDocument(string xml = null);

        [Test]
        public void Children_ReturnsCorrectElements()
        {
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "  <child1></child1>" +
                                  "  <child2></child2>" +
                                  "</root>");

            doc.Children["root"].First()
                .Children
                .Should()
                .HaveCount(2)
                .And
                .OnlyContain(x => x.Name == "child1" || x.Name == "child2");
        }

        [Test]
        public void AddAttribute_ReturnsAddedAttribute()
        {
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            document
                .Children
                .WithName("root")
                .ForEach(rootNode =>
                    rootNode.Attributes
                        .Add("testkey", "testvalue")
                        .Add("testkey2", "testvalue2"));

            document
                .Children
                .WithName("root")
                .Single()
                .Attributes
                .WithName("testkey")
                .Single()
                .Value
                .Should().Be("testvalue");
        }
    }
}