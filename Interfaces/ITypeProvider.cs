using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Interfaces
{
    public interface ITypeProvider
    {
        [NotNull]
        string ClassName { get; }
        [NotNull, ItemNotNull]
        List<FieldInfo> FieldsType { get; }
        [NotNull, ItemNotNull]
        List<PropertyInfo> PropertiesType { get; }
        [NotNull, ItemNotNull]
        List<MethodInfo> MethodsType { get; }
        [NotNull, ItemNotNull]
        List<EventInfo> EventsType { get; }
    }
}
