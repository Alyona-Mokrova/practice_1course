using System;
using System.Linq;
using System.Reflection;

namespace task07
{
    public class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    public class VersionAttribute : Attribute
    {
        public int Major { get; }
        public int Minor { get; }
        public VersionAttribute(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }

    [Version(1, 0)]
    [DisplayName("Пример класса")]
    public class SampleClass
    {
        [DisplayName("Тестовый метод")]
        public void TestMethod(){ }
        [DisplayName("Числовое свойство")]
        public int Number { get; set; }
    }

    public static class ReflectionHelper
    {
        public static void PrintTypeInfo(Type type)
        {
            var classDisplayNameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
            if (classDisplayNameAttribute != null)
                Console.WriteLine($"DisplayName класса: {classDisplayNameAttribute.DisplayName}");

            var classVersionAttribute = type.GetCustomAttribute<VersionAttribute>();
            if (classVersionAttribute != null)
                Console.WriteLine($"Версия класса: {classVersionAttribute.Major}.{classVersionAttribute.Minor}");

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("Методы с DisplayName: ");

            var methodsWithDisplayNameAttribute = methods
                .Select(method => new { Method = method, Attr = method.GetCustomAttribute<DisplayNameAttribute>() })
                .Where(x => x.Attr != null);
            foreach (var item in methodsWithDisplayNameAttribute)
                Console.WriteLine($"-{item.Method.Name}: {item.Attr.DisplayName}");

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var propertiesWithDisplayNameAttribute = properties
                .Select(property => new { Property = property, Attr = property.GetCustomAttribute<DisplayNameAttribute>() })
                .Where(x => x.Attr != null);
            Console.WriteLine("Свойства с DisplayName: ");

            foreach (var item in propertiesWithDisplayNameAttribute)
                Console.WriteLine($"-{item.Property.Name}: {item.Attr.DisplayName}");
        }
    }
}
