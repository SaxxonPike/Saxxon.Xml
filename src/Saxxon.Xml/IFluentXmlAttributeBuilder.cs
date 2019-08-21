namespace Saxxon.Xml
{
    public interface IFluentXmlAttributeBuilder
    {
        IFluentXmlAttributeBuilder WithKey(string key);
        IFluentXmlAttributeBuilder WithValue<T>(T value);
    }

    internal interface IFluentXmlAttributeCreator<out T> : IFluentXmlAttributeBuilder
    {
        T Create();
    }
}