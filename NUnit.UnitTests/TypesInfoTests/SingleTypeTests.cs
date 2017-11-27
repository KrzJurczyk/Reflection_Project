using System.Collections.Generic;
using System.Reflection;
using Interfaces;
using NUnit.Framework;

namespace NUnit.UnitTests.TypesInfoTests
{
    internal sealed class TestClassType : ITypeProvider
    {
        public string ClassName { get; }

        public List<FieldInfo> FieldsType { get; }
        public List<EventInfo> EventsType { get; }
        public List<MethodInfo> MethodsType { get; }
        public List<PropertyInfo> PropertiesType { get; }

        public TestClassType(string nameType, List<FieldInfo> fieldsType, List<PropertyInfo> propertiesType, List<MethodInfo> methodsType, List<EventInfo> eventsType)
        {
            ClassName = nameType;
            FieldsType = fieldsType;
            PropertiesType = propertiesType;
            MethodsType = methodsType;
            EventsType = eventsType;
        }
    }

    [TestFixture]
    public class SingleTypeTests
    {
        [Test]
        public void SingleType_TypeIsRight()
        {
            var testsSingleType = new TestClassType("testName", new List<FieldInfo>(), new List<PropertyInfo>(), new List<MethodInfo>(), new List<EventInfo>());
            
            Assert.IsInstanceOf<ITypeProvider>(testsSingleType);
        }
        
        [Test]
        public void StringNames_AreMatch([Range(0, 1000, 99)] int d)
        {
            var testStringName = $"{d}";

            var testsSingleType = new TestClassType(testStringName, new List<FieldInfo>(), new List<PropertyInfo>(), new List<MethodInfo>(), new List<EventInfo>());

            Assert.That(testsSingleType.ClassName, Is.EqualTo(testStringName));
        }

        [Test]
        public void FieldTypes_AreMatch([Range(0, 1000, 99)] int d)
        {
            var testFieldType = new List<FieldInfo>(d);

            var testsSingleType = new TestClassType("testName", testFieldType, new List<PropertyInfo>(), new List<MethodInfo>(), new List<EventInfo>());

            Assert.That(testsSingleType.FieldsType, Is.EqualTo(testFieldType));
        }

        [Test]
        public void PropertyTypes_AreMatch([Range(0, 1000, 99)] int d)
        {
            var testPropertyType = new List<PropertyInfo>(d);

            var testsSingleType = new TestClassType("testName", new List<FieldInfo>(), testPropertyType, new List<MethodInfo>(), new List<EventInfo>());

            Assert.That(testsSingleType.PropertiesType, Is.EqualTo(testPropertyType));
        }

        [Test]
        public void MethodTypes_AreMatch([Range(0, 1000, 99)] int d)
        {
            var testMethodType = new List<MethodInfo>(d);

            var testsSingleType = new TestClassType("testName", new List<FieldInfo>(), new List<PropertyInfo>(), testMethodType, new List<EventInfo>());

            Assert.That(testsSingleType.MethodsType, Is.EqualTo(testMethodType));
        }

        [Test]
        public void EventTypes_AreMatch([Range(0, 1000, 99)] int d)
        {
            var testEventType = new List<EventInfo>(d);

            var testsSingleType = new TestClassType("testName", new List<FieldInfo>(), new List<PropertyInfo>(), new List<MethodInfo>(), testEventType);

            Assert.That(testsSingleType.EventsType, Is.EqualTo(testEventType));
        }
    }
}