using System.Reflection;

namespace MSDocsReflectionDemo
{
    class Program
    {
        static void Main()
        {

            // Load the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Assembly: {assembly.FullName}");
            Console.WriteLine(new string('-', 40));

            // Get all types in this assembly
            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"Type: {type.FullName}");

                // Get constructors
                Console.WriteLine("\nConstructors:");
                foreach (ConstructorInfo ctor in type.GetConstructors())
                    Console.WriteLine($" - {ctor}");

                // Get methods
                Console.WriteLine("\nMethods:");
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                    Console.WriteLine($" - {method.Name}");

                // Get fields
                Console.WriteLine("\nFields:");
                foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                    Console.WriteLine($" - {field.Name} (Access: {(field.IsPublic ? "Public" : "Private")})");

                // Get properties
                Console.WriteLine("\nProperties:");
                foreach (PropertyInfo prop in type.GetProperties())
                    Console.WriteLine($" - {prop.Name} ({prop.PropertyType.Name})");

                Console.WriteLine(new string('-', 40));
            }

            // Create an instance dynamically
            Type personType = typeof(Person);
            object person = Activator.CreateInstance(personType, "Alice", 25)!;

            // Access field
            FieldInfo nameField = personType.GetField("Name")!;
            Console.WriteLine($"\nOriginal Name field: {nameField.GetValue(person)}");
            nameField.SetValue(person, "Bob");

            // Access property
            PropertyInfo countryProp = personType.GetProperty("Country")!;
            countryProp.SetValue(person, "Germany");
            Console.WriteLine($"Property Country set to: {countryProp.GetValue(person)}");

            // Invoke public method
            MethodInfo greetMethod = personType.GetMethod("Greet")!;
            greetMethod.Invoke(person, null);

            // Invoke private method
            MethodInfo secretMethod = personType.GetMethod("Secret", BindingFlags.NonPublic | BindingFlags.Instance)!;
            secretMethod.Invoke(person, null);
        }

    }
  }
