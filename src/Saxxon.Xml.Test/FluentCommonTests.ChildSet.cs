using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public abstract partial class FluentCommonTests
    {
        [Test]
        public void ChildSet_ShouldAddNewComment()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            // Act.
            doc
                .Root
                .AppendComment("some comment");

            // Assert.
            doc
                .Root
                .Children
                .Single()
                .As<IFluentXmlComment>()
                .Value
                .Should()
                .Be("some comment");
        }

        [Test]
        public void ChildSet_ShouldAddNewElement()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            // Act.
            doc
                .Root
                .AppendElement("child1")
                .AppendElement("child2", x => x.Value = "test");

            // Assert.
            doc
                .Root
                .Use(root =>
                {
                    root
                        .Children
                        .WithName("child1")
                        .Single().Use(node =>
                        {
                            node.Name.Should().Be("child1");
                            node.Value.Should().BeEmpty();
                        });
                })
                .Use(root =>
                {
                    root
                        .Children
                        .WithName("child2")
                        .Single().Use(node =>
                        {
                            node.Name.Should().Be("child2");
                            node.Value.Should().Be("test");
                        });
                });
        }

        [Test]
        public void ChildSet_ShouldAddNewText()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "</root>");

            // Act.
            doc
                .Root
                .AppendText("some text");

            // Assert.
            doc
                .Root
                .Children
                .Single()
                .As<IFluentXmlText>()
                .Value
                .Should()
                .Be("some text");
        }

        [Test]
        public void ChildSet_ShouldRemoveChild()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "  <child1></child1>" +
                                  "  <child2></child2>" +
                                  "</root>");

            // Act.
            doc
                .Root
                .RemoveChildrenWhere(x => x.Name == "child1");

            // Assert.
            doc
                .Root
                .Children
                .Should()
                .NotContain(x => x.Name == "child1")
                .And
                .Contain(x => x.Name == "child2");
        }

        [Test]
        public void ChildSet_ShouldReturnCorrectElements()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "  <child1></child1>" +
                                  "  <child2>text1<!--comment-->text2</child2>" +
                                  "  <child3><child4></child4></child3>" +
                                  "</root>");

            // Assert.
            doc
                .Root
                .Use(x => x.Children[0].Use(c =>
                {
                    c.Name.Should().Be("child1");
                    c.Children.Should().BeEmpty();
                }))
                .Use(x => x.Children[1].Use(c =>
                {
                    c.Name.Should().Be("child2");
                    c.Children.Should().HaveCount(3);
                    c.Children[0]
                        .As<IFluentXmlText>()
                        .Value.Should().Be("text1");
                    c.Children[1]
                        .As<IFluentXmlComment>()
                        .Value.Should().Be("comment");
                    c.Children[2]
                        .As<IFluentXmlText>()
                        .Value.Should().Be("text2");
                }))
                .Use(x => x.Children[2].Use(c =>
                {
                    c.Name.Should().Be("child3");
                    c.Children.Should().HaveCount(1);
                    c.Children[0]
                        .As<IFluentXmlElement>()
                        .Name.Should().Be("child4");
                }));
        }
    }
}