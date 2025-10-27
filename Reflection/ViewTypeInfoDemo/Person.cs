using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewTypeInfoDemo
{
    public class Person
    {
        public string Name;
        private int age;
        public static int PopulationCount = 0;

        public string Country { get; set; }
        public event EventHandler? OnBirthday;

        public Person() { Name = "Unknown"; age = 0; }
        public Person(string name, int age)
        {
            Name = name;
            this.age = age;
        }

        public void Greet() => Console.WriteLine($"Hi, I'm {Name} ({age} years old).");
        private void Secret() => Console.WriteLine("Shh, this is private!");
    }
}
