using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public abstract partial class FluentCommonTests
    {
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
    }
}