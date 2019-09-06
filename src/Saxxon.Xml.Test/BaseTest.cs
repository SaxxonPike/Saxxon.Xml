using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Saxxon.Xml.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        [ExcludeFromCodeCoverage]
        protected static string RandomString() => 
            TestContext.CurrentContext.Random.GetString();

        [ExcludeFromCodeCoverage]
        protected static string RandomString(int length) => 
            TestContext.CurrentContext.Random.GetString(length);

        [ExcludeFromCodeCoverage]
        protected static int RandomInt() => 
            TestContext.CurrentContext.Random.Next();

        [ExcludeFromCodeCoverage]
        protected static int RandomInt(int max) => 
            TestContext.CurrentContext.Random.Next(max);

        [ExcludeFromCodeCoverage]
        protected static int RandomInt(int min, int max) => 
            TestContext.CurrentContext.Random.Next(min, max);

        [ExcludeFromCodeCoverage]
        protected static void Pass() => 
            NUnit.Framework.Assert.Pass();

        [ExcludeFromCodeCoverage]
        protected static void Pass(string reason) => 
            NUnit.Framework.Assert.Pass(reason);
        
        [ExcludeFromCodeCoverage]
        protected static void Fail() => 
            NUnit.Framework.Assert.Fail();

        [ExcludeFromCodeCoverage]
        protected static void Fail(string reason) => 
            NUnit.Framework.Assert.Fail(reason);
    }
}