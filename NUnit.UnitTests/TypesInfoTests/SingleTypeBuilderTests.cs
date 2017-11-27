using System.Collections.Generic;
using System.Reflection;
using Interfaces;
using Moq;
using NUnit.Framework;
using ObjectsOfTypesProvider;

namespace NUnit.UnitTests.TypesInfoTests
{
    internal class TestClassTypesesBuilder : ITypesesBuilder
    {
        public string NameBuilder { get; set; }
        public List<FieldInfo> FieldsBuilderType { get; set; }
        public List<PropertyInfo> PropertiesBuilderType { get; set; }
        public List<MethodInfo> MethodsBuilderType { get; set; }
        public List<EventInfo> EventsBuilderType { get; set; }

        public TestClassTypesesBuilder(string name, List<FieldInfo> field, List<PropertyInfo> property, List<MethodInfo> method, List<EventInfo> even)
        {
            NameBuilder = name;
            FieldsBuilderType = field;
            PropertiesBuilderType = property;
            MethodsBuilderType = method;
            EventsBuilderType = even;
        }

        public TestClassTypesesBuilder()
        {
            NameBuilder = "";
            FieldsBuilderType = new List<FieldInfo>();
            PropertiesBuilderType = new List<PropertyInfo>();
            MethodsBuilderType = new List<MethodInfo>();
            EventsBuilderType = new List<EventInfo>();
        }

        public ITypeProvider BuildNewSingleType()
        {
            return new Types(NameBuilder, FieldsBuilderType, PropertiesBuilderType, MethodsBuilderType, EventsBuilderType);
        }
    }

    [TestFixture]
    public class SingleTypeBuilderTests
    {
        [Test]
        public void SingleTypeBuilder_BuildNewSingleTypeIstanceIsRight()
        {
            var singleType = new TestClassTypesesBuilder();

            var testSingleType = singleType.BuildNewSingleType();

            Assert.IsInstanceOf<ITypeProvider>(testSingleType);
        }

        [Test]
        public void Name_IsReplacing([Range(0, 1000, 99)] int d)
        {
            var mockSingleType = Mock.Of<ITypesesBuilder>(build =>
                build.EventsBuilderType == new List<EventInfo>() &&
                build.FieldsBuilderType == new List<FieldInfo>() &&
                build.MethodsBuilderType == new List<MethodInfo>() &&
                build.PropertiesBuilderType == new List<PropertyInfo>() &&
                build.NameBuilder == $"{d}");

            Assert.That(mockSingleType.NameBuilder, Is.EqualTo($"{d}"));
        }

        [Test]
        public void BuildMethod_Returns_ITypeProvider()
        {
            var mockSingleType = Mock.Of<ITypesesBuilder>(build =>
                build.BuildNewSingleType().EventsType == new List<EventInfo>() &&
                build.BuildNewSingleType().FieldsType== new List<FieldInfo>() &&
                build.BuildNewSingleType().MethodsType == new List<MethodInfo>() &&
                build.BuildNewSingleType().PropertiesType == new List<PropertyInfo>() &&
                build.BuildNewSingleType().ClassName == "");

            var types = mockSingleType.BuildNewSingleType();

            Assert.IsInstanceOf<ITypeProvider>(types);
        }
    }
}
