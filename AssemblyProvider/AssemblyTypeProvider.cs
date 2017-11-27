using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AttributeProvider;
using Interfaces;
using JetBrains.Annotations;
using ObjectsOfTypesProvider;

namespace AssemblyProvider
{
    public class AssemblyTypeProvider : IAssemblyTypeProvider
    {
        [NotNull]
        private readonly IAssemblyOpener _openedAssembly;

        [ItemNotNull]
        private readonly List<ITypeProvider> _listOfTypes = new List<ITypeProvider>();

        [CanBeNull]
        private IGeneralType _generalAssembly;
        
        public IGeneralType GeneralAssembly => _generalAssembly ?? (_generalAssembly = ParseAssemblies());

        public AssemblyTypeProvider([NotNull]IAssemblyOpener openedAssembly)
        {
            _openedAssembly = openedAssembly;
        }

        [NotNull]
        private static IEnumerable<T> RemoveIgnored<T>(IEnumerable<T> enumerable) where T : MemberInfo
        {
            return enumerable.Select(p => new { val = p, attribute = p.GetCustomAttribute(typeof(IgnoreContentAttribute)) })
                .Where(p => p.attribute == null).Select(p => p.val);
        }

        [NotNull]
        private IGeneralType ParseAssemblies()
        {
            foreach (var type in _openedAssembly.LoadedAssembly.GetExportedTypes())
            {
                var singleTypeBuilder = new TypesesBuilder();
                singleTypeBuilder.NameBuilder = type.Name;
                singleTypeBuilder.FieldsBuilderType.AddRange(RemoveIgnored(type.GetFields()));
                singleTypeBuilder.PropertiesBuilderType.AddRange(RemoveIgnored(type.GetProperties()));
                singleTypeBuilder.MethodsBuilderType.AddRange(RemoveIgnored(type.GetMethods()));
                singleTypeBuilder.EventsBuilderType.AddRange(RemoveIgnored(type.GetEvents()));

                _listOfTypes.Add(singleTypeBuilder.BuildNewSingleType());
            }
            return new ListOfSingleTypes(_openedAssembly.LoadedAssembly.FullName, _listOfTypes);
        }
    }
}
