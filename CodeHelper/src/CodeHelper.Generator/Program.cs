using System;
using CodeHelper.Generator.SimpleCoders;

namespace CodeHelper.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Generator!");

            var simpleCoder = new SimpleCoder();
            simpleCoder.Builder();

            Console.WriteLine("See You Generator!");

            Console.Read();
        }
    }
}
