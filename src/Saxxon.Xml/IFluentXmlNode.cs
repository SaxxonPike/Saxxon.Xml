namespace Saxxon.Xml
{
    public interface IFluentXmlNode : IFluentXmlObject
    {
        string Xml { get; set; }

        IFluentXmlChildSet Children { get; }

        IFluentXmlAttributeSet Attributes { get; }

        IFluentXmlNode Next { get; }

        IFluentXmlNode Previous { get; }
    }
}