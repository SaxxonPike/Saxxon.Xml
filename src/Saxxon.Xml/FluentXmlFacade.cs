using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Saxxon.Xml.Impl.SysXml;
using Saxxon.Xml.Impl.SysXmlLinq;

namespace Saxxon.Xml
{
    public static class FluentXmlFacade
    {
        #region Local Helpers


        
        #endregion
        
        #region Object

        public static IFluentXmlAttribute AsAttribute(this IFluentXmlObject obj) => 
            obj as IFluentXmlAttribute;
        
        public static IFluentXmlDeclaration AsDeclaration(this IFluentXmlObject obj) =>
            obj as IFluentXmlDeclaration;

        public static IFluentXmlDocument AsDocument(this IFluentXmlObject obj) => 
            obj as IFluentXmlDocument;

        public static IFluentXmlElement AsElement(this IFluentXmlObject obj) =>
            obj as IFluentXmlElement;

        public static IFluentXmlNode AsNode(this IFluentXmlObject obj) =>
            obj as IFluentXmlNode;

        public static T ForEach<T>(this T obj, Action<T> scope) 
            where T : IFluentXmlObject
        {
            scope(obj);
            return obj;
        }
        
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> obj, Action<T> scope) 
            where T : IFluentXmlObject
        {
            foreach (var node in obj)
                scope(node);

            return obj;
        }

        public static IEnumerable<T> WithName<T>(this IEnumerable<T> obj, string name) where T : IFluentXmlObject => 
            obj.Where(x => x.Name == name);

        #endregion Object
        
        #region System.Xml
        
        public static IFluentXmlAttribute Fluent(this XmlAttribute obj) =>
            (IFluentXmlAttribute) FluentSysXmlFactory.Create(obj);

        public static IFluentXmlDocument Fluent(this XmlDocument obj) =>
            (IFluentXmlDocument) FluentSysXmlFactory.Create(obj);
        
        #endregion
        
        #region System.Xml.Linq

        public static IFluentXmlAttribute Fluent(this XAttribute obj) =>
            (IFluentXmlAttribute) FluentSysXmlLinqFactory.Create(obj);

        public static IFluentXmlDocument Fluent(this XDocument obj) =>
            (IFluentXmlDocument) FluentSysXmlLinqFactory.Create(obj);
        
        #endregion System.Xml.Linq
    }
}