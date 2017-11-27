using System;
using System.Collections.Generic;
using Interfaces;
using JetBrains.Annotations;

namespace Reflection
{
    internal class PrintAssemblyContent
    {
        [NotNull]
        private readonly IAssemblyTypeProvider _assemblyInfo;

        public PrintAssemblyContent(IAssemblyTypeProvider assemblyInfo)
        {
            _assemblyInfo = assemblyInfo;
        }

        public void Run()
        {
            Console.WriteLine("Informacje o podanym assembly: ");
            Console.WriteLine($"Nazwa: {_assemblyInfo.GeneralAssembly.GeneralName}");
            
            foreach (var singleType in _assemblyInfo.GeneralAssembly.SingleType)
            {
                Console.WriteLine("\n_________________________\n");
                Console.WriteLine($"ClassName: {singleType.ClassName}");
                Printer(singleType.FieldsType, "Fields");
                Printer(singleType.PropertiesType, "Properties");
                Printer(singleType.MethodsType, "Methods");
                Printer(singleType.EventsType, "Events");
            }
        }

        private void Printer<T>(List<T> singleType, string name)
        {
            Console.WriteLine($"\n\t{name}: ");
            if (singleType != null)
                foreach (var a in singleType)
                {
                    Console.WriteLine($"\t\t{a}.");
                }
        }
    }
}