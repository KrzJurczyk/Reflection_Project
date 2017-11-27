using System.Collections.Generic;
using System.Reflection;
using Interfaces;
using JetBrains.Annotations;

namespace ObjectsOfTypesProvider
{
    public class Types : ITypeProvider
    {
        public string ClassName { get; }
        public List<FieldInfo> FieldsType { get; }
        public List<EventInfo> EventsType { get; }
        public List<MethodInfo> MethodsType { get; }
        public List<PropertyInfo> PropertiesType { get; }

        public Types([NotNull] string nameType, [NotNull, ItemNotNull]List<FieldInfo> fieldsType, [NotNull, ItemNotNull]List<PropertyInfo> propertiesType, [NotNull, ItemNotNull]List<MethodInfo> methodsType, [NotNull, ItemNotNull]List<EventInfo> eventsType)
        {
            ClassName = nameType;
            FieldsType = fieldsType;
            PropertiesType = propertiesType;
            MethodsType = methodsType;
            EventsType = eventsType;
        }
    }
}