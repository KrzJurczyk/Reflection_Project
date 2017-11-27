using AssemblyProvider;
using Interfaces;
using Ninject.Modules;
using PathProvider;

namespace Reflection
{
    internal class ProgramModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAssemblyOpener>().To<AssemblyPathOpener>();

            Bind<IAssemblyTypeProvider>().To<AssemblyTypeProvider>();

            Bind<IPathProvider>().To<LocalPathProvider>();
        }
    }
}