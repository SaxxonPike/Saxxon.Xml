using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    [TestFixture]
    public abstract class FluentCommonTests
    {
        protected abstract IFluentXmlDocument GetDocument(string xml = null);

        #region AttributeSet

        #region Fetch

        [Test]
        public void AttributeSet_ShouldReturnAttributes()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root myattr1=\"val1\" myattr2=\"\" myattr3=\"val3\">" +
                                       "</root>");

            // Act.
            document
                .Root
                .Use(root => root.Attributes["myattr1"].Value.Should().Be("val1"))
                .Use(root => root.Attributes["myattr2"].Value.Should().Be(string.Empty))
                .Use(root => root.Attributes["myattr3"].Value.Should().Be("val3"));
        }

        #endregion Fetch

        #region Add

        [Test]
        public void AttributeSet_ShouldAddNewAttribute()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root>" +
                                       "</root>");

            // Act.
            document
                .Root
                .ForEach(rootNode =>
                    rootNode
                        .SetAttribute("testkey", "testvalue")
                        .SetAttribute("testkey2", "testvalue2"));

            // Assert.
            document
                .Root
                .Attributes
                .WithName("testkey")
                .Single()
                .Value
                .Should().Be("testvalue");
        }

        [Test]
        public void AttributeSet_ShouldRemoveAttributes()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<root attr1=\"test0\" attr2=\"test2\" attr3=\"test3\" attr4=\"test0\">" +
                                       "</root>");

            // Act.
            document
                .Root
                .RemoveAttribute("attr2")
                .Use(root => root.Attributes.Select(x => x.Name).Should().BeEquivalentTo("attr1", "attr3", "attr4"))
                .RemoveAttributesWhere(attr => attr.Value == "test0")
                .Use(root => root.Attributes.Select(x => x.Name).Should().BeEquivalentTo("attr3"));
        }

        #endregion Add

        #endregion AttributeSet

        #region ChildSet

        #region Fetch

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

        #endregion Fetch

        #region Add

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

        #endregion Add

        #region Remove

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

        #endregion Remove

        #region Update

        #endregion Update

        #endregion ChildSet

        #region Node

        #region Navigation

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

        #endregion Navigation

        #region Replace

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

        #endregion Replace

        #endregion Node

        #region Text

        #region Fetch

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

        #endregion Fetch

        #endregion Text
    }
}