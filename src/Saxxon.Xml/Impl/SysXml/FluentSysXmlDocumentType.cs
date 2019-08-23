using System;
using System.Xml;

namespace Saxxon.Xml.Impl.SysXml
{
    internal class FluentSysXmlDocumentType : FluentSysXmlBase, IFluentXmlDocumentType
    {
        private readonly XmlDocumentType _docType;

        public FluentSysXmlDocumentType(XmlDocumentType docType)
        {
            _docType = docType;
        }

        public override XmlNode Node { get; }

        public string SystemId
        {
            get => _docType.SystemId;
            set => throw new NotSupportedException(
                $"{nameof(XmlDocumentType)} does not support setting {nameof(SystemId)}.");
        }

        public string PublicId
        {
            get => _docType.PublicId;
            set => throw new NotSupportedException(
                $"{nameof(XmlDocumentType)} does not support setting {nameof(PublicId)}.");
        }

        public string InternalSubset
        {
            get => _docType.InternalSubset;
            set => throw new NotSupportedException(
                $"{nameof(XmlDocumentType)} does not support setting {nameof(InternalSubset)}.");
        }
    }
}