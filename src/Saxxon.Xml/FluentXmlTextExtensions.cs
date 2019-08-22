// ReSharper disable UnusedMethodReturnValue.Global

namespace Saxxon.Xml
{
    public static class FluentXmlTextExtensions
    {
        public static IFluentXmlText SetText(this IFluentXmlText obj, string content)
        {
            obj.Value = content;
            return obj;
        }
    }
}