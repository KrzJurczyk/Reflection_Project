using System.Collections.Generic;
using Interfaces;
using JetBrains.Annotations;

namespace ObjectsOfTypesProvider
{
    public class ListOfSingleTypes : IGeneralType
    {
        public string GeneralName { get; }

        public List<ITypeProvider> SingleType { get; }

        public ListOfSingleTypes([NotNull]string generalName, [NotNull, ItemNotNull]List<ITypeProvider> singleType)
        {
            GeneralName = generalName;
            SingleType = singleType;
        }
    }
}