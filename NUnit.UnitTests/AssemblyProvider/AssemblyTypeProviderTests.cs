using System;
using System.IO;
using System.Reflection;
using Interfaces;
using Moq;
using NUnit.Framework;

namespace NUnit.UnitTests.AssemblyProvider
{
    internal class TestPath : IPathProvider
    {
        public string PathFile { get; } = Path.Combine(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) ?? string.Empty).LocalPath,@"AttributeProvider.dll");
    }

    public class AssemblyTypeProviderTests
    {
        [TestFixture]
        public class AssemblyTypeInfoTests
        {
            [Test]
            public void AssemblyName_IsMatch()
            {
                var mockAssembly = Mock.Of<IAssemblyOpener>(p =>
                    p.LoadedAssembly == Assembly.LoadFile(new TestPath().PathFile));
                
                var stringName = mockAssembly.LoadedAssembly.FullName;

                Assert.That(stringName, Is.EqualTo(Assembly.LoadFrom(new TestPath().PathFile).FullName));
            }
        }
    }
}