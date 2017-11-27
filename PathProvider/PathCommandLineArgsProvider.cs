using System;
using Interfaces;

namespace PathProvider
{
    public class PathCommandLineArgsProvider : IPathProvider
    {
        public string PathFile { get; } = Environment.GetCommandLineArgs()[1];

    }
}
