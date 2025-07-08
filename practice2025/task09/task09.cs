using System;
using System.Reflection;
using task07;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите путь к сборке.");
                return;
            }

            string path = args[0];
            if (!File.Exists(path))
            {
                return;
            }

            try
            {
                var assembly = Assembly.LoadFrom(path);
                Console.WriteLine($"Сборка: {assembly.FullName}");

                foreach (var type in assembly.GetTypes())
                {
                    if (!type.IsClass)
                        continue;

                    Console.WriteLine($"Класс: {type.FullName}");
                    Console.WriteLine(" Атрибуты класса:");
                    PrintAttributes(type);

                    var constrs = type.GetConstructors();
                    Console.WriteLine("Конструкторы:");
                    if (constrs.Length == 0)
                        Console.WriteLine("  отсутствуют");
                    foreach (var constr in constrs)
                    {
                        Console.WriteLine($"{constr.Name} параметры:");
                        var parameters = constr.GetParameters();
                        if (parameters.Length == 0)
                            Console.WriteLine("  отсутствуют");
                        else
                            foreach (var p in parameters)
                                Console.WriteLine($"{p.ParameterType.Name} {p.Name}");

                        Console.WriteLine("Атрибуты конструктора:");
                        PrintAttributes(constr,"  ");
                    }

                    var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);
                    Console.WriteLine("Методы:");
                    if (methods.Length == 0)
                        Console.WriteLine("  отсутствуют");
                    foreach (var method in methods)
                    {
                        Console.WriteLine($"{method.Name} параметры:");
                        var parameters = method.GetParameters();
                        if (parameters.Length == 0)
                            Console.WriteLine("  отсутствуют");
                        else
                            foreach (var p in parameters)
                                Console.WriteLine($"{p.ParameterType.Name} {p.Name}");

                        Console.WriteLine("Атрибуты метода:");
                        PrintAttributes(method,"  ");
                    }

                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    Console.WriteLine("Свойства:");
                    if (properties.Length == 0)
                        Console.WriteLine("  отсутствуют");
                    foreach (var prop in properties)
                    {
                        Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name})");
                        Console.WriteLine("Атрибуты свойства:");
                        PrintAttributes(prop, "  ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void PrintAttributes(ICustomAttributeProvider provider, string indent = "  ")
        {
            var attrs = provider.GetCustomAttributes(false);
            if (attrs.Length == 0)
            {
                Console.WriteLine($"{indent}атрибуты отсутствуют");
                return;
            }

            foreach (var attr in attrs)
            {
                switch (attr)
                {
                    case DisplayNameAttribute displayNameAttr:
                        Console.WriteLine($"{indent}DisplayName: {displayNameAttr.DisplayName}");
                        break;
                    case VersionAttribute versionAttr:
                        Console.WriteLine($"{indent}Version: {versionAttr.Major}.{versionAttr.Minor}");
                        break;
                    default:
                        Console.WriteLine($"{indent}{attr.GetType().Name}");
                        break;
                }
            }
        }
    }
}
