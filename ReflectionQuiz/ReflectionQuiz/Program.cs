using System;
using System.Reflection;
using System.Text;
namespace ReflectionQuiz
{
    class Program
    {
        public static void Main()
        {
            var info = typeof(ReflectionQuiz.Baz).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Select(fi => fi.Name)
            .Aggregate(string.Empty, (prev, next) => prev += $" {next}");

            Console.WriteLine(info);

            object @object = Activator.CreateInstance<List<int>>();
        }
    }
    public class Baz
    {
        private readonly string quux;
        private static int waldo;
        private const decimal fred = 1.0m;

        public double plugh;
        static Baz() => waldo = 1;
        public Baz() { }
        public Baz(string quux) => this.quux = quux;

    }
}