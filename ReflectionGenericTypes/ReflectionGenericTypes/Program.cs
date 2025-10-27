using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ReflectionGenericTypes
{
    class Program
    {
        static void Main()
        {
            Type d1 = typeof(Dictionary<,>);

            Console.WriteLine($"   Is this a generic type? {d1.IsGenericType}");
            Console.WriteLine($"   Is this a generic type definition? {d1.IsGenericTypeDefinition}");

            Type[] typeParameters = d1.GetGenericArguments();

            Console.WriteLine($"   List {typeParameters.Length} type arguments:");
            foreach (Type tParam in typeParameters)
            {
                Console.WriteLine(tParam.Name);
            }

            Assembly assembly = Assembly.GetExecutingAssembly();

            var modules = assembly.GetModules();
            foreach (Module m in modules)
            {
                Console.WriteLine(m.GetType());
            }

            Console.WriteLine(new string('-', 30));


            Type stringType = typeof(string);

            Console.WriteLine($"Full Name: {stringType.FullName}");
            Console.WriteLine($"Base Type: {stringType.BaseType}");
            Console.WriteLine($"Is Class: {stringType.IsClass}");
            Console.WriteLine($"Is Value Type: {stringType.IsValueType}");
            Console.WriteLine($"Assembly: {stringType.Assembly.FullName}");

            // --- Part 4: Reflection on Person class ---
            DisplayPersonProperties();

            Console.WriteLine(new string('-', 30));
            AccessingFields();

            Console.WriteLine(new string('-', 30));

            // --- Part 5: Reflection on Calculator class ---


            Type calcType = typeof(Calculator);
            var methodInfos = calcType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach(var method in methodInfos)
            {
                Console.WriteLine(method.Name);
            }

            MethodInfo addMethod = calcType.GetMethod("Add");
            MethodInfo multiplyMethod = calcType.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            Console.WriteLine(multiplyMethod?.Name ?? "nulllllll");

            MethodInfo[] allMethods = calcType.GetMethods(
             BindingFlags.Public | BindingFlags.NonPublic |
             BindingFlags.Instance | BindingFlags.Static |
             BindingFlags.DeclaredOnly
             );

            foreach (var m in allMethods)
            {
                Console.WriteLine($"{m.Name}, IsPublic={m.IsPublic}, IsStatic={m.IsStatic}, Params=[{string.Join(",", m.GetParameters().Select(p => p.ParameterType.Name))}]");
            }
        }
        public static void DisplayPersonProperties()
        {
            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties();

            Console.WriteLine($"Properties of {personType.Name}:");
            foreach (var prop in properties)
            {
                Console.WriteLine($"   {prop.Name} ({prop.PropertyType})");
            }
        }

        public static void AccessingFields()
        {
            Type personType = typeof(Person);
            personType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Public | 
                BindingFlags.NonPublic
                );

            var person = Activator.CreateInstance(personType);
            

            FieldInfo[] fields = personType.GetFields(BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);



            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
               
            }


            Person person2 = new Person { Name = "John", Age = 30 };

            FieldInfo secretField = personType.GetField("_secret", BindingFlags.NonPublic | BindingFlags.Instance);

            var secretValue = secretField.GetValue(person2);

            secretField.SetValue(person2, "new value");
            Console.WriteLine(secretField.GetValue(person));
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            private string _secret = "hidden";
        }

        public class Calculator
        {
            public int Add (int a,  int b) => a + b;
            private double Multiply (double a, double b) => a * b;
        }
    }
    
}
