namespace Saxxon.Xml
{
    internal interface IFluentXmlChildCreator
    {
        IFluentXmlObject CreateChild(IFluentXmlObject obj);
    }

    internal interface IFluentXmlChildCreator<out TBase> : IFluentXmlChildCreator
    {
        new TBase CreateChild(IFluentXmlObject obj);
    }
}