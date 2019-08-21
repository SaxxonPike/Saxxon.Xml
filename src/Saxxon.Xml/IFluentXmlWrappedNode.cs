namespace Saxxon.Xml
{
    public interface IFluentXmlWrappedObject<out T>
    {
        T Node { get; }
    }
}