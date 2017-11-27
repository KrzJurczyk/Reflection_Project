using System.Collections.Generic;
using JetBrains.Annotations;

namespace Interfaces
{
    public interface IGeneralType
    {
        [NotNull]
        string GeneralName { get; }
        [NotNull, ItemNotNull]
        List<ITypeProvider> SingleType { get; }
    }
}
