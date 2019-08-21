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
        public void Children_Add_ShouldAddElement()
        {
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            doc
                .Children
                .WithName("root")
                .Single()
                .Children
                .AddElement("child1")
                .AddElement("child2", "content")
                .AddElementUsing("child3", x => x.Value = "test");

            doc
                .Children
                .WithName("root")
                .Single()
                .Scope(root =>
                {
                    root
                        .Children
                        .WithName("child1")
                        .Single()
                        .Scope(node =>
                        {
                            node.Name.Should().Be("child1");
                            node.Value.Should().BeEmpty();
                        });
                })
                .Scope(root =>
                {
                    root
                        .Children
                        .WithName("child2")
                        .Single()
                        .Scope(node =>
                        {
                            node.Name.Should().Be("child2");
                            node.Value.Should().Be("content");
                        });
                })
                .Scope(root =>
                {
                    root
                        .Children
                        .WithName("child3")
                        .Single()
                        .Scope(node =>
                        {
                            node.Name.Should().Be("child3");
                            node.Value.Should().Be("test");
                        });
                });
        }
        
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