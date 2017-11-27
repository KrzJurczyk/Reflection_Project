using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Interfaces
{
    public interface ITypesesBuilder
    {
        [NotNull]
        string NameBuilder { get; }
        [NotNull, ItemNotNull]
        List<FieldInfo> FieldsBuilderType { get; }
        [NotNull, ItemNotNull]
        List<PropertyInfo> PropertiesBuilderType { get; }
        [NotNull, ItemNotNull]
        List<MethodInfo> MethodsBuilderType { get; }
        [NotNull, ItemNotNull]
        List<EventInfo> EventsBuilderType { get; }
        [NotNull]
        ITypeProvider BuildNewSingleType();
    }
}
