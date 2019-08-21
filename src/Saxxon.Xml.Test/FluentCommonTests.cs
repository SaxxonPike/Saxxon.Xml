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
        public void ChildSet_ShouldAddNewElement()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            // Act.
            doc
                .Children
                .WithName("root")
                .Single()
                .Children
                .AddElement("child1")
                .AddElement("child2", "content")
                .AddElementUsing("child3", x => x.Value = "test");

            // Assert.
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
        public void ChildSet_ShouldReturnCorrectElements()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "  <child1></child1>" +
                                  "  <child2></child2>" +
                                  "</root>");

            // Assert.
            doc
                .Children["root"]
                .First()
                .Children
                .Select(x => x.Name)
                .Should().Equal("child1", "child2");
        }

        [Test]
        public void AttributeSet_ShouldAddNewAttribute()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            // Act.
            document
                .Children
                .WithName("root")
                .ForEach(rootNode =>
                    rootNode.Attributes
                        .Add("testkey", "testvalue")
                        .Add("testkey2", "testvalue2"));

            // Assert.
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