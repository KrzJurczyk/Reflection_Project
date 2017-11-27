using JetBrains.Annotations;

namespace Interfaces
{
    public interface IAssemblyTypeProvider
    {
        [NotNull]
        IGeneralType GeneralAssembly { get; }
    }
}
