using System;

namespace ViewTypeInfoDemo
{
    public class Baz
    {
        private readonly string quux;

        private static int waldo;

        static Baz() => waldo = 1;

        public Baz() { }
        public Baz(string quux) => this.quux = quux; 

    }
}