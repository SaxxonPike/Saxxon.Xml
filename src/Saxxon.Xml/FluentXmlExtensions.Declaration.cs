// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Saxxon.Xml
{
    public static partial class FluentXmlExtensions
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