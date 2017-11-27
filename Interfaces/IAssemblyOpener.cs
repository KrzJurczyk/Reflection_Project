using System.Reflection;
using JetBrains.Annotations;

namespace Interfaces
{
    public interface IAssemblyOpener
    {
        [NotNull]
        Assembly LoadedAssembly { get; }
    }
}
