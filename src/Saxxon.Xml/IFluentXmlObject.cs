namespace Saxxon.Xml
{
    public interface IFluentXmlObject
    {
        IFluentXmlObject Parent { get; }
        
        IFluentXmlChildSet Children { get; }
        
        string Name { get; }
        
        string InnerXml { get; }

        IFluentXmlAttributeSet Attributes { get; }
    }
}