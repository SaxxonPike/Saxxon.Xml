using System;
using System.Xml.Linq;

namespace Saxxon.Xml.Impl.SysXmlLinq
{
    internal class FluentSysXmlLinqDocumentType : FluentSysXmlLinqNodeBase, IFluentXmlDocumentType
    {
        private readonly XDocumentType _docType;

        public FluentSysXmlLinqDocumentType(XDocumentType docType)
        {
            _docType = docType;
        }

        public override string Name => "DOCTYPE";

        public override XObject Node => _docType;

        public string SystemId
        {
            get => _docType.SystemId;
            set => _docType.SystemId = value;
        }

        public string PublicId
        {
            get => _docType.PublicId;
            set => _docType.PublicId = value;
        }

        public string InternalSubset
        {
            get => _docType.InternalSubset;
            set => _docType.InternalSubset = value;
        }

        public string Id
        {
            get => _docType.Name;
            set => _docType.Name = value;
        }
    }
}