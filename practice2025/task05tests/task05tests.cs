using Xunit;
using task05;

namespace task05tests
{
    public class TestClass
    {
        public int PublicField;
        private string _privateField;
        public int Property { get; set; }

        public void Method() { }
        public int MethodWithParams(int x1, string x2) => 0;
    }

    [Serializable]
    public class AttributedClass { }

    public class ClassAnalyzerTests
    {
        [Fact]
        public void GetPublicMethods_ReturnsCorrectMethods()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var methods = analyzer.GetPublicMethods();

            Assert.Contains("Method", methods);
        }

        [Fact]
        public void GetAllFields_IncludesPrivateFields()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var fields = analyzer.GetAllFields();

            Assert.Contains("_privateField", fields);
        }

        [Fact]
        public void GetProperties_Returns_PropertyNames()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var properties = analyzer.GetProperties();

            Assert.Contains("Property", properties);
        }

        [Fact]
        public void HasAttribute_Returns_TrueIfAttributeExists()
        {
            var analyzer = new ClassAnalyzer(typeof(AttributedClass));

            Assert.True(analyzer.HasAttribute<SerializableAttribute>());
        }

        [Fact]
        public void HasAttribute_Returns_FalseIfAttributeNotPresent()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));

            Assert.False(analyzer.HasAttribute<SerializableAttribute>());
        }
    }
}
