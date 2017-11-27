using JetBrains.Annotations;

namespace Interfaces
{
    public interface IPathProvider
    {
        [NotNull]
        string PathFile { get; }
    }
}