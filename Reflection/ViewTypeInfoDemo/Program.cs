using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ViewTypeInfoDemo
{
    class Program
    {
        static void Main()
        {

            // ====== 1️⃣ Getting Assembly, Module, and Type ======
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Current Assembly: {currentAssembly.FullName}");
            Console.WriteLine($"Main Module: {currentAssembly.ManifestModule.Name}");


            // Get Type of a built-in .NET class (String)
            Type stringType = typeof(string);
            Console.WriteLine($" PROBA : {stringType.Module.Assembly}");
            Console.WriteLine($"\nType from CLR: {stringType.FullName}");
            Console.WriteLine($"Module: {stringType.Module.Name}");
            Console.WriteLine($"Assembly: {stringType.Assembly.FullName}");

            // ====== 2️⃣ Load another assembly (mscorlib is automatically loaded in .NET 6+) ======
            // Example: list all types in System.Private.CoreLib (core system assembly)
            Assembly coreAssembly = typeof(object).Assembly;
            Console.WriteLine($"\nLoaded Assembly: {coreAssembly.GetName().Name}");
            Console.WriteLine("First few types:");
            foreach (var t in coreAssembly.GetTypes()[..5]) // first 5 types only
                Console.WriteLine($" - {t.FullName}");

            // ====== 3️⃣ Working with Type directly ======
            Type fileType = typeof(System.IO.File);
            Console.WriteLine($"\nAnalyzing type: {fileType.FullName}");
            Console.WriteLine($"Is Public: {fileType.IsPublic}");
            Console.WriteLine($"Is Abstract: {fileType.IsAbstract}");
            Console.WriteLine($"Is Sealed: {fileType.IsSealed}");

            MemberInfo[] members = fileType.GetMembers();
            Console.WriteLine($"Total Members: {members.Length}");

            // Show a few
            Console.WriteLine("First 10 members:");
            foreach (var m in members[..10])
                Console.WriteLine($" - {m.MemberType}: {m.Name}");

            // ====== 4️⃣ Get Constructors of a Type ======
            Type personType = typeof(Person);
            Console.WriteLine($"\nListing Constructors for: {personType.FullName}");
            ConstructorInfo[] ctors = personType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            PrintMembers(ctors);

            // ====== 5️⃣ Get Methods, Fields, Properties, Events (Static & Instance) ======
            Console.WriteLine("\n=== Static Members ===");
            PrintMembers(personType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));

            Console.WriteLine("\n=== Instance Members ===");
            PrintMembers(personType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));

            Console.WriteLine("\n=== Fields ===");
            PrintMembers(personType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));

            Console.WriteLine("\n=== Properties ===");
            PrintMembers(personType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));

            // ====== 6️⃣ Checking Member Types ======
            MethodInfo methodInfo = typeof(FieldInfo).GetMethod("GetValue")!;
            Console.WriteLine($"\nMember info example:");
            Console.WriteLine($"Type: {methodInfo.DeclaringType!.FullName}");
            Console.WriteLine($"Member name: {methodInfo.Name}");
            Console.WriteLine($"Member type: {methodInfo.MemberType}");


            var type = typeof(ViewTypeInfoDemo.Baz);
            var count1 = type.GetConstructors(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Length;
            var count2 = type.GetConstructors(BindingFlags.Static | BindingFlags.Instance).Length;
            var count3 = type.GetConstructors().Length;
            string result = $"{count1} {count2} {count3}";
            Console.WriteLine(result);

            Console.WriteLine("\nPress ENTER to exit.");
            Console.ReadLine();

        }
        static void PrintMembers(MemberInfo[] members)
        {
            foreach (var m in members)
                Console.WriteLine($" - {m.MemberType}: {m.Name}");
        }

    }
}