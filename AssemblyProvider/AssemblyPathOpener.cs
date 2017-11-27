using System.Reflection;
using Interfaces;
using JetBrains.Annotations;
using System;
using System.IO;

namespace AssemblyProvider
{
    public class AssemblyPathOpener : IAssemblyOpener
    {
        public Assembly LoadedAssembly { get; }

        public AssemblyPathOpener([NotNull]IPathProvider pathToAssembly)
        {
            try
            {
                LoadedAssembly = Assembly.LoadFile(pathToAssembly.PathFile);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
