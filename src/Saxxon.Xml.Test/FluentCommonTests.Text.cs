using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public abstract partial class FluentCommonTests
    {
        [Test]
        public void Text_ShouldBeSplitCorrectly()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "test" +
                                  "<divider></divider>" +
                                  "text" +
                                  "</root>");

            // Assert.
            doc
                .Root
                .Use(root => root.Children[0].Value.Should().Be("test"))
                .Use(root => root.Children[2].Value.Should().Be("text"));
        }

        [Test]
        public void Text_ShouldHaveCorrectValue()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "test text" +
                                  "</root>");

            // Assert.
            doc
                .Root
                .Children[0]
                .Value
                .Should()
                .Be("test text");
        }
    }
}