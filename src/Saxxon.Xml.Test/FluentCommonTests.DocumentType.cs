using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public abstract partial class FluentCommonTests
    {
        [Test]
        public void DocumentType_ShouldGetName()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<!DOCTYPE html>" +
                                       "<html>" +
                                       "</html>");

            // Act.
            document
                .Type
                .Name
                .Should()
                .Be("DOCTYPE");
        }

        [Test]
        public void DocumentType_ShouldGetId()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<!DOCTYPE html>" +
                                       "<html>" +
                                       "</html>");

            // Act.
            document
                .Type
                .Id
                .Should()
                .Be("html");
        }

        [Test]
        public void DocumentType_ShouldGetPublicId()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01//EN\" " +
                                       "\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
                                       "<html>" +
                                       "</html>");

            // Act/Assert.
            document
                .Type
                .PublicId
                .Should()
                .Be("-//W3C//DTD HTML 4.01//EN");
        }
        
        [Test]
        public void DocumentType_ShouldGetInternalSubset()
        {
            // Arrange.
            var document = GetDocument("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                       "<!DOCTYPE html [<!-- test -->]>" +
                                       "<html>" +
                                       "</html>");

            // Act/Assert.
            document
                .Type
                .InternalSubset
                .Should()
                .Be("<!-- test -->");
        }
    }
}