using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public abstract partial class FluentCommonTests
    {
        [Test]
        public void Node_ShouldAddComment()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root>" +
                                       "</root>");

            // Act.
            document
                .Root
                .AppendComment("comment one")
                .AppendComment(c => c.SetValue("comment two"));
            
            // Assert.
            document
                .Root
                .Use(r => r.Children[0]
                    .As<IFluentXmlComment>()
                    .Value
                    .Should()
                    .Be("comment one"))
                .Use(r => r.Children[1]
                    .As<IFluentXmlComment>()
                    .Value
                    .Should()
                    .Be("comment two"));
        }

        [Test]
        public void Node_ShouldGetXml()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root>" +
                                       "<test>content</test>" +
                                       "</root>");

            // Act.
            document
                .Root
                .Xml
                .Should().Be("<test>content</test>");
        }

        [Test]
        public void Node_ShouldNavigateNextAndPrevious()
        {
            // Arrange.
            var doc = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                  "<root>" +
                                  "  <sibling1>" +
                                  "    <descendant1>" +
                                  "    </descendant1>" +
                                  "  </sibling1>" +
                                  "  <sibling2>" +
                                  "  </sibling2>" +
                                  "</root>");

            // Assert
            doc
                .Root
                .Children["sibling1"]
                .Single()
                .Next
                .Use(node => { node.Name.Should().Be("sibling2"); })
                .Previous
                .Use(node => { node.Name.Should().Be("sibling1"); });
        }

        [Test]
        public void Node_ShouldSetAttribute()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root>" +
                                       "<test></test>" +
                                       "</root>");

            // Act.
            document
                .Root
                .Children[0]
                .SetAttribute("blah", attr => { attr.Value = "test"; });

            // Assert.
            document
                .Root
                .Children
                .Single()
                .Attributes["blah"]
                .Value
                .Should().Be("test");
        }

        [Test]
        public void Node_ShouldSetXml()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root>" +
                                       "</root>");

            // Act.
            document
                .Root
                .SetXml("<test></test>");

            // Assert.
            document
                .Root
                .Children
                .Single()
                .Name
                .Should().Be("test");
        }

        [Test]
        public void Node_ShouldSetXmlByText()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root>" +
                                       "</root>");

            // Act.
            document
                .Root
                .SetXml("text node");

            // Assert.
            document
                .Root
                .Children
                .Single()
                .Value
                .Should().Be("text node");
        }
    }
}