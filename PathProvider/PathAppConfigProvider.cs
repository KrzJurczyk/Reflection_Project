using System.Collections.Specialized;
using System.Configuration;
using Interfaces;

namespace PathProvider
{
    public class PathAppConfigProvider : IPathProvider
    {
        public string PathFile { get; } = ((NameValueCollection)ConfigurationManager.GetSection("AssemblerClassConfig"))["FilePath"];
    }
}