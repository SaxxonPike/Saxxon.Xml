using System;
using FluentAssertions;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    public class AssertTests : BaseTest
    {
        [Test]
        public void NotNull_ShouldDoNothing_WhenArgumentIsNotNull()
        {
            // Arrange.
            var argName = RandomString();

            // Act.
            Action act = () => Assert.NotNull(new object(), argName);

            // Assert.
            act
                .Invoking(x => x.Invoke())
                .Should()
                .NotThrow();
        }

        [Test]
        public void NotNull_ShouldThrowArgumentNullException_WhenArgumentIsNull()
        {
            // Arrange.
            var argName = RandomString();

            // Act.
            Action act = () => Assert.NotNull(null, argName);

            // Assert.
            act
                .Invoking(x => x.Invoke())
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage(new ArgumentNullException(argName).Message);
        }

        [Test]
        public void NotNullOrEmpty_ShouldDoNothing_WhenArgumentIsNotNullOrEmpty()
        {
            // Arrange.
            var argName = RandomString();

            // Act.
            Action act = () => Assert.NotNullOrEmpty(RandomString(), argName);

            // Assert.
            act
                .Invoking(x => x.Invoke())
                .Should()
                .NotThrow();
        }

        [Test]
        public void NotNullOrEmpty_ShouldThrowArgumentNullException_WhenArgumentIsNull()
        {
            // Arrange.
            var argName = RandomString();

            // Act.
            Action act = () => Assert.NotNullOrEmpty(null, argName);

            // Assert.
            act
                .Invoking(x => x.Invoke())
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage(new ArgumentNullException(argName).Message);
        }

        [Test]
        public void NotNullOrEmpty_ShouldThrowArgumentNullException_WhenArgumentIsEmpty()
        {
            // Arrange.
            var argName = RandomString();

            // Act.
            Action act = () => Assert.NotNullOrEmpty(string.Empty, argName);

            // Assert.
            act
                .Invoking(x => x.Invoke())
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(new ArgumentException("Argument cannot be empty", argName).Message);
        }
    }
}