using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        [ExcludeFromCodeCoverage]
        protected static string RandomString()
        {
            return TestContext.CurrentContext.Random.GetString();
        }

        [ExcludeFromCodeCoverage]
        protected static string RandomString(int length)
        {
            return TestContext.CurrentContext.Random.GetString(length);
        }

        [ExcludeFromCodeCoverage]
        protected static int RandomInt()
        {
            return TestContext.CurrentContext.Random.Next();
        }

        [ExcludeFromCodeCoverage]
        protected static int RandomInt(int max)
        {
            return TestContext.CurrentContext.Random.Next(max);
        }

        [ExcludeFromCodeCoverage]
        protected static int RandomInt(int min, int max)
        {
            return TestContext.CurrentContext.Random.Next(min, max);
        }
    }
}