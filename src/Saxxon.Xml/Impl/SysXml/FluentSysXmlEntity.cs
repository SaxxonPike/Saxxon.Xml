using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal sealed class FluentSysXmlEntity : FluentSysXmlBase, IFluentXmlEntity
    {
        private readonly XmlEntity _entity;

        public FluentSysXmlEntity(XmlEntity entity)
        {
            _entity = entity;
        }

        public override XmlNode Node => _entity;

        public string SystemId => _entity.SystemId;

        public string PublicId => _entity.PublicId;

        public string NotationName => _entity.NotationName;
    }
}