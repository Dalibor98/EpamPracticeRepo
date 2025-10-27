using System;

namespace MSDocsReflectionDemo
{
    // This is a siimple test clas to inspect using reflection.
    public class Person
    {
        public string Name;
        private int age;

        public string Country { get; set; }

        public Person() { Name = "Unknown"; age = 0; }

        public Person(string name, int age) 
        {
            Name = name;
            this.age = age;
        }

        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name}, and I am {age} years old!");
        }

        private void Secret() => Console.WriteLine("This is a private method");

    }
}
