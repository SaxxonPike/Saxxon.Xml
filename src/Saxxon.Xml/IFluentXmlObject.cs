namespace Saxxon.Xml
{
    public interface IFluentXmlObject
    {
        IFluentXmlNode Parent { get; }

        string Name { get; }
        
        string Namespace { get; }

        string Value { get; set; }
    }
}