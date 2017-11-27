using System.Collections.Generic;
using System.Reflection;

namespace Interfaces
{
    public interface IBuilderSingleTypeProvider
    {
        string GeneralName { get; set; }
        string ClassOfTypeName { get; set; }
        List<FieldInfo> FieldsType { get; }
        List<PropertyInfo> PropertiesType { get; }
        List<MethodInfo> MethodsType { get; }
        List<EventInfo> EventsType { get; }
        ISingleTypeProvider BuildNewSingleType();
    }
}