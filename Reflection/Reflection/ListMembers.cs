
using System;
using System.Reflection;

namespace Reflection
{
    class ListMembers
    {
        public static void Main()
        {
            Type t = typeof(System.String);
            Console.WriteLine($"Listing all the public constructors of the {t} type");
            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("//Constructors");
            PrintMembers(ci);
        }
        public static void PrintMembers(ConstructorInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine($"{"     "}{m}");
            }
            Console.WriteLine();
        }
    }
}
