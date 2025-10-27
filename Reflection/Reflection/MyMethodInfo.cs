using System;
using System.Reflection;


namespace Reflection
{
    class MyMethodInfo
    {
        public static int Main()
        {
            Console.WriteLine("Reflection.MethodInfo");
            // Gets and displays the Type.

            Type myStr = Type.GetType("System.String");

            ConstructorInfo[] infos = myStr.GetConstructors();
            foreach(ConstructorInfo info in infos)
            {
                Console.WriteLine($"My info: {info.GetParameters()}");
            }

            Console.WriteLine($"{Assembly.GetExecutingAssembly().GetTypes()}");
            var myTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in myTypes)
            {
                Console.WriteLine(type.GetElementType());
            }

            Assembly a = typeof(object).Module.Assembly;
            foreach (Type type in a.GetTypes())
            {
                Console.WriteLine(type.Name);
            }

        Type myType = Type.GetType("System.Reflection.FieldInfo");
            // Specifies the member for which you want type information.
            MethodInfo myMethodInfo = myType.GetMethod("GetValue");
            Console.WriteLine(myType.FullName + "." + myMethodInfo.Name);
            // Gets and displays the MemberType property.
            MemberTypes myMemberTypes = myMethodInfo.MemberType;
            if (MemberTypes.Constructor == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type All");
            }
            else if (MemberTypes.Custom == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Event");
            }
            else if (MemberTypes.Field == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Field");
            }
            else if (MemberTypes.Method == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Method");
            }
            else if (MemberTypes.Property == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Property");
            }
            else if (MemberTypes.TypeInfo == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type TypeInfo");
            }
            return 0;
        }
    }
}
