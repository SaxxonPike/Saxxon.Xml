using Moq;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public abstract partial class FluentCommonTests
    {
        [Test]
        public void Object_IfNull_ShouldExecute_WhenNull()
        {
            // Arrange.
            IFluentXmlObject obj = null;
            
            // Act.
            // ReSharper disable once ExpressionIsAlwaysNull
            obj.IfNull(Pass);
            
            // Assert.
            Fail("delegate was not called");
        }

        [Test]
        public void Object_IfNull_ShouldNotExecute_WhenNotNull()
        {
            // Arrange.
            var obj = new Mock<IFluentXmlObject>().Object;
            
            // Act.
            obj.IfNull(() => Fail("delegate was called"));
            
            // Assert.
            Pass();
        }

        [Test]
        public void Object_IfNotNull_ShouldNotExecute_WhenNull()
        {
            // Arrange.
            IFluentXmlObject obj = null;
            
            // Act.
            // ReSharper disable once ExpressionIsAlwaysNull
            obj.IfNotNull(_ => Fail("delegate was called"));
            
            // Assert.
            Pass();
        }

        [Test]
        public void Object_IfNotNull_ShouldExecute_WhenNotNull()
        {
            // Arrange.
            var obj = new Mock<IFluentXmlObject>().Object;
            
            // Act.
            obj.IfNotNull(_ => Pass());
            
            // Assert.
            Fail("delegate was not called");
        }
    }
}