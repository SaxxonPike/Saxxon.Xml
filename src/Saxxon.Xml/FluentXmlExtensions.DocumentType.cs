// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
    {
        public static IFluentXmlDocumentType SetSystemId(this IFluentXmlDocumentType self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.SystemId = value;
            return self;
        }
        
        public static IFluentXmlDocumentType SetPublicId(this IFluentXmlDocumentType self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.PublicId = value;
            return self;
        }
        
        public static IFluentXmlDocumentType SetInternalSubset(this IFluentXmlDocumentType self, string value)
        {
            Assert.NotNull(self, nameof(self));

            self.InternalSubset = value;
            return self;
        }
    }
}