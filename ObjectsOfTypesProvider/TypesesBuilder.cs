using System.Collections.Generic;
using System.Reflection;
using Interfaces;

namespace ObjectsOfTypesProvider
{
    public class TypesesBuilder : ITypesesBuilder
    {
        public string NameBuilder { get; set; } = "";
        public List<FieldInfo> FieldsBuilderType { get; } = new List<FieldInfo>();
        public List<PropertyInfo> PropertiesBuilderType { get; } = new List<PropertyInfo>();
        public List<MethodInfo> MethodsBuilderType { get; } = new List<MethodInfo>();
        public List<EventInfo> EventsBuilderType { get; } = new List<EventInfo>();

        public ITypeProvider BuildNewSingleType()
        {
            return new Types(NameBuilder, FieldsBuilderType, PropertiesBuilderType, MethodsBuilderType, EventsBuilderType);
        }
    }
}