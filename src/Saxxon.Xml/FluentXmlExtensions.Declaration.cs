// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static IFluentXmlDeclaration SetVersion(this IFluentXmlDeclaration self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.Version = value;
            return self;
        }

        public static IFluentXmlDeclaration SetStandalone(this IFluentXmlDeclaration self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.Standalone = value;
            return self;
        }

        public static IFluentXmlDeclaration SetEncoding(this IFluentXmlDeclaration self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.Encoding = value;
            return self;
        }
    }
}