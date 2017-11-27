using System;
using Ninject;

namespace Reflection
{
    internal class Program
    {
        private static void Main()
        {
            var kernel = new StandardKernel(new ProgramModule());
            var flow = kernel.Get<PrintAssemblyContent>();

            flow.Run();
            Console.ReadKey();
        }
    }
}