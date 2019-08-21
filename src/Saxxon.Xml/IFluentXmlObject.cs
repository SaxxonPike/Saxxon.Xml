namespace Saxxon.Xml
{
    public interface IFluentXmlObject
    {
        IFluentXmlObject Parent { get; }
        
        IFluentXmlChildSet Children { get; }
        
        string Name { get; }
        
        string Xml { get; }
        
        IFluentXmlAttributeSet Attributes { get; }
        
        string Value { get; set; }
    }
}