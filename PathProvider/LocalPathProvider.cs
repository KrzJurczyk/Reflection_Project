using Interfaces;
using System.IO;

namespace PathProvider
{
    public class LocalPathProvider : IPathProvider
    {
        public string PathFile => Path.GetFullPath(@"Ninject.dll");
    }
}
