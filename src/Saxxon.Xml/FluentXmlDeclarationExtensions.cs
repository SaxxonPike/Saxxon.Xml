// ReSharper disable UnusedMethodReturnValue.Global

namespace Saxxon.Xml
{
    public static class FluentXmlDeclarationExtensions
    {
        public static IFluentXmlDeclaration SetVersion(this IFluentXmlDeclaration obj, string value)
        {
            obj.Version = value;
            return obj;
        }

        public static IFluentXmlDeclaration SetStandalone(this IFluentXmlDeclaration obj, string value)
        {
            obj.Standalone = value;
            return obj;
        }

        public static IFluentXmlDeclaration SetEncoding(this IFluentXmlDeclaration obj, string value)
        {
            obj.Encoding = value;
            return obj;
        }
    }
}