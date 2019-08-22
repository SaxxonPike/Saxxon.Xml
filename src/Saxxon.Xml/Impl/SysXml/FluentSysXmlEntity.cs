using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal class FluentSysXmlEntity : FluentSysXmlBase, IFluentXmlEntity
    {
        private readonly XmlEntity _entity;

        public FluentSysXmlEntity(XmlEntity entity)
        {
            _entity = entity;
        }

        public override XmlNode Node => _entity;
    }
}